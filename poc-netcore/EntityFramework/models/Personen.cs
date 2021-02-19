using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Personen
    {
        public Personen()
        {
            Favorietenmaps = new HashSet<Favorietenmap>();
            Organisaties = new HashSet<Organisaty>();
            Persoonlijkemappens = new HashSet<Persoonlijkemappen>();
            Persoonrollens = new HashSet<Persoonrollen>();
            Rootfolders = new HashSet<Rootfolder>();
            Sessions = new HashSet<Session>();
        }

        public string Id { get; set; }
        public string Naam { get; set; }
        public int Projectid { get; set; }
        public string Type { get; set; }
        public int Persoonid { get; set; }
        public int? Userid { get; set; }

        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Favorietenmap> Favorietenmaps { get; set; }
        public virtual ICollection<Organisaty> Organisaties { get; set; }
        public virtual ICollection<Persoonlijkemappen> Persoonlijkemappens { get; set; }
        public virtual ICollection<Persoonrollen> Persoonrollens { get; set; }
        public virtual ICollection<Rootfolder> Rootfolders { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
    }
}
