using System;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace BuildingFutureCities
{
    class DataModel
    {

        public Comparison Comparison { get; set; }
        public RenovationConcept SelectedRenovationConcept { get; set; }

        //IList is an Indexed List, so it has an index, a normal List doesn't
        public IList<ProductGroup> ProductGroups { get; set; }

        public DataModel()
        {
            Comparison = new Comparison();
            SelectedRenovationConcept = Comparison.Linear;
        }

        // Get JSON String from URL (in this case the server)
        public string GetJSONStringFromUrl(string url)
        {
            try {
                using WebClient wc = new WebClient();
                string json = wc.DownloadString(url);
                Console.WriteLine("Verbonden met de server!");
                return json;
            }
            catch (Exception e)
            {
                Console.WriteLine("Kan geen verbinding maken met de server...");
                return null;
                
            }
        }
     
        private void GetListOfProductGroupsFromJson(string json)
        {
            // Create empty list to fill with productgroups
            IList<ProductGroup> productGroups = new List<ProductGroup>();
            // Get all productgroups from Json and parse it to JArray
            JArray productGroupsJArray = JArray.Parse(json) as JArray;

            // Loop through all product groups
            for(int i = 0; i < productGroupsJArray.Count; i++)
            {
                // Parse object from JArray to JObject
                JObject productGroupAsJObject = productGroupsJArray[i] as JObject;

                // Parse JObject to ProductGroup
                ProductGroup productGroup = productGroupAsJObject.ToObject<ProductGroup>();

                // Get the products array from this product group as JArray
                JArray productsInProductGroup = productGroupAsJObject.GetValue("Products") as JArray;

                // Loop through all products 
                for (int index = 0; index < productsInProductGroup.Count; index++)
                {
                    JObject productJObject = productsInProductGroup[index] as JObject;
                    Product product = productJObject.ToObject<Product>();
                    // Add product to productgroup
                    productGroup.AddProductInCategory(product);
                }
                productGroups.Add(productGroup);
            }
            ProductGroups = productGroups;
            Comparison.Linear.SetProducts(productGroups);
        }

        // Merged method to get list from url instead from string
        public void GetListOfProductGroupsFromUrl(string url)
        {
                // Get jsonString by using method
                string jsonString = GetJSONStringFromUrl(url);
                
                // Get list of products from Json string
                GetListOfProductGroupsFromJson(jsonString);
        }

        public void SetLinearProductsList()
        {
            Comparison.Linear.SetProducts(ProductGroups);
        }

    }

}

