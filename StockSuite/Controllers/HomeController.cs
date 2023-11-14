using Microsoft.AspNetCore.Mvc;
using StockSuite.Models;
using System.Diagnostics;
using StockSuite.MomoAPI;
using Microsoft.AspNetCore.Authorization;
using StockSuite.Utilities;
using Newtonsoft.Json;
using StockSuite.SSContext;
using Microsoft.EntityFrameworkCore;

namespace StockSuite.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SSDBContext _context;

        public HomeController(ILogger<HomeController> logger, SSDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var user = _context.UserDetails.Include(a => a.Transactions.ToList()).AsQueryable(); 
            var trans = _context.Transactions.OrderByDescending(a => a.CreatedDate).ToList();
            float subs = 0;
            float Savings = 0;
            float loan = 0;
            foreach(var transaction in trans)
            {
                if (transaction.Reference == "Subscription")
                {
                    subs = subs + transaction.Amount;
                }
                else if (transaction.Reference == "Savings")
                {
                    Savings = Savings + transaction.Amount;
                }
                else if(transaction.Reference =="Quick Loan")
                {
                    loan = loan + transaction.Amount;
                }
                
            }
            ViewData["Subs"] = subs;
            ViewData["Savings"] = Savings;
            ViewData["Loan"] = loan;
            ViewData["Quick"] = 1000 - loan;
            ViewBag.Transactions = trans;
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
            //RequestToPay requestToPay = new RequestToPay();
            //var status =  requestToPay.SendPayRequest("Subscriotion");
            //Disbursement disburse = new Disbursement();
            //var status = disburse.DisbursementRequest();


            return View(user);
        }
        public async Task<IActionResult> Dashboard()
        {
            return View();
        }
        public async Task<IActionResult> Proposals()
        {
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