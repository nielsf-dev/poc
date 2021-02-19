using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Messagevalue
    {
        public int Id { get; set; }
        public int Messageid { get; set; }
        public int? Elementid { get; set; }
        public int Rownumber { get; set; }
        public int Complexelementid { get; set; }
        public string Value { get; set; }
        public string Screenvalue { get; set; }
        public int? Parentcomplexelementid { get; set; }
        public string Htmlvalue { get; set; }

        public virtual Element1 Complexelement { get; set; }
        public virtual Element1 Element { get; set; }
        public virtual Message Message { get; set; }
        public virtual Element1 Parentcomplexelement { get; set; }
    }
}
