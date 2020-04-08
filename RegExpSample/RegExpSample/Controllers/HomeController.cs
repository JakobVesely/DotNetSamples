using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegExpSample.Models;

namespace RegExpSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var Output = new List<string>();

            string input = "<!@1234> <!@5678> 0 - 2";
            
            // Matching 1
            string pattern1 = "<!\\@\\d+>";
            MatchCollection matches1 = Regex.Matches (input, pattern1);

            Output.Add($"matches1 Count: {matches1.Count}");

            foreach(Match match in matches1)
            {
                Output.Add($"match.Value: {match.Value}");
                Output.Add($"match.Groups.Count: {match.Groups.Count}");
            }
            // Matching 2
            string pattern2 = "\\d+";
            MatchCollection matches2 = Regex.Matches (input, pattern2);

            Output.Add($"matches1 Count: {matches2.Count}");

            foreach(Match match in matches2)
            {
                Output.Add($"match.Value: {match.Value}");
                Output.Add($"match.Groups.Count: {match.Groups.Count}");
            }
            
            return View(Output);
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
