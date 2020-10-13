using System.ComponentModel.DataAnnotations;

namespace BuildingMaterials.Infrastructure.Domain.Orders.Entities
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }
        
        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int Count { get; set; }
    }
}
