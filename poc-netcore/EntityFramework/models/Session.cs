using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class Session
    {
        public Guid Gid { get; set; }
        public int Userid { get; set; }
        public int? Projectid { get; set; }
        public int? Persoonid { get; set; }
        public string Ip { get; set; }
        public DateTime Start { get; set; }
        public long Duration { get; set; }
        public string Hostname { get; set; }
        public string Useragent { get; set; }
        public string Filereadyfordownload { get; set; }
        public Guid? Token { get; set; }
        public int? Useridadministrator { get; set; }

        public virtual Personen Persoon { get; set; }
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
        public virtual User UseridadministratorNavigation { get; set; }
    }
}
