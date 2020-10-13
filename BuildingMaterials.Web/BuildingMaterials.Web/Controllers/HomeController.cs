using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BuildingMaterials.Web.Models;
using BuildingMaterials.UseCases.Orders.GetPositions;
using BuildingMaterials.UseCases.Orders.MakeOrder;
using BuildingMaterials.UseCases.Orders.GetOrders;

namespace BuildingMaterials.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var positions = await mediator.Send(new GetPositionsQuery());
            return View(positions);
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(MakeOrderCommand command)
        {
            await mediator.Send(command);
            return RedirectToAction(nameof(Orders));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Orders()
        {
            var orders = await mediator.Send(new GetOrdersQuery());
            return View(orders);
        }
    }
}
