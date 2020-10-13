using System.Collections.Generic;

namespace BuildingMaterials.Infrastructure.Domain.Orders.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int ManagerId { get; set; }

        public bool IsAccepted { get; set; }

        public bool IsRejected { get; set; }

        public string Information { get; set; }

        public string MobileNumber { get; set; }

        public string Adress { get; set; }

        public string CustomerName { get; set; }

        public ICollection<Cart> Carts { get; set; }
    }
}
