using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingFutureCities
{
    // Objects of this class are the panels that are added in the configuration screen
    class ProductClickable : Panel
    {
        private Label _labelEmbodiedEnergy, _labelEmbodiedCO2, _labelUnavailable;
        private Button _buttonEditProduct;
        public Product Product { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public int RowNumber { get; }
        
        // Check if Clickable is selected
        public bool IsSelected { get; set; }
        public bool IsAvailable { get; set; }

        private GUIController theController;

        public ProductClickable(Product product, int rowIndex, int columnIndex, GUIController controller)
        {
            theController = controller;

            IsSelected = false;
            Product = product;
            RowNumber = rowIndex;

            Dock = DockStyle.Fill;

            // Check if the product is avaible, if product is not null, it is available
            if (product != null)
            {
                SetAvailable();
            }
            else
            {
                // An "empty" Product is created, we just need the category, this is the index of the column it was placed in
                Product = new Product(columnIndex);
                SetUnavailable();
            }

            _buttonEditProduct = new Button();
            _buttonEditProduct.Text = "Edit";
            _buttonEditProduct.Location = new Point(20, 5);
            _buttonEditProduct.MouseUp += OnMouseUp_editButton;
            Controls.Add(_buttonEditProduct);
        }

        // Turns a productClickable into an available one
        public void SetAvailable()
        {
            IsAvailable = true;
            BackColor = System.Drawing.SystemColors.Control;

            _labelEmbodiedCO2 = new Label();
            _labelEmbodiedCO2.Location = new Point(5, 70);
            _labelEmbodiedCO2.TextAlign = ContentAlignment.MiddleCenter;
            _labelEmbodiedCO2.AutoSize = true;
            
            _labelEmbodiedEnergy = new Label();
            _labelEmbodiedEnergy.Location = new Point(5, 85);
            _labelEmbodiedEnergy.TextAlign = ContentAlignment.MiddleCenter;
            _labelEmbodiedEnergy.AutoSize = true;

            SetProductInfo();

            Controls.Add(_labelEmbodiedCO2);
            Controls.Add(_labelEmbodiedEnergy);

            MouseUp += OnMouseUpPanel;
            MouseDown += OnMouseDownPanel;
        }


        public void SetUnavailable()
        {
            IsAvailable = false;

            BackColor = System.Drawing.SystemColors.ControlDarkDark;

            _labelUnavailable = new Label();
            _labelUnavailable.Location = new Point(5, 70);
            _labelUnavailable.TextAlign = ContentAlignment.MiddleCenter;
            _labelUnavailable.AutoSize = true;
            _labelUnavailable.Text = "Niet beschikbaar";

            Controls.Add(_labelUnavailable);
        }

        public void SetProductInfo()
        {
            _labelEmbodiedCO2.Text = "Embodied CO2: " + Product.EmbodiedCO2 + " kg";
            _labelEmbodiedEnergy.Text = "Embodied Energy: " + Product.EmbodiedEnergy + "MJ/kg";
        }

        // Removes unavailable controls, then sets available
        public void ChangeToAvailable()
        {
            Controls.Remove(_labelUnavailable);
            SetAvailable();
        }

        // Removes available controls and then sets unavailable
        public void ChangeToUnavailable()
        {
            Product.EmbodiedCO2 = 0;
            Product.EmbodiedEnergy = 0;
            Controls.Remove(_labelEmbodiedEnergy);
            Controls.Remove(_labelEmbodiedCO2);

            MouseUp -= OnMouseUpPanel;
            MouseDown -= OnMouseDownPanel;

            SetUnavailable();
        }

        private void OnMouseUpPanel(object sender, EventArgs e)
        {
            RenovationConcept selected = theController.GetSelectedRenovationConcept();
           // Products can only be selected when working in a Circular renovation concept
            if (selected is Circular) 
            {
                if (!IsSelected)
                {
                    Select(true);
                }
                else
                {
                    Deselect(true);
                }
            }
            // When working in a Linear renovation concept no changes can be made, so on MouseUp, the color should return to the normal state 
            else
            {
                if (!IsSelected)
                {
                    this.BackColor = System.Drawing.SystemColors.Control;
                } else
                {
                    this.BackColor = FunctionsGUI.GetCategoryColor(Product.Category);
                }
            }
        }

        // If the parameter in a call of this method is false, the productclickable is only selected, but the product should not be added to the renovation concept
        // This is useful when the renovation concept is changed in the GUI, so the added products should be selected, but not added (because they were added before)
        public void Select(bool add)
        {
            // Set color to color of the category
            BackColor = FunctionsGUI.GetCategoryColor(Product.Category);
            IsSelected = true;
            if (add)
            {
                theController.GetSelectedRenovationConcept().AddProduct(Product);
            }
        }

        // Same as Select, but the bool in the parameter controls if the product is removed
        public void Deselect(bool remove)
        {
            // Set color to normal color
            BackColor = System.Drawing.SystemColors.Control;
            IsSelected = false;
            if (remove)
            {
                theController.GetSelectedRenovationConcept().RemoveProduct(Product);
            }
        }

        // Sets color to a lighter version of the category color on mouse down
        public void OnMouseDownPanel(object sender, EventArgs e)
        {
            BackColor = ControlPaint.LightLight(FunctionsGUI.GetCategoryColor(Product.Category));
        }

        private void OnMouseUp_editButton(object sender, EventArgs e)
        {
            EditProductScreen addProductScreen = new EditProductScreen(this);
            addProductScreen.ShowDialog();
        }
    }
}
