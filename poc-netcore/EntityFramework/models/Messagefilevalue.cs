using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Messagefilevalue
    {
        public int Id { get; set; }
        public int Messagefileid { get; set; }
        public int Simpleelementid { get; set; }
        public string Value { get; set; }
        public string Displayvalue { get; set; }

        public virtual Messagefile Messagefile { get; set; }
        public virtual Element1 Simpleelement { get; set; }
    }
}
