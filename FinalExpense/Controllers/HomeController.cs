using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinalExpense.Models;
using FinalExpense.Services;
using Microsoft.AspNetCore.Http;

namespace FinalExpense.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRecordsService _RecordService;
        private readonly ChartService _chartService;

        public HomeController(ILogger<HomeController> logger, IRecordsService RecordsService, ChartService chartService)
        {
            _logger = logger;
            _RecordService = RecordsService;
            _chartService = chartService;
        }

        
        public IActionResult Index()
        {
            ChartsViewModel dataPoints = new ChartsViewModel();

            dataPoints.DataPoints = _chartService.ChartPoints();

            return View(dataPoints);
           
        }

        public async Task<IActionResult> Records()
        {
            var records = await _RecordService.GetRecordsAsync();

            var model = new RecordsViewModel()
            {
                Transfers = records
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
