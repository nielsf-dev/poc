using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Auxfile
    {
        public Auxfile()
        {
            Auxfunctions = new HashSet<Auxfunction>();
        }

        public int Id { get; set; }
        public int Projectid { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Auxfunction> Auxfunctions { get; set; }
    }
}
