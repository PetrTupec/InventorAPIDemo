
using System.Text.Encodings.Web;
using System.Text.Json;

namespace InventorAPIDemoApp.Models
{
    public abstract class BaseModel
    {
        public string Name { get; protected set; }

        public abstract string ToCsv();

        public string ToJson()
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            options.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            return JsonSerializer.Serialize((object)this, options);
        }
    }
}
