using System.Text;

namespace InventorAPIDemoApp.Models
{
    public class BomItem : BaseModel
    {
        public List<BomPart> PartList { get; private set; }

        public BomItem(string name, List<BomPart> bomItems)
        {
            Name = name;
            PartList = bomItems;
        }

        public override string ToString()
        {
            if (PartList == null || PartList.Count == 0)
            {
                return $"BOM Items list of {Name}: No parts.";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"BOM Items list of {Name}: " +
                $"{(PartList == null || PartList.Count == 0 ? "No parts" : "")}");

            foreach (BomPart item in PartList)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public override string ToCsv()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("PartName;Quantity");

            foreach (BomPart item in PartList)
            {
                sb.AppendLine(item.ToCsv());
            }

            return sb.ToString();
        }
    }
}
