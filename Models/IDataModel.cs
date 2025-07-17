
namespace InventorAPIDemoApp.Models
{
    public interface IDataModel
    {
        string Name { get; set; }

        string ToCsv();
    }
}
