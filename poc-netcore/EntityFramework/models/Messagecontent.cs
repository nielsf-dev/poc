using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Messagecontent
    {
        public int Messagetypeid { get; set; }
        public int Elementid { get; set; }
        public int Counternr { get; set; }

        public virtual Element1 Element { get; set; }
        public virtual Messagetype Messagetype { get; set; }
    }
}
