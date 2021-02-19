using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Raamwerkdatum
    {
        public int? Raamwerkid { get; set; }
        public string Raamwerkxsd { get; set; }
        public string Transactiontypesid { get; set; }
        public string Mitsid { get; set; }

        public virtual Raamwerken Raamwerk { get; set; }
    }
}
