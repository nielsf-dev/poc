using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Log
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Sessionid { get; set; }
        public int Callid { get; set; }
        public string Thread { get; set; }
        public string Ip { get; set; }
    }
}
