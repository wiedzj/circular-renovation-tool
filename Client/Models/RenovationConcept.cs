using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuildingFutureCities
{
    // This class has a list of products that were added to this renovationconcept
    // It also has a value of TotalEmbodiedCO2, which is the sum of the embodiedCO2 values, of the products that were added, same for totalEmbodiedEnergy

    // This  class is abstract, because there are two types of RenovationConcept, linear and circular
    // This is useful because you can now check if a RenovationConcept is of type Linear or Circular
    // Also Linear and Circular have methods with the same implementation (non-abstract) and method with different implementations (abstract)
    public abstract class RenovationConcept
    {
        public List<Product> Products { get; set; }

        public string Name { get; set; }
        public double TotalEmbodiedCO2 { get; set; }
        public double TotalEmbodiedEnergy { get; set; }

        public RenovationConcept(string name)
        {
            Name = name;
            Products = new List<Product>();
            TotalEmbodiedCO2 = 0;
            TotalEmbodiedEnergy = 0;
        }

        public void AddProduct(Product newProduct)
        {
            Products.Add(newProduct);
            TotalEmbodiedCO2 += newProduct.EmbodiedCO2;
            TotalEmbodiedEnergy += newProduct.EmbodiedEnergy;
        }

        public abstract void RemoveProduct(Product product);

        public abstract void SetProducts(IList<ProductGroup> productGroups);
    }
}
