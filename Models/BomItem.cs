using System.Text;

namespace InventorAPIDemoApp.Models
{
    public class BomItem
    {
        public required string PartName { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"{PartName} X {Quantity}";
        }
        public static string ToFormattedString(List<BomItem> items)
        {
            if (items == null || items.Count == 0)
                return "BOM Items list is empty.";

            var sb = new StringBuilder();
            sb.AppendLine("BOM Items list:");
            
            foreach (var item in items)
            {
                sb.AppendLine($"{item}");
            }
            
            return sb.ToString();
        }
    }
}
