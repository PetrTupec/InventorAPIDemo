using InventorAPIDemoApp.Models;
using InventorAPIDemoApp.Services;
using InventorAPIDemoApp.UserInterface;

namespace InventorAPIDemoApp.Controllers
{
    internal class Controller
    {
        private UI ui;
        private InventorService inventorManager;

        public Controller(UI ui, InventorService inventorManager)
        {
            this.ui = ui;
            this.inventorManager = inventorManager;
        }

        public void Run()
        {

            string filePath = ui.GetFilePath();
            string extention = inventorManager.GetDocumentExtension(filePath);
            
            ui.WriteOpening();

            inventorManager.OpenDocument(filePath);

            ui.WriteDocumentOpen();

            switch (extention)
            {
                case ".ipt":
                    ui.WriteReadDocument();
                    var modelData = inventorManager.GetModelData();
                    ui.WriteReadingDone();
                    ui.WriteMessage(modelData.ToString());
                    break;
                case ".iam":
                    ui.WriteReadDocument();
                    var bomItems = inventorManager.GetBOM();
                    ui.WriteReadingDone();
                    ui.WriteMessage(BomItem.ToFormattedString(bomItems));
                    break;
            }
        }
    }
}
