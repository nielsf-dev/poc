using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Mitsendbeforecondition
    {
        public int Conditionid { get; set; }
        public int Mitid { get; set; }

        public virtual Mitcondition Condition { get; set; }
        public virtual Mit Mit { get; set; }
    }
}
