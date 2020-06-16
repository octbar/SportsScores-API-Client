using System;
using System.Collections.Generic;
using System.Text;

namespace Scores.Library.Models.Soccer
{
   public class CurrentSeason
    {
        public int id { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int? currentMatchday { get; set; }
        public Winner winner { get; set; }
    }
}

