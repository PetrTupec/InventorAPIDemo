using Inventor;
using InventorAPIDemoApp.Models;
using InventorAPIDemoApp.Services;

namespace InventorAPIDemoApp.Controllers
{
    internal class DocumentController
    {
        private InventorManager inventorManager;
        private DataExtractor dataExtractor;

        public DocumentController(InventorManager inventorManager)
        {
            this.inventorManager = inventorManager;
            dataExtractor = new DataExtractor();
        }

        public Document LoadDocument(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                throw new ArgumentException("Invalid file path.");

            return inventorManager.OpenDocument(filePath);
        }

        public BaseModel ReadDocument(Document openDocument)
        {
            if (openDocument == null)
            {
                throw new InvalidOperationException("Document must be open.");
            }

            return openDocument.DocumentType switch
            {
                DocumentTypeEnum.kPartDocumentObject => dataExtractor.GetModelData(openDocument),
                DocumentTypeEnum.kAssemblyDocumentObject => dataExtractor.GetBomItems(openDocument),
                _ => throw new NotSupportedException("Document type is not supported.")
            };
        }
    }
}
