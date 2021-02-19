using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Organisaty
    {
        public Organisaty()
        {
            Persoonrollens = new HashSet<Persoonrollen>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Projectid { get; set; }
        public int Organisatieid { get; set; }
        public string Soapurl { get; set; }
        public int? Contactpersoonid { get; set; }
        public string Abbr { get; set; }
        public string Publickey { get; set; }

        public virtual Personen Contactpersoon { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Persoonrollen> Persoonrollens { get; set; }
    }
}
