using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalExpense.Models;
using FinalExpense.Data;
using Microsoft.EntityFrameworkCore;

namespace FinalExpense.Services
{
    public class RecordsService : IRecordsService
    {
        private readonly ApplicationDbContext _Context;
        public RecordsService(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public async Task<Records[]> GetRecordsAsync()
        {
            return await _Context.Transfers.ToArrayAsync();
        }

        public async Task<bool> AddRecordsAsync(List<Records> records)
        {
            foreach (var record in records)
            {
                await _Context.AddAsync(record);

            }
            await _Context.SaveChangesAsync();
            
            return true;
        }

        
    }
}
