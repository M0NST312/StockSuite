using Microsoft.AspNetCore.Mvc;
using StockSuite.Models;
using System.Diagnostics;
using StockSuite.MomoAPI;
using Microsoft.AspNetCore.Authorization;
using StockSuite.Utilities;
using Newtonsoft.Json;

namespace StockSuite.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //APIUser user = new APIUser();
            //user.MakeUser();
            //UUID newUUID = new UUID();
            //var uu = newUUID.GetUUID();
            //newUUID.GetUUID();
            //CreateUser resp = new CreateUser();
            //CreateAPIUser us = new CreateAPIUser();
            //us.CreateUser();
            //resp.MakeRequest();

            //CreateAPIToken token = new CreateAPIToken();
            //string tokenInfo = token.MakeRequest().Result;
            //if (tokenInfo != null)
            //{
            //    TokenAttributes access_token = JsonConvert.DeserializeObject<TokenAttributes>(tokenInfo);
            //}
            RequestToPay requestToPay = new RequestToPay();
            requestToPay.SendPayRequest();



            return View();
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
    }
}