using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Auxfunction
    {
        public int Id { get; set; }
        public string Functiontype { get; set; }
        public string Functionxml { get; set; }
        public string Raamwerkelementsid { get; set; }
        public int Raamwerkelementtype { get; set; }
        public int Auxfileid { get; set; }
        public int Functiongroup { get; set; }

        public virtual Auxfile Auxfile { get; set; }
    }
}
