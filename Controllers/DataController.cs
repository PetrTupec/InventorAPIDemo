using InventorAPIDemoApp.Models;
using InventorAPIDemoApp.Utils;

namespace InventorAPIDemoApp.Controllers
{
    internal class DataController
    {
        private FileUtils fileUtils;

        public DataController()
        {
            fileUtils = new FileUtils();
        }

        public string ExportData(IDataModel documentData, string format)
        {
            return format switch
            {
                "json" => fileUtils.SaveAsJson(documentData),
                "csv" => fileUtils.SaveAsCsv(documentData),
                _ => throw new ArgumentException("File format is not supported.")
            };
        }
    }
}
