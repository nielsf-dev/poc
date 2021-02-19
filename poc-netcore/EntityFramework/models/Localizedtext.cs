using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Localizedtext
    {
        public Guid Id { get; set; }
        public Guid Localeid { get; set; }
        public string Value { get; set; }

        public virtual Text IdNavigation { get; set; }
        public virtual Locale Locale { get; set; }
    }
}
