using System;
using System.Collections.Generic;
using System.Text;

namespace Scores.Library.Soccer.Models
{
    public class CompetitionCollection
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public Competition[] Competitions { get; set; }
    }

}
