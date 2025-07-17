using Inventor;
using InventorAPIDemoApp.Models;

namespace InventorAPIDemoApp.Services
{
    internal class DataExtractor
    {
        public DataExtractor() { }

        public ModelData GetModelData(Document openDocument)
        {
            try
            {
                PartDocument partDocument = openDocument as PartDocument;
                var componentDefinition = partDocument.ComponentDefinition;

                double mass = componentDefinition.MassProperties.Mass;
                double volume = componentDefinition.MassProperties.Volume * 1e6;

                var designProps = partDocument.PropertySets["Design Tracking Properties"];
                var summaryProps = partDocument.PropertySets["Summary Information"];

                Box box = componentDefinition.RangeBox;
                double width = Math.Abs(box.MaxPoint.X - box.MinPoint.X) * 10;
                double height = Math.Abs(box.MaxPoint.Y - box.MinPoint.Y) * 10;
                double depth = Math.Abs(box.MaxPoint.Z - box.MinPoint.Z) * 10;

                return new ModelData(
                    partDocument.DisplayName,
                    componentDefinition.Material.Name,
                    Math.Round(mass, 2),
                    Math.Round(volume, 2),
                    Math.Round(width, 2),
                    Math.Round(height, 2),
                    Math.Round(depth, 2),
                    summaryProps["Author"].Value as string ?? "Unknown",
                    (DateTime)designProps["Creation Time"].Value);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to get model data.", ex);
            }
        }

        public BomItem GetBomItems(Document openDocument)
        {
            string name = "";
            List<BomPart> bomParts = new List<BomPart>();

            try
            {
                AssemblyDocument asmDoc = openDocument as AssemblyDocument;
                name = asmDoc.DisplayName;
                BOM bom = asmDoc.ComponentDefinition.BOM;

                bom.StructuredViewEnabled = true;

                BOMView bomView = bom.BOMViews["Strukturované"];

                foreach (BOMRow row in bomView.BOMRows)
                {
                    string partName = row.ComponentOccurrences[1].Name;
                    int quantity = row.ItemQuantity;

                    bomParts.Add(new BomPart(partName, quantity));
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to get BOM data.", ex);
            }

            return new BomItem(name, bomParts); ;
        }

    }
}
