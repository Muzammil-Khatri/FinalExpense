using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalExpense.Data;
using FinalExpense.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExpense.Services
{
    public class ChartService
    {
        private readonly ApplicationDbContext _Context;

        public ChartService (ApplicationDbContext context)
        {
            _Context = context;
        }

        public IEnumerable<Charts> ChartPoints()
        {

           var Points = _Context.Transfers.AsEnumerable().GroupBy(s => s.SalesRep)
               .Select(g => new Charts { X = g.Key, Y = g.Select(l => l.SalesRep).Count()});

            return Points;
            
        }
    }
}
