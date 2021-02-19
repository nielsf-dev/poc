using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Messagetypeappendix
    {
        public int Messagetypeid { get; set; }
        public int Appendixid { get; set; }

        public virtual Appendix Appendix { get; set; }
        public virtual Messagetype Messagetype { get; set; }
    }
}
