using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Message
    {
        public Message()
        {
            ExecuteScripts = new HashSet<ExecuteScript>();
            Messagefiles = new HashSet<Messagefile>();
            Messagevalues = new HashSet<Messagevalue>();
            Oldmessagevalues = new HashSet<Oldmessagevalue>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public int Transactionid { get; set; }
        public DateTime Datumverzonden { get; set; }
        public bool Gelezen { get; set; }
        public DateTime Reactietermijn { get; set; }
        public long Tijdverzonden { get; set; }
        public string Soapid { get; set; }
        public int? Mitid { get; set; }
        public string Verzenderloginname { get; set; }
        public int? Verzenderpersoonrolid { get; set; }
        public int? Ontvangerpersoonrolid { get; set; }

        public virtual Mit Mit { get; set; }
        public virtual Persoonrollen Ontvangerpersoonrol { get; set; }
        public virtual Transaction Transaction { get; set; }
        public virtual Persoonrollen Verzenderpersoonrol { get; set; }
        public virtual ICollection<ExecuteScript> ExecuteScripts { get; set; }
        public virtual ICollection<Messagefile> Messagefiles { get; set; }
        public virtual ICollection<Messagevalue> Messagevalues { get; set; }
        public virtual ICollection<Oldmessagevalue> Oldmessagevalues { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
