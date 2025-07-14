namespace InventorAPIDemoApp.Models
{
    public class ModelData
    {
        public required string FileName { get; set; }
        public required string Material { get; set; }
        public double MassKg { get; set; }
        public double VolumeCm3 { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public required string Author { get; set; }
        public DateTime DateCreated { get; set; }

        public override string ToString()
        {
            return $"Metadata from file: {FileName}\n" +
               $"Material: {Material}\n" +
               $"Weight: {MassKg:F2} kg\n" +
               $"Volume: {VolumeCm3:F2} cm³\n" +
               $"Width: {Width:F2} mm\n" +
               $"Height: {Height:F2} mm\n" +
               $"Depth: {Depth:F2} mm\n" +
               $"Author: {Author}\n" +
               $"Created: {DateCreated:dd-MM-yyyy}\n";
        }
    }
}
