using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Sessioncall
    {
        public int Id { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public Guid Sessionid { get; set; }
    }
}
