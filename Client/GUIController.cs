using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingFutureCities
{
    class GUIController
    {
        private GUI theView { get; set; }
        private DataModel theModel;



        public void SetViewAndModel(GUI view, DataModel model)
        {
            theView = view;
            theModel = model;
            theModel.GetListOfProductGroupsFromUrl("http://localhost:3000/products");
            theView.LoadProductsInToConfigurationScreen(theModel.ProductGroups);
            theModel.SetLinearProductsList();
            theView.SelectProductsInRenovationConcept(theModel.SelectedRenovationConcept);
            theView.SetTotalValuesInGui();
        }

        public void SendDataFromModelToView()
        {
            theView.LoadProductsInToConfigurationScreen(theModel.ProductGroups);
        }

        public RenovationConcept GetRenovationConceptByName(string name)
        {
            switch (name)
            {
                case "linear":
                    return theModel.Comparison.Linear;
                case "circular1":
                    return theModel.Comparison.Circular1;
                case "circular2":
                    return theModel.Comparison.Circular2;
            }
            return null;
        }

        public RenovationConcept GetSelectedRenovationConcept()
        {
            return theModel.SelectedRenovationConcept;
        }

        public void ChangeSelectedRenovationConcept(string name)
        {
            theModel.SelectedRenovationConcept = GetRenovationConceptByName(name);
            theView.SelectProductsInRenovationConcept(theModel.SelectedRenovationConcept);
        }

        public string GetTotalValuesInString(string name)
        {
            RenovationConcept renovation = GetRenovationConceptByName(name);
            return "Embodied energy: " + renovation.TotalEmbodiedEnergy + " MJ/kg" + "\r" + "Embodied CO2: " + renovation.TotalEmbodiedCO2 + " kg";
        }



    }
}
