using InventorAPIDemoApp.Models;

namespace InventorAPIDemoApp.Utils
{
    public class FileUtils
    {
        private readonly string defaultOutputDirectory;

        public FileUtils()
        {
            defaultOutputDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "ExportedData");
        }

        private string CreateFullOutputPath(string extension, string outputDirectory)
        {
            outputDirectory ??= defaultOutputDirectory;

            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            DateTime currentDateTime = DateTime.Now;
            string fileName = $"item_export_{currentDateTime:yyyyMMdd_HHmmssfff}.{extension}";
            return Path.Combine(outputDirectory, fileName);
        }

        public string SaveAsJson(BaseModel data, string outputDirectory = null)
        {
            string fullOutputPath = CreateFullOutputPath("json", outputDirectory);

            File.WriteAllText(fullOutputPath, data.ToJson());

            return fullOutputPath;
        }

        public string SaveAsCsv(BaseModel data, string outputDirectory = null)
        {
            string fullOutputPath = CreateFullOutputPath("csv", outputDirectory);

            File.WriteAllText(fullOutputPath, data.ToCsv());

            return fullOutputPath;
        }
    }
}
