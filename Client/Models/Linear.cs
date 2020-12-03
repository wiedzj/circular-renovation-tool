using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingFutureCities
{
    class Linear : RenovationConcept
    {
        // Call parent constructor (RenovationConcept)
        public Linear() : base("Lineair") // Name of Linear is always "Lineair"
        {
        }

        // Override abstract method SetProducts of RenovationConcept
        // This function adds the products with most lineair category (category 1 or 2) to the renovationconcept
        public override void SetProducts(IList<ProductGroup> productGroups)
        {
            Reset();
            for (int i = 0; i < productGroups.Count; i++)
            {
                ProductGroup productGroup = productGroups[i];
                if (productGroup.GetProductFromCategory(1) != null)
                {
                    AddProduct(productGroup.GetProductFromCategory(1));
                }
                else if (productGroup.GetProductFromCategory(2) != null)
                {
                    AddProduct(productGroup.GetProductFromCategory(2));
                }
            }
        }


        private void Reset()
        {
            Products = new List<Product>();
            TotalEmbodiedCO2 = 0;
            TotalEmbodiedEnergy = 0;
        }

        // Can't remove product from Linear, so if this method is called by accident, it throws a NotImplemtedException
        public override void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

    }
}
