namespace InventorAPIDemoApp.Models
{
    public class BomPart : BaseModel
    {
        public int Quantity { get; private set; }

        public BomPart(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
        public override string ToString()
        {
            return $"{Name} X {Quantity}";
        }

        public override string ToCsv()
        {
            return $"{Name};{Quantity}";
        }
    }
}
