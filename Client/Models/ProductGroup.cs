using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingFutureCities
{
    // This class represents a group of products
    // An object of ProductGroup with name "Douche" can contain up to 5 products

    public class ProductGroup
    {
        public string Name { get; set; }

        public Product[] ProductsInGroup { get; set; }

        public ProductGroup(string productNaam)
        {
            Name = productNaam;
            // Array with 5 products, index 0 t/m 4 stands for catagory 1 t/m 5
            ProductsInGroup = new Product[5]; 
        }

        public void AddProductInCategory(Product product)
        {
            // Adds a product in the ProductGroup at the index of the right category
            // If the category is 1, the index it should be added at is 0, therefore -1
            ProductsInGroup[product.Category - 1] = product;
        }

        public Product GetProductFromCategory(int categorie)
        {
            return ProductsInGroup[categorie - 1];
        }

    }
}
