using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BuildingMaterials.Web.Models;
using BuildingMaterials.UseCases.Orders.GetPositions;
using BuildingMaterials.UseCases.Orders.MakeOrder;

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
        public IActionResult Checkout(MakeOrderCommand command)
        {
            return RedirectToAction(nameof(OrderCreated));
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

        public IActionResult OrderCreated()
        {
            return View();
        }
    }
}
