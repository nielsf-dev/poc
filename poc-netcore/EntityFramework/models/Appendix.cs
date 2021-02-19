using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Appendix
    {
        public Appendix()
        {
            Appendicescontent = new HashSet<Appendixcontent>();
            Messagefiles = new HashSet<Messagefile>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Sid { get; set; }
        public int Raamwerkid { get; set; }

        public virtual Raamwerken Raamwerk { get; set; }
        public virtual ICollection<Appendixcontent> Appendicescontent { get; set; }
        public virtual ICollection<Messagefile> Messagefiles { get; set; }
    }
}
