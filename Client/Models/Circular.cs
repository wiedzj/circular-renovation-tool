using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingFutureCities
{
    class Circular : RenovationConcept
    {
        // Call parent constructor (RenovationConcept)
        public Circular(int number) : base("Circulair " + number) // For instance: new Circular(5), Circular.Name -> "Circulair 5"
        {
        }

        // Override abstract method RemoveProduct of 
        public override void RemoveProduct(Product product)
        {
            Products.Remove(product);
            TotalEmbodiedCO2 -= product.EmbodiedCO2;
            TotalEmbodiedEnergy -= product.EmbodiedEnergy;
        }

        public override void SetProducts(IList<ProductGroup> productGroups) 
        {
            throw new NotImplementedException();
        }

    }
}
