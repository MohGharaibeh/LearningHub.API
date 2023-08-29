using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.core.DTO
{
    public class Search
    {
        public string? Studentfirstname { get; set; }
        public string? Studentlastname { get; set; }
        public string? Coursename { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public decimal? Stdcoursemarkofstd { get; set; }
    }
}
