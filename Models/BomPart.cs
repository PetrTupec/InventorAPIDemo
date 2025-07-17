    namespace InventorAPIDemoApp.Models
    {
        public class BomPart : IDataModel
        {
            public string Name { get; set; }
            public int Quantity { get; set; }

            public BomPart(string name, int quantity)
            {
                Name = name;
                Quantity = quantity;
            }
            public override string ToString()
            {
                return $"{Name} X {Quantity}";
            }

            public string ToCsv()
            {
                return $"{Name};{Quantity}";
            }
        }
    }
