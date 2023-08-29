using System;
using System.Collections.Generic;

namespace LearningHub.core.Data
{
    public partial class Apistdcourse
    {
        public decimal Stdcourseid { get; set; }
        public decimal? Stdcoursemarkofstd { get; set; }
        public DateTime? Stdcoursedateofregistration { get; set; }
        public decimal? Studentid { get; set; }
        public decimal? Courseid { get; set; }

        public virtual Apicourse? Course { get; set; }
        public virtual Apistudent? Student { get; set; }
    }
}
