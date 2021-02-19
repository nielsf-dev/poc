using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Succeeded
    {
        public int Persoonrolid { get; set; }
        public int Succeededpersoonrolid { get; set; }

        public virtual Persoonrollen Persoonrol { get; set; }
        public virtual Persoonrollen Succeededpersoonrol { get; set; }
    }
}
