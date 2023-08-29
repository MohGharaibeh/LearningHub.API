using System;
using System.Collections.Generic;

namespace LearningHub.core.Data
{
    public partial class Apilogin
    {
        public decimal Loginid { get; set; }
        public string? Loginusername { get; set; }
        public string? Loginpassword { get; set; }
        public decimal? Roleid { get; set; }
        public decimal? Studentid { get; set; }

        public virtual Apirole? Role { get; set; }
        public virtual Apistudent? Student { get; set; }
    }
}
