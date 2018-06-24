using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCalculator.Api.Client;
using WebCalculator.Api.Client.Model;
using WebCalculator.Models;

namespace WebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebCalculatorClient client;

        public HomeController(WebCalculatorClient client)
        {
            this.client = client;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new CalculateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(string expression)
        {
            CalculationResult calculationResult = await client.GetCalculationAsync(expression);

            return View("Index", new CalculateViewModel() { Result = calculationResult.Result, Calculated = true, Expression = expression });
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
