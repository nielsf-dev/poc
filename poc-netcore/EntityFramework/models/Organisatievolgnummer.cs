using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Organisatievolgnummer
    {
        public int Id { get; set; }
        public string Organisatiesid { get; set; }
        public int Projectid { get; set; }
        public int Volgnummer { get; set; }

        public virtual Project Project { get; set; }
    }
}
