using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Transactiontypeappendix
    {
        public int Transactiontypeid { get; set; }
        public int Appendixid { get; set; }

        public virtual Appendix Appendix { get; set; }
        public virtual Transactiontype Transactiontype { get; set; }
    }
}
