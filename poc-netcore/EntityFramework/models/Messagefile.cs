using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Messagefile
    {
        public Messagefile()
        {
            Messagefilevalues = new HashSet<Messagefilevalue>();
        }

        public int Id { get; set; }
        public string Filename { get; set; }
        public int Visifileid { get; set; }
        public int Messageid { get; set; }
        public int Projectid { get; set; }
        public int Appendixid { get; set; }
        public string Sharepointurl { get; set; }
        public string Sharepointid { get; set; }
        public string Sharepointlibrary { get; set; }
        public string Thinkprojectfilehref { get; set; }
        public string Thinkprojectdocumenthref { get; set; }

        public virtual Appendix Appendix { get; set; }
        public virtual Message Message { get; set; }
        public virtual Project Project { get; set; }
        public virtual Visifile Visifile { get; set; }
        public virtual ICollection<Messagefilevalue> Messagefilevalues { get; set; }
    }
}
