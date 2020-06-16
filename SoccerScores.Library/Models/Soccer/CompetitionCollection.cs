using System;
using System.Collections.Generic;
using System.Text;

namespace Scores.Library.Models.Soccer
{
    public class CompetitionCollection
    {
        public int Count { get; set; }
        public Filters Filters { get; set; }
        public Competition[] Competitions { get; set; }
    }

}
