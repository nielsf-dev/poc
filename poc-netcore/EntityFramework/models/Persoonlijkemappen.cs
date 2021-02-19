using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Persoonlijkemappen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Projectid { get; set; }
        public int? Persoonid2 { get; set; }

        public virtual Personen Persoonid2Navigation { get; set; }
        public virtual Project Project { get; set; }
    }
}
