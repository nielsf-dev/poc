using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Appendixcontent
    {
        public int Appendixid { get; set; }
        public int Elementid { get; set; }
        public int Counternr { get; set; }

        public virtual Appendix Appendix { get; set; }
        public virtual Element1 Element { get; set; }
    }
}
