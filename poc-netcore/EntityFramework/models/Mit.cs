using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Mit
    {
        public Mit()
        {
            Elementconditions = new HashSet<Elementcondition>();
            Messages = new HashSet<Message>();
            Mitconditionlinks = new HashSet<Mitconditionlink>();
            Mitsendafterconditions = new HashSet<Mitsendaftercondition>();
            Mitsendbeforeconditions = new HashSet<Mitsendbeforecondition>();
        }

        public int Id { get; set; }
        public int Messagetypeid { get; set; }
        public int Transactiontypeid { get; set; }
        public int Raamwerkid { get; set; }
        public string Groupid { get; set; }
        public string Sid { get; set; }
        public bool Opensecondarytransactionallowed { get; set; }
        public bool? Firstmessage { get; set; }
        public int? Demophase { get; set; }
        public bool Iseditablebyeveryone { get; set; }

        public virtual Messagetype Messagetype { get; set; }
        public virtual Raamwerken Raamwerk { get; set; }
        public virtual Transactiontype Transactiontype { get; set; }
        public virtual ICollection<Elementcondition> Elementconditions { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Mitconditionlink> Mitconditionlinks { get; set; }
        public virtual ICollection<Mitsendaftercondition> Mitsendafterconditions { get; set; }
        public virtual ICollection<Mitsendbeforecondition> Mitsendbeforeconditions { get; set; }
    }
}
