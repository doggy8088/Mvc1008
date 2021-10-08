using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mvc1008.Models;
using System.Diagnostics;

namespace Mvc1008.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HelloWorldService hw;

        public HomeController(ILogger<HomeController> logger, HelloWorldService hw)
        {
            this.hw = hw;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //throw new Exception("ERROR");

            // using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            // var client = new Greeter.GreeterClient(channel);
            // var reply = await client.SayHelloAsync(
            //                   new HelloRequest { Name = "Will" });

            hw.Name = "Alex";

            string result = hw.SayHello();

            // ViewData["Reply"] = result;
            // _logger.LogWarning(result);

            return Content(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
