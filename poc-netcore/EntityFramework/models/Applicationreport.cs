using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Applicationreport
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Query { get; set; }
        public bool Report { get; set; }
    }
}
