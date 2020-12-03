using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingFutureCities
{
    class FunctionsGUI
    {

        // Get the name that belongs to a certain category by categorynumber
        public static string GetCategoryName(int categoryNumber)
        {
            switch (categoryNumber)
            {
                // This gets the "name" from the "category" based on "categoryNumber"//
                case 1: return "Nieuwe materialen - uit nieuwe grondstoffen";
                case 2: return "Nieuwe materialen - biobased";
                case 3: return "Secundaire materialen";
                case 4: return "Reparatie";
                case 5: return "Geen ingreep";
                default: return "Niet beschikbaar";
            }
        }

        // Get the color that belongs to a certain category by categorynumber
        public static Color GetCategoryColor(int categoryNumber)
        {
            switch (categoryNumber)
            {
                // This gets the "name" from the "category" based on "categoryNumber"//
                case 1: return Color.Red;
                case 2: return Color.Orange;
                case 3: return Color.Yellow;
                case 4: return Color.LightBlue;
                case 5: return Color.Green;
                default: return Color.Gray;
            }
        }
    }
}
