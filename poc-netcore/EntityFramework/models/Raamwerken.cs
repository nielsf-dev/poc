using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Raamwerken
    {
        public Raamwerken()
        {
            Appendices = new HashSet<Appendix>();
            Element1s = new HashSet<Element1>();
            Elementconditions = new HashSet<Elementcondition>();
            Grouptypes = new HashSet<Grouptype>();
            Messagetypes = new HashSet<Messagetype>();
            Mitconditions = new HashSet<Mitcondition>();
            Mits = new HashSet<Mit>();
            Transactiontypes = new HashSet<Transactiontype>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Xmlns { get; set; }
        public int Counternr { get; set; }
        public string Xsi { get; set; }
        public string Schemalocation { get; set; }
        public string Systematiek { get; set; }
        public string Sid { get; set; }
        public bool Isbasisraamwerk { get; set; }

        public int Projectid { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Appendix> Appendices { get; set; }
        public virtual ICollection<Element1> Element1s { get; set; }
        public virtual ICollection<Elementcondition> Elementconditions { get; set; }
        public virtual ICollection<Grouptype> Grouptypes { get; set; }
        public virtual ICollection<Messagetype> Messagetypes { get; set; }
        public virtual ICollection<Mitcondition> Mitconditions { get; set; }
        public virtual ICollection<Mit> Mits { get; set; }
        public virtual ICollection<Transactiontype> Transactiontypes { get; set; }
    }
}
