using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Sessioncit
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string Inlogname { get; set; }
        public string Source { get; set; }
        public string Uniqueid { get; set; }
        public DateTime? Startdate { get; set; }
    }
}
