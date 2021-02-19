using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class ExecuteScript
    {
        public int Id { get; set; }
        public int Messageid { get; set; }
        public string Script { get; set; }
        public int? Status { get; set; }
        public int? Attempts { get; set; }
        public DateTime? Attemptdate { get; set; }
        public string Error { get; set; }

        public virtual Message Message { get; set; }
    }
}
