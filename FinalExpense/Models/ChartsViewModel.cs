﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalExpense.Models
{
    public class ChartsViewModel
    {
        public IEnumerable<Charts> ColumnChartPoints;
        public IEnumerable<Charts> PieChartPoints;
        public IEnumerable<Charts> LineChartPoints;
    }
}
