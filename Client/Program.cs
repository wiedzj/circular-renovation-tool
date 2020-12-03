using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingFutureCities
{
    static class Program
    {
        //The main entry point for the application.//
        [STAThread]
        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GUIController controller = new GUIController();
            DataModel model = new DataModel();
            GUI gui = new GUI(controller);
            controller.SetViewAndModel(gui, model);
  
            Application.Run(gui);
        }
    }
}
   

 


    


