using System;
using System.Collections.Generic;

#nullable disable

namespace EntityFramework.models
{
    public partial class User
    {
        public User()
        {
            Personens = new HashSet<Personen>();
            SessionUseridadministratorNavigations = new HashSet<Session>();
            SessionUsers = new HashSet<Session>();
            Userprojects = new HashSet<Userproject>();
        }

        public int Id { get; set; }
        public string Password { get; set; }
        public string Inlogname { get; set; }
        public string Emailadres { get; set; }
        public int Rechten { get; set; }
        public bool Allowedtologin { get; set; }
        public bool Emailnotificatie { get; set; }
        public int? Lastprojectid { get; set; }
        public Guid? Localeid { get; set; }
        public int? Reactietermijnmaildagen { get; set; }
        public int? Failedloginattempts { get; set; }
        public DateTime? Lastpasswordchanged { get; set; }
        public string Temppassword { get; set; }
        public int? Adminprojectid { get; set; }
        public string Twofactorauthtoken { get; set; }
        public DateTime? Twofactorauthtokendate { get; set; }
        public string Externalid { get; set; }
        public bool? Scimdeleted { get; set; }
        public string Twostepsauthenticatorsecret { get; set; }

        public virtual Project Lastproject { get; set; }
        public virtual Locale Locale { get; set; }
        public virtual ICollection<Personen> Personens { get; set; }
        public virtual ICollection<Session> SessionUseridadministratorNavigations { get; set; }
        public virtual ICollection<Session> SessionUsers { get; set; }
        public virtual ICollection<Userproject> Userprojects { get; set; }
    }
}
