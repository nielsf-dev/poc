using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Userrole
    {
        public int Userid { get; set; }
        public int Roleid { get; set; }
        public int? Counternr { get; set; }

        public virtual User User { get; set; }
    }
}
