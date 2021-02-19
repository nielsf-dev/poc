using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Metaraamwerkupdate
    {
        public int Id { get; set; }
        public bool Confirmed { get; set; }
        public DateTime Ingangsdatum { get; set; }
        public string Data { get; set; }
        public int Projectid { get; set; }
        public int Type { get; set; }
        public bool Executed { get; set; }

        public virtual Project Project { get; set; }
    }
}
