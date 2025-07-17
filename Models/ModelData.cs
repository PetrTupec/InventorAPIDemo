using System.Text;

namespace InventorAPIDemoApp.Models
{
    public class ModelData : IDataModel
    {
        public string Name { get; set; }
        public string Material { get; set; }
        public double MassKg { get; set; }
        public double VolumeCm3 { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public string Author { get; set; }
        public DateTime DateCreated { get; set; }

        public ModelData(string name, string material, double massKg, double volumeCm3, double width, double height, double depth, string author, DateTime dateCreated)
        {
            Name = name;
            Material = material;
            MassKg = massKg;
            VolumeCm3 = volumeCm3;
            Width = width;
            Height = height;
            Depth = depth;
            Author = author;
            DateCreated = dateCreated;
        }

        public override string ToString()
        {
            return $"Metadata from file: {Name}\n" +
               $"Material: {Material}\n" +
               $"Weight: {MassKg:F2} kg\n" +
               $"Volume: {VolumeCm3:F2} cm³\n" +
               $"Width: {Width:F2} mm\n" +
               $"Height: {Height:F2} mm\n" +
               $"Depth: {Depth:F2} mm\n" +
               $"Author: {Author}\n" +
               $"Created: {DateCreated:yyyy-MM-dd}\n";
        }

        public string ToCsv()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name;Material;MassKg;VolumeCm3;Width;Height;Depth;Author;DateCreated");
            sb.AppendLine(string.Join(";",
            Name,
            Material,
            MassKg.ToString(),
            VolumeCm3.ToString(),
            Width.ToString(),
            Height.ToString(),
            Depth.ToString(),
            Author,
            DateCreated.ToString("yyyy-MM-dd")));

            return sb.ToString();
        }
    }
}
