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
    // This is a the class of the AddProductScreen, a Form where a new product can be added
    partial class EditProductScreen : Form
    {
        private ProductClickable _productClickable;
        //private GUI _gui;
        public EditProductScreen(ProductGroup productGroup, GUI gui)
        {
            InitializeComponent();
            //_productGroup = productGroup;
            //_gui = gui;
            SetValues();
        }

        public EditProductScreen(ProductClickable productClickable)
        {
            InitializeComponent();
            _productClickable = productClickable;
            SetValues();
        }

        private void SetValues()
        {
            labelProductGroupValue.Text = _productClickable.ProductGroup.Name;
            labelCategoryValue.Text = _productClickable.Product.Category.ToString();
            numericUpDownEmbodiedCO2.Value = (decimal)_productClickable.Product.EmbodiedCO2;
            numericUpDownEmbodiedEnergy.Value = (decimal) _productClickable.Product.EmbodiedEnergy;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            double embodiedCO2 = (double) numericUpDownEmbodiedCO2.Value;
            double embodiedEnergy = (double) numericUpDownEmbodiedEnergy.Value;

            //Product newProduct = new Product(embodiedEnergy, embodiedCO2, category);
            //_productClickable.ProductGroup.AddProductInCategory(newProduct);

            if (_productClickable.IsAvailable)
            {
                _productClickable.Product.EmbodiedCO2 = embodiedCO2;
                _productClickable.Product.EmbodiedEnergy = embodiedEnergy;
                _productClickable.SetProductInfo();
            } else
            {
                _productClickable.Product.EmbodiedCO2 = embodiedCO2;
                _productClickable.Product.EmbodiedEnergy = embodiedEnergy;
                _productClickable.ChangeToAvailable();
            }

            this.Dispose();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Product productToDelete =_productClickable.Product;
            GUI.comparison.Circular1.RemoveProduct(productToDelete);
            GUI.comparison.Circular2.RemoveProduct(productToDelete);
            _productClickable.ChangeToUnavailable();

            this.Dispose();
        }
    }
}