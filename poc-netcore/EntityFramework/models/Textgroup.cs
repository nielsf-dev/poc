using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Textgroup
    {
        public Guid Id { get; set; }
        public Guid Textid { get; set; }

        public virtual Text Text { get; set; }
    }
}
