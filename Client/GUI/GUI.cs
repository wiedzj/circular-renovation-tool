using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingFutureCities
{
    partial class GUI : Form
    {
        private GUIController theController;
        public static Comparison comparison { get; set; }
        public GUI(GUIController controller)
        {
            InitializeComponent();
            theController = controller;
            
        }

        public void RefreshConfigurationScreen()
        {
            EmptyConfigurationScreen();
            theController.SendDataFromModelToView();
            SetTotalValuesInGui();
        }

        // Generates a screen with all the data that was retreived from the datamodel
        public void LoadProductsInToConfigurationScreen(IList<ProductGroup> productGroups)
        {
            // There a 6 columns
            int columnCount = 6;

            // There are as many rows as the length of the productgroups plus 1 for the first row where the "circulariteitscategory" is shown
            int rowCount = productGroups.Count + 1;

            //Now we will generate the table, setting up the row and column counts first
            configurationScreen.ColumnCount = columnCount;
            configurationScreen.RowCount = rowCount;

            SetCategoryNameToLabels();

            // Loops through all the rows
            for (int rowIndex = 0; rowIndex < productGroups.Count; rowIndex++)
            {
                // Add a new Row
                configurationScreen.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                // Get the productgroup that is used to fill in the columns of this row
                ProductGroup productGroup = productGroups[rowIndex];

                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                   
                    if (columnIndex == 0)
                    {
                        // Add column
                        configurationScreen.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                        // In the first column the productgroup name is shown
                        Label productGroupName = new Label();
                        productGroupName.Dock = DockStyle.Fill;
                        productGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        productGroupName.Text = productGroups[rowIndex].Name;
                        // row + 1 because in the first row the category is added
                        configurationScreen.Controls.Add(productGroupName, 0, rowIndex + 1);
                    } else
                    {
                        // Add column
                        configurationScreen.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                        // In column 2 - 6 a productclickable is placed
                        Product product = productGroup.GetProductFromCategory(columnIndex);
                        
                        ProductClickable productClickable = new ProductClickable(product, rowIndex + 1, columnIndex, theController);
                        productClickable.ProductGroup = productGroup;
                        if (productClickable.IsAvailable)
                        {
                            productClickable.MouseUp += ResetSelectionOnClick;
                            productClickable.MouseUp += SetTotalOnMouseClick;
                        }

                        // Add column to the row
                        configurationScreen.Controls.Add(productClickable, columnIndex, rowIndex + 1);
                    }
                }
            }
        }
        
        // Remove all the controls from the configuration screen
        private void EmptyConfigurationScreen()
        {
            // We start at the bottom of the table and go up
            for(int row = configurationScreen.RowCount - 1; row > 0; row--)
            {
                for (int i = 0; i < configurationScreen.ColumnCount; i++)
                {
                    var control = configurationScreen.GetControlFromPosition(i, row);
                    configurationScreen.Controls.Remove(control);
                }
                configurationScreen.RowStyles.RemoveAt(row);
                configurationScreen.RowCount--;
            }
        }

        // Sets the name of the labels in the first row of the configurationscreen to the "circulariteitscategorie"
        private void SetCategoryNameToLabels()
        {
            for (int i = 1; i < 6; i++)
            {
                Label categoryLabel = (Label) configurationScreen.GetControlFromPosition(i, 0);
                categoryLabel.Text = FunctionsGUI.GetCategoryName(i);
                categoryLabel.BackColor = FunctionsGUI.GetCategoryColor(i);
            }
        }

        // This function deselects the previously selected element in the row
        // So that only the newly selected element is selected
        private void ResetSelectionOnClick(object sender, EventArgs e)
        {
            RenovationConcept selectedRenovationConcept = theController.GetSelectedRenovationConcept();
            // This is only happens if the active renovation concept is circular (in the linear one, no elements can be selected)
            if (selectedRenovationConcept is Circular)
            {
                ProductClickable clickedElement = (ProductClickable) sender;
                int rowNumber = clickedElement.RowNumber;
                for (int i = 1; i < 6; i++)
                {
                    ProductClickable element = (ProductClickable) configurationScreen.GetControlFromPosition(i, rowNumber);

                    // Check if the element is not an empty one (so IsAvailable), if the element is clicked and if the element is not the element we just clicked
                    if (element.IsAvailable && element.IsSelected && element != clickedElement)
                    {
                        element.Deselect(true);
                        break;
                    }
                }
            }
        }

        // Deselect all the elements in the configurationscreen, for instance when changing to another renovationconcept
        private void ResetWholeSelection()
        {
            for (int row = 1; row < configurationScreen.RowCount; row++)
            {
                for (int column = 1; column < 6; column++)
                {
                    ProductClickable productClickable = (ProductClickable) configurationScreen.GetControlFromPosition(column, row);
                    if (productClickable.IsAvailable && productClickable.IsSelected)
                    {
                        productClickable.Deselect(false);
                        break;
                    }
                }
            }
        }

        private void buttonLinear_Click(object sender, EventArgs e)
        {
            ResetWholeSelection();
            theController.ChangeSelectedRenovationConcept("linear");
            DisableChosenButton(buttonLinear);
        }

        private void buttonCirculair1_Click(object sender, EventArgs e)
        {
            ResetWholeSelection();
            theController.ChangeSelectedRenovationConcept("circular1");
            DisableChosenButton(buttonCirculair1);
        }

        private void buttonCirculair2_Click(object sender, EventArgs e)
        {
            ResetWholeSelection();
            theController.ChangeSelectedRenovationConcept("circular2");
            DisableChosenButton(buttonCirculair2);
        }

        // Disables the renovationconcept button that was clicked, enables the other ones
        private void DisableChosenButton(Button chosenButton)
        {
            foreach (Button button in renovationConceptsPanel.Controls.OfType<Button>())
            {
                if (button == chosenButton)
                {
                    button.Enabled = false;
                } else
                {
                    button.Enabled = true;
                }
            }
        }

        public void SelectProductsInRenovationConcept(RenovationConcept renovationConcept)
        {
            // Gets a list of all productclickables in configuration screen
            List<ProductClickable> productClickables = configurationScreen.Controls.OfType<ProductClickable>().Cast<ProductClickable>().ToList();

            for(int i = 0; i < renovationConcept.Products.Count; i++)
            {
                Product product = renovationConcept.Products[i];

                // Select the elements in the configurationscreen that are in the products list of the active renovation concept
                if (productClickables.Any(productClickable => productClickable.Product == product))
                {
                    productClickables.First(productClickable => productClickable.Product == product).Select(false);
                }
            }
        }

        // 
        public void SetTotalOnMouseClick(Object sender, EventArgs e)
        {
            SetTotalValuesInGui();
        }

        public void SetTotalValuesInGui()
        {
            labelTotalClassic.Text = theController.GetTotalValuesInString("linear");
            labelTotalCirculair1.Text = theController.GetTotalValuesInString("circular1");
            labelTotalCirculair2.Text = theController.GetTotalValuesInString("circular2");


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.Text = "Refreshing...";
            button1.Enabled = false;
            RefreshConfigurationScreen();
            button1.Enabled = true;
            button1.Text = "Refresh";
        }

    }
}
