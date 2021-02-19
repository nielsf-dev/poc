using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Messagetype
    {
        public Messagetype()
        {
            Messagecontents = new HashSet<Messagecontent>();
            Mits = new HashSet<Mit>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Sid { get; set; }
        public int Raamwerkid { get; set; }
        public string Helpinfo { get; set; }
        public bool Appendixmandatory { get; set; }

        public virtual Raamwerken Raamwerk { get; set; }
        public virtual ICollection<Messagecontent> Messagecontents { get; set; }
        public virtual ICollection<Mit> Mits { get; set; }
    }
}
