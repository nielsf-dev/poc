using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Mitpreviou
    {
        public int? Mitid { get; set; }
        public int? Previousmitid { get; set; }

        public virtual Mit Mit { get; set; }
        public virtual Mit Previousmit { get; set; }
    }
}
