using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Projectdate
    {
        public long Id { get; set; }
        public int Projectid { get; set; }
        public DateTime Psbchanged { get; set; }
    }
}
