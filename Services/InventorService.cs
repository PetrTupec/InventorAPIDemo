using Inventor;
using InventorAPIDemoApp.Models;

namespace InventorAPIDemoApp.Services
{
    public class InventorService
    {
        public Application InventorApp { get; private set; }

        public InventorService()
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

        public void OpenDocument(string filePath)
        {
            var allowedExtensions = new HashSet<string>()
            {
            ".ipt",
            ".iam"
            };

            if (InventorApp == null)
                throw new InvalidOperationException("Inventor must be open.");

            string fileExtension = GetDocumentExtension(filePath);
            if (!System.IO.File.Exists(filePath) || !allowedExtensions.Contains(fileExtension))
            {
                throw new ArgumentException("Invalid file path or file is not supported.");
            }

            try
            {
                InventorApp.Documents.Open(filePath, true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to open document.", ex);
            }
        }

        public string GetDocumentExtension(string filePath)
        {
            return System.IO.Path.GetExtension(filePath).ToLower();
        }

        public ModelData GetModelData()
        {
            try
            {
                var partDocument = InventorApp.ActiveDocument as PartDocument;
                var componentDefinition = partDocument.ComponentDefinition;

                double mass = componentDefinition.MassProperties.Mass;
                double volume = componentDefinition.MassProperties.Volume * 1e6;

                var designProps = partDocument.PropertySets["Design Tracking Properties"];
                var summaryProps = partDocument.PropertySets["Summary Information"];

                Box box = componentDefinition.RangeBox;
                double width = Math.Abs(box.MaxPoint.X - box.MinPoint.X) * 10;
                double height = Math.Abs(box.MaxPoint.Y - box.MinPoint.Y) * 10;
                double depth = Math.Abs(box.MaxPoint.Z - box.MinPoint.Z) * 10;

                return new ModelData
                {
                    FileName = partDocument.DisplayName,
                    Material = componentDefinition.Material.Name,
                    MassKg = Math.Round(mass, 2),
                    VolumeCm3 = Math.Round(volume, 2),
                    Width = Math.Round(width, 2),
                    Height = Math.Round(height, 2),
                    Depth = Math.Round(depth, 2),
                    Author = summaryProps["Author"].Value as string ?? "Unknown",
                    DateCreated = (DateTime)designProps["Creation Time"].Value
                };
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to get model data.", ex);
            }
        }

        public List<BomItem> GetBOM()
        {
            AssemblyDocument asmDoc = InventorApp.ActiveDocument as AssemblyDocument;
            BOM bom = asmDoc.ComponentDefinition.BOM;

            bom.StructuredViewEnabled = true;

            BOMView bomView = bom.BOMViews["Strukturované"];
            List<BomItem> bomItems = new List<BomItem>();

            foreach (BOMRow row in bomView.BOMRows)
                try
                {
                    var partName = row.ComponentOccurrences[1].Name;
                    var quantity = row.ItemQuantity;

                    bomItems.Add(new BomItem
                    {
                        PartName = partName,
                        Quantity = quantity
                    });
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException($"No component definition for BOM row {row}", ex);
                }

            return bomItems;
        }

        public void CloseInventor()
        {
            if (InventorApp != null)
            {
                InventorApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(InventorApp);
                InventorApp = null;
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
    }
}