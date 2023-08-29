using System;
using System.Collections.Generic;

namespace LearningHub.core.Data
{
    public partial class Apirole
    {
        public Apirole()
        {
            Apilogins = new HashSet<Apilogin>();
        }

        public decimal Roleid { get; set; }
        public string? Rolename { get; set; }

        public virtual ICollection<Apilogin> Apilogins { get; set; }
    }
}
