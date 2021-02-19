using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Element1
    {
        public Element1()
        {
            Appendicescontent = new HashSet<Appendixcontent>();
            ElementElementNavigations = new HashSet<Element>();
            ElementSubelements = new HashSet<Element>();
            ElementconditionComplexelements = new HashSet<Elementcondition>();
            ElementconditionSimpleelements = new HashSet<Elementcondition>();
            Messagecontents = new HashSet<Messagecontent>();
            Messagefilevalues = new HashSet<Messagefilevalue>();
            MessagevalueComplexelements = new HashSet<Messagevalue>();
            MessagevalueElements = new HashSet<Messagevalue>();
            MessagevalueParentcomplexelements = new HashSet<Messagevalue>();
            OldmessagevalueComplexelements = new HashSet<Oldmessagevalue>();
            OldmessagevalueElements = new HashSet<Oldmessagevalue>();
            OldmessagevalueParentcomplexelements = new HashSet<Oldmessagevalue>();
            Organisationtypecontents = new HashSet<Organisationtypecontent>();
            Persontypecontents = new HashSet<Persontypecontent>();
        }

        public int Id { get; set; }
        public string Sid { get; set; }
        public string Name { get; set; }
        public int Raamwerkid { get; set; }
        public string Elementtype { get; set; }
        public bool Istable { get; set; }
        public string Restriction { get; set; }
        public string Basetype { get; set; }
        public string Behaviour { get; set; }
        public string Functionname { get; set; }
        public string Interface { get; set; }
        public string Help { get; set; }
        public string Defaultvalue { get; set; }
        public int? Minoccurs { get; set; }
        public int? Maxoccurs { get; set; }

        public virtual Raamwerken Raamwerk { get; set; }
        public virtual ICollection<Appendixcontent> Appendicescontent { get; set; }
        public virtual ICollection<Element> ElementElementNavigations { get; set; }
        public virtual ICollection<Element> ElementSubelements { get; set; }
        public virtual ICollection<Elementcondition> ElementconditionComplexelements { get; set; }
        public virtual ICollection<Elementcondition> ElementconditionSimpleelements { get; set; }
        public virtual ICollection<Messagecontent> Messagecontents { get; set; }
        public virtual ICollection<Messagefilevalue> Messagefilevalues { get; set; }
        public virtual ICollection<Messagevalue> MessagevalueComplexelements { get; set; }
        public virtual ICollection<Messagevalue> MessagevalueElements { get; set; }
        public virtual ICollection<Messagevalue> MessagevalueParentcomplexelements { get; set; }
        public virtual ICollection<Oldmessagevalue> OldmessagevalueComplexelements { get; set; }
        public virtual ICollection<Oldmessagevalue> OldmessagevalueElements { get; set; }
        public virtual ICollection<Oldmessagevalue> OldmessagevalueParentcomplexelements { get; set; }
        public virtual ICollection<Organisationtypecontent> Organisationtypecontents { get; set; }
        public virtual ICollection<Persontypecontent> Persontypecontents { get; set; }
    }
}
