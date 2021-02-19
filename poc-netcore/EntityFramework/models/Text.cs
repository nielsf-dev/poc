using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Text
    {
        public Text()
        {
            Localizedtexts = new HashSet<Localizedtext>();
            Textgroups = new HashSet<Textgroup>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? Datecreated { get; set; }

        public virtual ICollection<Localizedtext> Localizedtexts { get; set; }
        public virtual ICollection<Textgroup> Textgroups { get; set; }
    }
}
