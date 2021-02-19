using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Databaseversion
    {
        public int? Version { get; set; }
        public int? Basisraamwerkversion { get; set; }
    }
}
