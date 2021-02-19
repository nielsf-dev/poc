using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Rollen
    {
        public Rollen()
        {
            Persoonrollens = new HashSet<Persoonrollen>();
        }

        public string Sid { get; set; }
        public string Roletype { get; set; }
        public string Naam { get; set; }
        public int Projectid { get; set; }
        public int Rolid { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<Persoonrollen> Persoonrollens { get; set; }
    }
}
