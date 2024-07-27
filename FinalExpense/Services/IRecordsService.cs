using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalExpense.Models;

namespace FinalExpense.Services
{
    public interface IRecordsService
    {
        Task<Records[]> GetRecordsAsync();
        Task<bool> AddRecordsAsync(List<Records> records);
    }
}
