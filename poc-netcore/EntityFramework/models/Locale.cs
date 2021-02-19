using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Locale
    {
        public Locale()
        {
            Localizedtexts = new HashSet<Localizedtext>();
            Users = new HashSet<User>();
        }

        public Guid Id { get; set; }
        public string Languagecode { get; set; }
        public string Countrycode { get; set; }
        public bool? Uses24hourclock { get; set; }

        public virtual ICollection<Localizedtext> Localizedtexts { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
