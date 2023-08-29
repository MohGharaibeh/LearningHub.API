using System;
using System.Collections.Generic;

namespace LearningHub.core.Data
{
    public partial class Apicategory
    {
        public Apicategory()
        {
            Apicourses = new HashSet<Apicourse>();
        }

        public decimal Categoryid { get; set; }
        public string? Categoryname { get; set; }

        public virtual ICollection<Apicourse> Apicourses { get; set; }
    }
}
