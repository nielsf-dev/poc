using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Element
    {
        public int Elementid { get; set; }
        public int Subelementid { get; set; }
        public int Counternr { get; set; }

        public virtual Element1 ElementNavigation { get; set; }
        public virtual Element1 Subelement { get; set; }
    }
}
