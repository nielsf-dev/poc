using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Projectsetting
    {
        public int Id { get; set; }
        public string Setting { get; set; }
        public string Value { get; set; }
        public string Personid { get; set; }
        public int Projectid { get; set; }

        public virtual Project Project { get; set; }
    }
}
