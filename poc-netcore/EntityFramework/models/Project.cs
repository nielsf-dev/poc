using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Project
    {
        public Project()
        {
            Auxfiles = new HashSet<Auxfile>();
            Favorietenmaps = new HashSet<Favorietenmap>();
            Messagefiles = new HashSet<Messagefile>();
            Metaraamwerkupdates = new HashSet<Metaraamwerkupdate>();
            Organisaties = new HashSet<Organisaty>();
            Organisatievolgnummers = new HashSet<Organisatievolgnummer>();
            Personens = new HashSet<Personen>();
            Persoonlijkemappens = new HashSet<Persoonlijkemappen>();
            Persoonrollens = new HashSet<Persoonrollen>();
            Projectsettings = new HashSet<Projectsetting>();
            Raamwerkens = new HashSet<Raamwerken>();
            Rollens = new HashSet<Rollen>();
            Rootfolders = new HashSet<Rootfolder>();
            Sessions = new HashSet<Session>();
            Transactions = new HashSet<Transaction>();
            Userprojects = new HashSet<Userproject>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Sid { get; set; }
        public string Name { get; set; }
        public bool Iscrm { get; set; }
        public string Description { get; set; }
        public string Projecttype { get; set; }
        public bool? Isdeleted { get; set; }
        public int Type { get; set; }
        public bool Subtransactionallowed { get; set; }
        public bool Isworkflowproject { get; set; }
        public int? Parentid { get; set; }
        public string Modules { get; set; }
        public string Moduleurls { get; set; }

        public virtual ICollection<Auxfile> Auxfiles { get; set; }
        public virtual ICollection<Favorietenmap> Favorietenmaps { get; set; }
        public virtual ICollection<Messagefile> Messagefiles { get; set; }
        public virtual ICollection<Metaraamwerkupdate> Metaraamwerkupdates { get; set; }
        public virtual ICollection<Organisaty> Organisaties { get; set; }
        public virtual ICollection<Organisatievolgnummer> Organisatievolgnummers { get; set; }
        public virtual ICollection<Personen> Personens { get; set; }
        public virtual ICollection<Persoonlijkemappen> Persoonlijkemappens { get; set; }
        public virtual ICollection<Persoonrollen> Persoonrollens { get; set; }
        public virtual ICollection<Projectsetting> Projectsettings { get; set; }
        public virtual ICollection<Raamwerken> Raamwerkens { get; set; }
        public virtual ICollection<Rollen> Rollens { get; set; }
        public virtual ICollection<Rootfolder> Rootfolders { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Userproject> Userprojects { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
