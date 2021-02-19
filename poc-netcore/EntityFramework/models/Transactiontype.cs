using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Transactiontype
    {
        public Transactiontype()
        {
            Mits = new HashSet<Mit>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public int Raamwerkid { get; set; }
        public string Sid { get; set; }
        public string Name { get; set; }
        public string Executorroletype { get; set; }
        public string Initiatorroletype { get; set; }
        public bool Passive { get; set; }
        public bool Iscrm { get; set; }
        public string Helpinfo { get; set; }

        public virtual Raamwerken Raamwerk { get; set; }
        public virtual ICollection<Mit> Mits { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
