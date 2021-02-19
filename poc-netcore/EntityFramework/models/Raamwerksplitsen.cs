using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Raamwerksplitsen
    {
        public int Id { get; set; }
        public int Raamwerkid { get; set; }
        public string Raamwerkxml { get; set; }
        public int? Splitsstatus { get; set; }
        public int? Splitsattempts { get; set; }
        public DateTime? Splitsattemptdate { get; set; }
        public string Splitserror { get; set; }
    }
}
