using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Transactionlink
    {
        public int Parenttransactionid { get; set; }
        public int Childtransactionid { get; set; }
        public int Id { get; set; }

        public virtual Transaction Childtransaction { get; set; }
        public virtual Transaction Parenttransaction { get; set; }
    }
}
