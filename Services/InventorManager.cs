using Inventor;

namespace InventorAPIDemoApp.Services
{
    public class InventorManager
    {
        private Application InventorApp { get; set; }

        public InventorManager()
        {
            RunInventor();
        }

        public void RunInventor()
        {
            try
            {
                Type inventorAppType = Type.GetTypeFromProgID("Inventor.Application");
                InventorApp = (Application)Activator.CreateInstance(inventorAppType);
                InventorApp.Visible = false;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to start Autodesk Inventor. Please make sure it is properly installed.", ex);
            }

        }

        public void CloseInventor()
        {
            if (InventorApp != null)
            {
                InventorApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(InventorApp);
                InventorApp = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        public Document OpenDocument(string filePath)
        {
            if (InventorApp == null)
                throw new InvalidOperationException("Inventor must be open.");

            try
            {
                return InventorApp.Documents.Open(filePath, false);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to open document.", ex);
            }
        }
    }
}