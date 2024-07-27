using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExpense.Models
{
    public class Records
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string SalesRep { get; set; }
        public string Status { get; set; }
    }
}
