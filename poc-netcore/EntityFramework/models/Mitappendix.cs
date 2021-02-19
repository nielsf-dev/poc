using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Mitappendix
    {
        public int? Mitid { get; set; }
        public int? Appendixid { get; set; }

        public virtual Appendix Appendix { get; set; }
        public virtual Mit Mit { get; set; }
    }
}
