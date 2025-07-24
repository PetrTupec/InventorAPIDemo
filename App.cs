using InventorAPIDemoApp.Controllers;
using InventorAPIDemoApp.Models;
using InventorAPIDemoApp.Services;
using InventorAPIDemoApp.UserInterface;
using Inventor;

namespace InventorAPIDemoApp
{
    internal class App
    {
        private readonly UI ui;
        private readonly InventorManager inventorManager;

        public App()
        {
            ui = new UI();
            inventorManager = new InventorManager();
        }

        public void Run()
        {
            ui.Welcome();

            try
            {
                DocumentController documentController = new DocumentController(inventorManager);
                ui.WriteInventorReady();
                
                string filePath = ui.GetFilePath();
                
                ui.WriteOpening();
                Document openDocument= documentController.LoadDocument(filePath);
                ui.WriteDocumentOpen();

                ui.WriteReadingDocument();
                BaseModel documentData = documentController.ReadDocument(openDocument);
                ui.WriteReadingDone();

                ui.WriteMessage(documentData.ToString());

                if (ui.WantUserContinue())
                {
                    string format = ui.GetPreferFormat();
                    ui.WriteExportingData(format);
                    
                    DataController DataController = new DataController();
                    string outputFilePath = DataController.ExportData(documentData, format);
                    
                    ui.WriteExportDone(outputFilePath);
                }
            }
            catch (Exception ex)
            {
                ui.WriteErrorMessage(ex.Message);
            }
            finally
            {
                ui.WriteClosingInventor();
                inventorManager.CloseInventor();
                ui.WriteInventorClose();
            }
        }
    }
}
