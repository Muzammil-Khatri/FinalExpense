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

        public IEnumerable<Charts> GetColumnChart()
        {

           var Points = _Context.Transfers.AsEnumerable().GroupBy(s => s.SalesRep)
               .Select(g => new Charts { X = g.Key, Y = g.Select(l => l.SalesRep).Count()});

            return Points;
            
        }

        public IEnumerable<Charts> GePieChart()
        {

            var Points = _Context.Transfers.AsEnumerable().GroupBy(s => s.Status)
                .Select(g => new Charts { X = g.Key, Y = g.Select(l => l.Status).Count() });

            return Points;

        }

        public IEnumerable<Charts> GeLineChart()
        {

            var Points = _Context.Transfers.AsEnumerable().GroupBy(s => s.Date.Date).OrderBy(s => s.Key)
                .Select(g => new Charts { X = g.Key.ToString(), Y = g.Select(l => l.Date).Count() });

            return Points;

        }
    }
}
