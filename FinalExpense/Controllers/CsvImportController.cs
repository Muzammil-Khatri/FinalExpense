using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalExpense.Services;
using FinalExpense.Models;
using Microsoft.AspNetCore.Http;

namespace FinalExpense.Controllers
{
    [Route("[controller]")]
    public class CsvImportController : Controller
    {
        private readonly CsvService _csvService;
        private readonly IRecordsService _RecordService;

        
        public CsvImportController(CsvService csvService, IRecordsService RecordService)
        {
            _csvService = csvService;
            _RecordService = RecordService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile csvFile)
        {
            
            if (csvFile != null && csvFile.Length > 0)
            {
                using (var stream = csvFile.OpenReadStream())
                {
                    try
                    {
                        ViewData["Message"] = _csvService.errorMessage;
                        var recordList = _csvService.ReadCsvFile(stream).ToList();
                        await _RecordService.AddRecordsAsync(recordList);
                        
                        return View(recordList); // Return users list to the view
                    }
                    catch (ApplicationException ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        ViewData["Message"] = ex.Message;
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, $"An unexpected error occurred: {ex.Message}");
                        ViewData["Message"] = ex.InnerException.Message;
                    }
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Please select a valid CSV file.");
                ViewData["Message"] = "Please select a valid CSV file.";
            }
            return View();
        }
    }
}