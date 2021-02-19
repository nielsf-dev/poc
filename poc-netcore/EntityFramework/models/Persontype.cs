using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Persontype
    {
        public Persontype()
        {
            Persontypecontents = new HashSet<Persontypecontent>();
        }

        public int Id { get; set; }
        public string Sid { get; set; }
        public string Name { get; set; }
        public int Raamwerkid { get; set; }

        public virtual ICollection<Persontypecontent> Persontypecontents { get; set; }
    }
}
