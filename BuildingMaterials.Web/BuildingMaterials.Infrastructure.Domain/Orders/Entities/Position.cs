namespace BuildingMaterials.Infrastructure.Domain.Orders.Entities
{
    public class Position
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int Price { get; set; }
    }
}
