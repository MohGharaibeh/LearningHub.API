using System;
using System.Collections.Generic;

namespace LearningHub.core.Data
{
    public partial class Apicourse
    {
        public Apicourse()
        {
            Apistdcourses = new HashSet<Apistdcourse>();
        }

        public decimal Courseid { get; set; }
        public string? Coursename { get; set; }
        public string? Courseimagepath { get; set; }
        public decimal? Categoryid { get; set; }

        public virtual Apicategory? Category { get; set; }
        public virtual ICollection<Apistdcourse> Apistdcourses { get; set; }
    }
}
