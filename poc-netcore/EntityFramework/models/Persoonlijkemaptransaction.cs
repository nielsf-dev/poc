using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Persoonlijkemaptransaction
    {
        public int Persoonlijkemapid { get; set; }
        public int Transactionid { get; set; }

        public virtual Persoonlijkemappen Persoonlijkemap { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
