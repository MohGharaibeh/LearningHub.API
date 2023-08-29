using System;
using System.Collections.Generic;

namespace LearningHub.core.Data
{
    public partial class Apistudent
    {
        public Apistudent()
        {
            Apilogins = new HashSet<Apilogin>();
            Apistdcourses = new HashSet<Apistdcourse>();
        }

        public decimal Studentid { get; set; }
        public string? Studentfirstname { get; set; }
        public string? Studentlastname { get; set; }
        public DateTime? Studentdateofbirth { get; set; }

        public virtual ICollection<Apilogin> Apilogins { get; set; }
        public virtual ICollection<Apistdcourse> Apistdcourses { get; set; }
    }
}
