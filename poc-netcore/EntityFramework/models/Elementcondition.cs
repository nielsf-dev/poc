using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Elementcondition
    {
        public int Id { get; set; }
        public int Raamwerkid { get; set; }
        public int? Complexelementid { get; set; }
        public int? Simpleelementid { get; set; }
        public string Condition { get; set; }
        public int? Mitid { get; set; }
        public int? Complexelementid2 { get; set; }

        public virtual Element1 Complexelement { get; set; }
        public virtual Mit Mit { get; set; }
        public virtual Raamwerken Raamwerk { get; set; }
        public virtual Element1 Simpleelement { get; set; }
    }
}
