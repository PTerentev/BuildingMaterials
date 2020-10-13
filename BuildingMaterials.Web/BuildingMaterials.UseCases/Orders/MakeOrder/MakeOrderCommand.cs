using MediatR;
using System.Collections.Generic;

namespace BuildingMaterials.UseCases.Orders.MakeOrder
{
    public class MakeOrderCommand : IRequest
    {
        public string MobileNumber { get; set; }

        public string Adress { get; set; }

        public IDictionary<int, int> Carts { get; set; }

        public string Information { get; set; }

        public string CustomerName { get; set; }
    }
}
