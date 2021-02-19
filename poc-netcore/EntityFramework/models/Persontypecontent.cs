using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Persontypecontent
    {
        public int Persontypeid { get; set; }
        public int Elementid { get; set; }
        public int Counternr { get; set; }

        public virtual Element1 Element { get; set; }
        public virtual Persontype Persontype { get; set; }
    }
}
