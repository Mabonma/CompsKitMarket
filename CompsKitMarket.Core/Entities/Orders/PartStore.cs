using CompsKitMarket.Core.Entities.Kits;

namespace CompsKitMarket.Core.Entities.Orders
{
    public class PartStore
    {
        public int PartId { get; set; }
        public Part Part { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public double Cost { get; set; }
    }
}
