using InventorAPIDemoApp.Services;
using InventorAPIDemoApp.Controllers;
using InventorAPIDemoApp.UserInterface;

namespace InventorAPIDemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ui = new UI();
            InventorService inventorManager;

            ui.Welcome();

            try
            {
                inventorManager = new InventorService();
                ui.WriteInventorReady();
            }
            catch (Exception ex)
            {
                ui.WriteErrorMessage(ex.Message);
                return;
            }

            var controller = new Controller(ui, inventorManager);

            try
            {
                controller.Run();
            }
            catch (Exception ex)
            {
                ui.WriteErrorMessage(ex.Message);
            }

            ui.WriteClosingInventor();
            inventorManager.CloseInventor();
            ui.WriteInventorClose();
        }
    }
}