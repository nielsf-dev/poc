using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Mitcondition
    {
        public Mitcondition()
        {
            Mitconditionlinks = new HashSet<Mitconditionlink>();
            Mitsendafterconditions = new HashSet<Mitsendaftercondition>();
            Mitsendbeforeconditions = new HashSet<Mitsendbeforecondition>();
        }

        public int Id { get; set; }
        public string Sid { get; set; }
        public int Raamwerkid { get; set; }
        public string Helpinfo { get; set; }

        public virtual Raamwerken Raamwerk { get; set; }
        public virtual ICollection<Mitconditionlink> Mitconditionlinks { get; set; }
        public virtual ICollection<Mitsendaftercondition> Mitsendafterconditions { get; set; }
        public virtual ICollection<Mitsendbeforecondition> Mitsendbeforeconditions { get; set; }
    }
}
