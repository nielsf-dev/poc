using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Visifile
    {
        public Visifile()
        {
            Messagefiles = new HashSet<Messagefile>();
        }

        public int Id { get; set; }
        public string Bestandsnaam { get; set; }
        public byte[] Bestand { get; set; }
        public string Checksum { get; set; }
        public string Uniqueid { get; set; }
        public long Size { get; set; }

        public virtual ICollection<Messagefile> Messagefiles { get; set; }
    }
}
