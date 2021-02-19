using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Organisationtype
    {
        public Organisationtype()
        {
            Organisationtypecontents = new HashSet<Organisationtypecontent>();
        }

        public int Id { get; set; }
        public string Sid { get; set; }
        public string Name { get; set; }
        public int Raamwerkid { get; set; }

        public virtual ICollection<Organisationtypecontent> Organisationtypecontents { get; set; }
    }
}
