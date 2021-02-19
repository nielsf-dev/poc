using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Rootfolder
    {
        public int Persoonid { get; set; }
        public int Projectid { get; set; }
        public string Treeid { get; set; }
        public string Name { get; set; }
        public bool Isleaf { get; set; }
        public int Id { get; set; }
        public string Iconcls { get; set; }

        public virtual Personen Persoon { get; set; }
        public virtual Project Project { get; set; }
    }
}
