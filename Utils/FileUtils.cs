using InventorAPIDemoApp.Models;
using System.Text;
using System.Text.Json;

namespace InventorAPIDemoApp.Utils
{
    public class FileUtils
    {
        private readonly string defaultOutputDirectory;

        public FileUtils() {
            defaultOutputDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "ExportedData");
        }

        private string CreateFullOutputPath(string extension, string outputDirectory)
        {
            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            DateTime currentDateTime = DateTime.Now;
            string fileName = $"item_export_{currentDateTime:yyyyMMdd_HHmmssfff}.{extension}";
            return Path.Combine(outputDirectory, fileName);
        }

        public string SaveAsJson(object data, string outputDirectory = null)
        {
            outputDirectory ??= defaultOutputDirectory;

            string fullOutputPath = CreateFullOutputPath("json", outputDirectory);
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(fullOutputPath, json);
            
            return fullOutputPath;
        }

        public string SaveAsCsv(IDataModel data, string outputDirectory = null)
        {
            outputDirectory ??= defaultOutputDirectory;

            string fullOutputPath = CreateFullOutputPath("csv", outputDirectory);
            File.WriteAllText(fullOutputPath, data.ToCsv());

            return fullOutputPath;
        }
    }
}
