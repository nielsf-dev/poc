using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Soapmessage
    {
        public int Id { get; set; }
        public string Uniqueid { get; set; }
        public int Direction { get; set; }
        public string Soapurlreceiver { get; set; }
        public string Soapurlsender { get; set; }
        public string Soapxml { get; set; }
    }
}
