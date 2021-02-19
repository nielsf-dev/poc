using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Persoonrollen
    {
        public Persoonrollen()
        {
            InverseGemachtigdnamenspersoonrol = new HashSet<Persoonrollen>();
            InverseSuccessorpersoonrol = new HashSet<Persoonrollen>();
            MessageOntvangerpersoonrols = new HashSet<Message>();
            MessageVerzenderpersoonrols = new HashSet<Message>();
            TransactionExecutorpersoonrols = new HashSet<Transaction>();
            TransactionInitiatorpersoonrols = new HashSet<Transaction>();
            TransactionLaatsteontvangerpersoonrols = new HashSet<Transaction>();
            TransactionLaatsteverzenderpersoonrols = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public int? Gemachtigdnamenspersoonrolid { get; set; }
        public int? Persoonid2 { get; set; }
        public int? Rolid2 { get; set; }
        public int? Organisatieid2 { get; set; }
        public string Sid { get; set; }
        public int? Successorpersoonrolid { get; set; }
        public int Projectid { get; set; }
        public bool? Isactive { get; set; }
        public bool Islocked { get; set; }

        public virtual Persoonrollen Gemachtigdnamenspersoonrol { get; set; }
        public virtual Organisaty Organisatieid2Navigation { get; set; }
        public virtual Personen Persoonid2Navigation { get; set; }
        public virtual Project Project { get; set; }
        public virtual Rollen Rolid2Navigation { get; set; }
        public virtual Persoonrollen Successorpersoonrol { get; set; }
        public virtual ICollection<Persoonrollen> InverseGemachtigdnamenspersoonrol { get; set; }
        public virtual ICollection<Persoonrollen> InverseSuccessorpersoonrol { get; set; }
        public virtual ICollection<Message> MessageOntvangerpersoonrols { get; set; }
        public virtual ICollection<Message> MessageVerzenderpersoonrols { get; set; }
        public virtual ICollection<Transaction> TransactionExecutorpersoonrols { get; set; }
        public virtual ICollection<Transaction> TransactionInitiatorpersoonrols { get; set; }
        public virtual ICollection<Transaction> TransactionLaatsteontvangerpersoonrols { get; set; }
        public virtual ICollection<Transaction> TransactionLaatsteverzenderpersoonrols { get; set; }
    }
}
