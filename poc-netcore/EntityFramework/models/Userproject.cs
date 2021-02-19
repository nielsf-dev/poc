using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Userproject
    {
        public int Userid { get; set; }
        public int Projectid { get; set; }
        public DateTime? Datecreated { get; set; }

        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
