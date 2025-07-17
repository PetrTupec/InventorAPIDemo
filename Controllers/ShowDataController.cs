

using InventorAPIDemoApp.Models;
using InventorAPIDemoApp.UserInterface;

namespace InventorAPIDemoApp.Controllers
{
    internal class ShowDataController
    {
        private UI ui;

        public ShowDataController(UI ui)
        {
            this.ui = ui;
        }
        public void DisplayData(IDataModel documentData) {

                ui.WriteMessage(documentData.ToString());
        }
    }
}
