using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Concept
    {
        public int Id { get; set; }
        public int Persoonrolid { get; set; }
        public int? Replytomessageid { get; set; }
        public string Messagecontent { get; set; }
        public DateTime Date { get; set; }
    }
}
