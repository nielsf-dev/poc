using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EntityFramework.models
{
    public partial class flywayDev45aContext : DbContext
    {
        public flywayDev45aContext()
        {
        }

        public flywayDev45aContext(DbContextOptions<flywayDev45aContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appendix> Appendiceses { get; set; }
        public virtual DbSet<Appendixcontent> Appendicescontent { get; set; }
        public virtual DbSet<Applicationreport> Applicationreports { get; set; }
        public virtual DbSet<Auxfile> Auxfiles { get; set; }
        public virtual DbSet<Auxfunction> Auxfunctions { get; set; }
        public virtual DbSet<Concept> Concepts { get; set; }
        public virtual DbSet<Databaseversion> Databaseversions { get; set; }
        public virtual DbSet<Element> Elements { get; set; }
        public virtual DbSet<Element1> Elements1 { get; set; }
        public virtual DbSet<Elementcondition> Elementconditions { get; set; }
        public virtual DbSet<ExecuteScript> ExecuteScripts { get; set; }
        public virtual DbSet<Favorietenmap> Favorietenmaps { get; set; }
        public virtual DbSet<FlywaySchemaHistory> FlywaySchemaHistories { get; set; }
        public virtual DbSet<Grouptype> Grouptypes { get; set; }
        public virtual DbSet<Locale> Locales { get; set; }
        public virtual DbSet<Localizedtext> Localizedtexts { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Lucenesearchresult> Lucenesearchresults { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Messagecontent> Messagecontents { get; set; }
        public virtual DbSet<Messagefile> Messagefiles { get; set; }
        public virtual DbSet<Messagefilevalue> Messagefilevalues { get; set; }
        public virtual DbSet<Messagetype> Messagetypes { get; set; }
        public virtual DbSet<Messagetypeappendix> Messagetypeappendices { get; set; }
        public virtual DbSet<Messagevalue> Messagevalues { get; set; }
        public virtual DbSet<Metaraamwerkupdate> Metaraamwerkupdates { get; set; }
        public virtual DbSet<Mit> Mits { get; set; }
        public virtual DbSet<Mitappendix> Mitappendices { get; set; }
        public virtual DbSet<Mitcondition> Mitconditions { get; set; }
        public virtual DbSet<Mitconditionlink> Mitconditionlinks { get; set; }
        public virtual DbSet<Mitpreviou> Mitprevious { get; set; }
        public virtual DbSet<Mitsendaftercondition> Mitsendafterconditions { get; set; }
        public virtual DbSet<Mitsendbeforecondition> Mitsendbeforeconditions { get; set; }
        public virtual DbSet<Oldmessagevalue> Oldmessagevalues { get; set; }
        public virtual DbSet<Organisatievolgnummer> Organisatievolgnummers { get; set; }
        public virtual DbSet<Organisationtype> Organisationtypes { get; set; }
        public virtual DbSet<Organisationtypecontent> Organisationtypecontents { get; set; }
        public virtual DbSet<Organisaty> Organisaties { get; set; }
        public virtual DbSet<Personen> Personens { get; set; }
        public virtual DbSet<Persontype> Persontypes { get; set; }
        public virtual DbSet<Persontypecontent> Persontypecontents { get; set; }
        public virtual DbSet<Persoonlijkemappen> Persoonlijkemappens { get; set; }
        public virtual DbSet<Persoonlijkemaptransaction> Persoonlijkemaptransactions { get; set; }
        public virtual DbSet<Persoonrollen> Persoonrollens { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Projectdate> Projectdates { get; set; }
        public virtual DbSet<Projectsetting> Projectsettings { get; set; }
        public virtual DbSet<Raamwerkdatum> Raamwerkdata { get; set; }
        public virtual DbSet<Raamwerken> Raamwerkens { get; set; }
        public virtual DbSet<Raamwerksplitsen> Raamwerksplitsens { get; set; }
        public virtual DbSet<Roletype> Roletypes { get; set; }
        public virtual DbSet<Rollen> Rollens { get; set; }
        public virtual DbSet<Rootfolder> Rootfolders { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Sessioncall> Sessioncalls { get; set; }
        public virtual DbSet<Sessioncit> Sessioncits { get; set; }
        public virtual DbSet<Sessioncitlog> Sessioncitlogs { get; set; }
        public virtual DbSet<Soapmessage> Soapmessages { get; set; }
        public virtual DbSet<Succeeded> Succeededs { get; set; }
        public virtual DbSet<Text> Texts { get; set; }
        public virtual DbSet<Textgroup> Textgroups { get; set; }
        public virtual DbSet<Textversion> Textversions { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Transactionlink> Transactionlinks { get; set; }
        public virtual DbSet<Transactiontype> Transactiontypes { get; set; }
        public virtual DbSet<Transactiontypeappendix> Transactiontypeappendices { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Userproject> Userprojects { get; set; }
        public virtual DbSet<Userrole> Userroles { get; set; }
        public virtual DbSet<Visifile> Visifiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("user id=postgres;Password=toor;server=192.168.63.81;database=flywayDev45a;port=5432");
            }

            optionsBuilder
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "C");

            modelBuilder.Entity<Appendix>(entity =>
            {
                entity.ToTable("appendixes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('appendixes_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sid");

                entity.HasOne(d => d.Raamwerk)
                    .WithMany(p => p.Appendices)
                    .HasForeignKey(d => d.Raamwerkid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkd54fdff17a721450");
            });

            modelBuilder.Entity<Appendixcontent>(entity =>
            {
                entity.HasKey(e => new { e.Appendixid, e.Counternr })
                    .HasName("pk__appendix__eba033ef68487dd7");

                entity.ToTable("appendixcontent");

                entity.Property(e => e.Appendixid).HasColumnName("appendixid");

                entity.Property(e => e.Counternr).HasColumnName("counternr");

                entity.Property(e => e.Elementid).HasColumnName("elementid");

                entity.HasOne(d => d.Appendix)
                    .WithMany(p => p.Appendicescontent)
                    .HasForeignKey(d => d.Appendixid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fke8596c90acbb7d96");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Appendicescontent)
                    .HasForeignKey(d => d.Elementid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fke8596c9063e4a7a2");
            });

            modelBuilder.Entity<Applicationreport>(entity =>
            {
                entity.ToTable("applicationreports");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('applicationreports_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .HasColumnName("query");

                entity.Property(e => e.Report).HasColumnName("report");
            });

            modelBuilder.Entity<Auxfile>(entity =>
            {
                entity.ToTable("auxfiles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('auxfiles_seq'::regclass)");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Auxfiles)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_auxfiles_projects");
            });

            modelBuilder.Entity<Auxfunction>(entity =>
            {
                entity.ToTable("auxfunctions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('auxfunctions_seq'::regclass)");

                entity.Property(e => e.Auxfileid).HasColumnName("auxfileid");

                entity.Property(e => e.Functiongroup).HasColumnName("functiongroup");

                entity.Property(e => e.Functiontype)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("functiontype");

                entity.Property(e => e.Functionxml)
                    .IsRequired()
                    .HasColumnName("functionxml");

                entity.Property(e => e.Raamwerkelementsid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("raamwerkelementsid");

                entity.Property(e => e.Raamwerkelementtype).HasColumnName("raamwerkelementtype");

                entity.HasOne(d => d.Auxfile)
                    .WithMany(p => p.Auxfunctions)
                    .HasForeignKey(d => d.Auxfileid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_auxfunctions_auxfiles");
            });

            modelBuilder.Entity<Concept>(entity =>
            {
                entity.ToTable("concepts");

                entity.HasIndex(e => e.Persoonrolid, "ix_persoonrolid");

                entity.HasIndex(e => e.Replytomessageid, "ix_replytomessageid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('concepts_seq'::regclass)");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Messagecontent)
                    .IsRequired()
                    .HasColumnName("messagecontent");

                entity.Property(e => e.Persoonrolid).HasColumnName("persoonrolid");

                entity.Property(e => e.Replytomessageid).HasColumnName("replytomessageid");
            });

            modelBuilder.Entity<Databaseversion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("databaseversion");

                entity.Property(e => e.Basisraamwerkversion)
                    .HasColumnName("basisraamwerkversion")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Element>(entity =>
            {
                entity.HasKey(e => new { e.Elementid, e.Counternr })
                    .HasName("pk__elements__0b3808316d0d32f4");

                entity.ToTable("elements");

                entity.Property(e => e.Elementid).HasColumnName("elementid");

                entity.Property(e => e.Counternr).HasColumnName("counternr");

                entity.Property(e => e.Subelementid).HasColumnName("subelementid");

                entity.HasOne(d => d.ElementNavigation)
                    .WithMany(p => p.ElementElementNavigations)
                    .HasForeignKey(d => d.Elementid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkb07ae8a963e4a7a2");

                entity.HasOne(d => d.Subelement)
                    .WithMany(p => p.ElementSubelements)
                    .HasForeignKey(d => d.Subelementid)
                    .HasConstraintName("fk_element_elements");
            });

            modelBuilder.Entity<Element1>(entity =>
            {
                entity.ToTable("element");

                entity.HasIndex(e => e.Sid, "messagesid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('element_seq'::regclass)");

                entity.Property(e => e.Basetype)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("basetype");

                entity.Property(e => e.Behaviour)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("behaviour");

                entity.Property(e => e.Defaultvalue)
                    .HasMaxLength(255)
                    .HasColumnName("defaultvalue");

                entity.Property(e => e.Elementtype)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("elementtype");

                entity.Property(e => e.Functionname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("functionname");

                entity.Property(e => e.Help)
                    .IsRequired()
                    .HasColumnName("help");

                entity.Property(e => e.Interface)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("interface");

                entity.Property(e => e.Istable).HasColumnName("istable");

                entity.Property(e => e.Maxoccurs).HasColumnName("maxoccurs");

                entity.Property(e => e.Minoccurs).HasColumnName("minoccurs");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Restriction)
                    .IsRequired()
                    .HasColumnName("restriction");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sid");

                entity.HasOne(d => d.Raamwerk)
                    .WithMany(p => p.Element1s)
                    .HasForeignKey(d => d.Raamwerkid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_element_raamwerken2");
            });

            modelBuilder.Entity<Elementcondition>(entity =>
            {
                entity.ToTable("elementconditions");

                entity.HasIndex(e => new { e.Raamwerkid, e.Mitid }, "raamwerkidmitid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('elementconditions_seq'::regclass)");

                entity.Property(e => e.Complexelementid).HasColumnName("complexelementid");

                entity.Property(e => e.Complexelementid2).HasColumnName("complexelementid2");

                entity.Property(e => e.Condition)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("condition");

                entity.Property(e => e.Mitid).HasColumnName("mitid");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Simpleelementid).HasColumnName("simpleelementid");

                entity.HasOne(d => d.Complexelement)
                    .WithMany(p => p.ElementconditionComplexelements)
                    .HasForeignKey(d => d.Complexelementid)
                    .HasConstraintName("fk4d44189b8084f7b");

                entity.HasOne(d => d.Mit)
                    .WithMany(p => p.Elementconditions)
                    .HasForeignKey(d => d.Mitid)
                    .HasConstraintName("fk_elementcondition_mit");

                entity.HasOne(d => d.Raamwerk)
                    .WithMany(p => p.Elementconditions)
                    .HasForeignKey(d => d.Raamwerkid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk4d44189b640a1043");

                entity.HasOne(d => d.Simpleelement)
                    .WithMany(p => p.ElementconditionSimpleelements)
                    .HasForeignKey(d => d.Simpleelementid)
                    .HasConstraintName("fk4d44189b29bd54e8");
            });

            modelBuilder.Entity<ExecuteScript>(entity =>
            {
                entity.ToTable("execute_script");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('executescript_seq'::regclass)");

                entity.Property(e => e.Attemptdate).HasColumnName("attemptdate");

                entity.Property(e => e.Attempts).HasColumnName("attempts");

                entity.Property(e => e.Error).HasColumnName("error");

                entity.Property(e => e.Messageid).HasColumnName("messageid");

                entity.Property(e => e.Script)
                    .IsRequired()
                    .HasColumnName("script");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.ExecuteScripts)
                    .HasForeignKey(d => d.Messageid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_messages");
            });

            modelBuilder.Entity<Favorietenmap>(entity =>
            {
                entity.ToTable("favorietenmap");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('favorietenmap_seq'::regclass)");

                entity.Property(e => e.Iconcls)
                    .HasMaxLength(1000)
                    .HasColumnName("iconcls");

                entity.Property(e => e.Isleaf).HasColumnName("isleaf");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Persoonid).HasColumnName("persoonid");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Treeid)
                    .IsRequired()
                    .HasColumnName("treeid");

                entity.HasOne(d => d.Persoon)
                    .WithMany(p => p.Favorietenmaps)
                    .HasForeignKey(d => d.Persoonid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_favorietenmap_persoon");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Favorietenmaps)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_favorietenmap_project");
            });

            modelBuilder.Entity<FlywaySchemaHistory>(entity =>
            {
                entity.HasKey(e => e.InstalledRank)
                    .HasName("flyway_schema_history_pk");

                entity.ToTable("flyway_schema_history");

                entity.HasIndex(e => e.Success, "flyway_schema_history_s_idx");

                entity.Property(e => e.InstalledRank)
                    .ValueGeneratedNever()
                    .HasColumnName("installed_rank");

                entity.Property(e => e.Checksum).HasColumnName("checksum");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("description");

                entity.Property(e => e.ExecutionTime).HasColumnName("execution_time");

                entity.Property(e => e.InstalledBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("installed_by");

                entity.Property(e => e.InstalledOn)
                    .HasColumnName("installed_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Script)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("script");

                entity.Property(e => e.Success).HasColumnName("success");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("type");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .HasColumnName("version");
            });

            modelBuilder.Entity<Grouptype>(entity =>
            {
                entity.ToTable("grouptypes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('grouptypes_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasColumnName("sid");

                entity.HasOne(d => d.Raamwerk)
                    .WithMany(p => p.Grouptypes)
                    .HasForeignKey(d => d.Raamwerkid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_grouptypes_raamwerken");
            });

            modelBuilder.Entity<Locale>(entity =>
            {
                entity.ToTable("locales");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid");

                entity.Property(e => e.Countrycode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("countrycode")
                    .IsFixedLength(true);

                entity.Property(e => e.Languagecode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("languagecode")
                    .IsFixedLength(true);

                entity.Property(e => e.Uses24hourclock).HasColumnName("uses24hourclock");
            });

            modelBuilder.Entity<Localizedtext>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Localeid })
                    .HasName("pk_localizedtexts");

                entity.ToTable("localizedtexts");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid");

                entity.Property(e => e.Localeid).HasColumnName("localeid");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(4000)
                    .HasColumnName("value");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Localizedtexts)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_localizedtexts_texts");

                entity.HasOne(d => d.Locale)
                    .WithMany(p => p.Localizedtexts)
                    .HasForeignKey(d => d.Localeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_localizedtexts_locales");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('log_seq'::regclass)");

                entity.Property(e => e.Callid).HasColumnName("callid");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Exception)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("exception");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ip");

                entity.Property(e => e.Level)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("level");

                entity.Property(e => e.Logger)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("logger");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("message");

                entity.Property(e => e.Sessionid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sessionid");

                entity.Property(e => e.Thread)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("thread");
            });

            modelBuilder.Entity<Lucenesearchresult>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lucenesearchresult");

                entity.Property(e => e.Searchid).HasColumnName("searchid");

                entity.Property(e => e.Searchindex).HasColumnName("searchindex");

                entity.Property(e => e.Transactionid).HasColumnName("transactionid");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.ToTable("messages");

                entity.HasIndex(e => e.Soapid, "ix_messages")
                    .IsUnique();

                entity.HasIndex(e => e.Transactionid, "transactionid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('messages_seq'::regclass)");

                entity.Property(e => e.Datumverzonden).HasColumnName("datumverzonden");

                entity.Property(e => e.Gelezen).HasColumnName("gelezen");

                entity.Property(e => e.Mitid).HasColumnName("mitid");

                entity.Property(e => e.Ontvangerpersoonrolid).HasColumnName("ontvangerpersoonrolid");

                entity.Property(e => e.Reactietermijn).HasColumnName("reactietermijn");

                entity.Property(e => e.Soapid)
                    .HasMaxLength(255)
                    .HasColumnName("soapid");

                entity.Property(e => e.Tijdverzonden).HasColumnName("tijdverzonden");

                entity.Property(e => e.Transactionid).HasColumnName("transactionid");

                entity.Property(e => e.Verzenderloginname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("verzenderloginname")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Verzenderpersoonrolid).HasColumnName("verzenderpersoonrolid");

                entity.HasOne(d => d.Mit)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.Mitid)
                    .HasConstraintName("fk_messages_mit");

                entity.HasOne(d => d.Ontvangerpersoonrol)
                    .WithMany(p => p.MessageOntvangerpersoonrols)
                    .HasForeignKey(d => d.Ontvangerpersoonrolid)
                    .HasConstraintName("fk_messages_ontvangerpersoonrollen");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.Transactionid)
                    .HasConstraintName("fk_transactions_messages");

                entity.HasOne(d => d.Verzenderpersoonrol)
                    .WithMany(p => p.MessageVerzenderpersoonrols)
                    .HasForeignKey(d => d.Verzenderpersoonrolid)
                    .HasConstraintName("fk_messages_verzenderpersoonrollen");
            });

            modelBuilder.Entity<Messagecontent>(entity =>
            {
                entity.HasKey(e => new { e.Messagetypeid, e.Counternr })
                    .HasName("pk__messagec__34b098d17b5b524b");

                entity.ToTable("messagecontent");

                entity.Property(e => e.Messagetypeid).HasColumnName("messagetypeid");

                entity.Property(e => e.Counternr).HasColumnName("counternr");

                entity.Property(e => e.Elementid).HasColumnName("elementid");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Messagecontents)
                    .HasForeignKey(d => d.Elementid)
                    .HasConstraintName("fk_message_content");

                entity.HasOne(d => d.Messagetype)
                    .WithMany(p => p.Messagecontents)
                    .HasForeignKey(d => d.Messagetypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk765af5b374612768");
            });

            modelBuilder.Entity<Messagefile>(entity =>
            {
                entity.ToTable("messagefiles");

                entity.HasIndex(e => e.Messageid, "messageid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('messagefiles_seq'::regclass)");

                entity.Property(e => e.Appendixid).HasColumnName("appendixid");

                entity.Property(e => e.Filename)
                    .HasMaxLength(255)
                    .HasColumnName("filename");

                entity.Property(e => e.Messageid).HasColumnName("messageid");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Sharepointid)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("sharepointid")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Sharepointlibrary)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("sharepointlibrary")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Sharepointurl)
                    .IsRequired()
                    .HasColumnName("sharepointurl")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.Thinkprojectdocumenthref)
                    .IsRequired()
                    .HasColumnName("thinkprojectdocumenthref")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.Thinkprojectfilehref)
                    .IsRequired()
                    .HasColumnName("thinkprojectfilehref")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.Visifileid).HasColumnName("visifileid");

                entity.HasOne(d => d.Appendix)
                    .WithMany(p => p.Messagefiles)
                    .HasForeignKey(d => d.Appendixid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_messagefiles_appendixes");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Messagefiles)
                    .HasForeignKey(d => d.Messageid)
                    .HasConstraintName("fk_messagefiles_messages");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Messagefiles)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_messagefiles_projects");

                entity.HasOne(d => d.Visifile)
                    .WithMany(p => p.Messagefiles)
                    .HasForeignKey(d => d.Visifileid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_messagefiles_visifiles");
            });

            modelBuilder.Entity<Messagefilevalue>(entity =>
            {
                entity.ToTable("messagefilevalues");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('messagefilevalues_seq'::regclass)");

                entity.Property(e => e.Displayvalue).HasColumnName("displayvalue");

                entity.Property(e => e.Messagefileid).HasColumnName("messagefileid");

                entity.Property(e => e.Simpleelementid).HasColumnName("simpleelementid");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Messagefile)
                    .WithMany(p => p.Messagefilevalues)
                    .HasForeignKey(d => d.Messagefileid)
                    .HasConstraintName("fk_messagefilevalues_messagefiles");

                entity.HasOne(d => d.Simpleelement)
                    .WithMany(p => p.Messagefilevalues)
                    .HasForeignKey(d => d.Simpleelementid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkd41e0af629bd54e8");
            });

            modelBuilder.Entity<Messagetype>(entity =>
            {
                entity.ToTable("messagetypes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('messagetypes_seq'::regclass)");

                entity.Property(e => e.Appendixmandatory).HasColumnName("appendixmandatory");

                entity.Property(e => e.Helpinfo).HasColumnName("helpinfo");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sid");

                entity.HasOne(d => d.Raamwerk)
                    .WithMany(p => p.Messagetypes)
                    .HasForeignKey(d => d.Raamwerkid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_messagetypes_raamwerken");
            });

            modelBuilder.Entity<Messagetypeappendix>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("messagetypeappendices");

                entity.Property(e => e.Appendixid).HasColumnName("appendixid");

                entity.Property(e => e.Messagetypeid).HasColumnName("messagetypeid");

                entity.HasOne(d => d.Appendix)
                    .WithMany()
                    .HasForeignKey(d => d.Appendixid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_messagetypeappendices_appendixes");

                entity.HasOne(d => d.Messagetype)
                    .WithMany()
                    .HasForeignKey(d => d.Messagetypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_messagetypeappendices_messagetypes");
            });

            modelBuilder.Entity<Messagevalue>(entity =>
            {
                entity.ToTable("messagevalues");

                entity.HasIndex(e => e.Elementid, "elementid");

                entity.HasIndex(e => e.Messageid, "messagevaluesmessageid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('messagevalues_seq'::regclass)");

                entity.Property(e => e.Complexelementid).HasColumnName("complexelementid");

                entity.Property(e => e.Elementid).HasColumnName("elementid");

                entity.Property(e => e.Htmlvalue)
                    .IsRequired()
                    .HasColumnName("htmlvalue")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.Messageid).HasColumnName("messageid");

                entity.Property(e => e.Parentcomplexelementid).HasColumnName("parentcomplexelementid");

                entity.Property(e => e.Rownumber).HasColumnName("rownumber");

                entity.Property(e => e.Screenvalue)
                    .IsRequired()
                    .HasColumnName("screenvalue");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.HasOne(d => d.Complexelement)
                    .WithMany(p => p.MessagevalueComplexelements)
                    .HasForeignKey(d => d.Complexelementid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_messagevalues_element");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.MessagevalueElements)
                    .HasForeignKey(d => d.Elementid)
                    .HasConstraintName("fk37b6b8d63e4a7a2");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Messagevalues)
                    .HasForeignKey(d => d.Messageid)
                    .HasConstraintName("fk_messages_messagevalues");

                entity.HasOne(d => d.Parentcomplexelement)
                    .WithMany(p => p.MessagevalueParentcomplexelements)
                    .HasForeignKey(d => d.Parentcomplexelementid)
                    .HasConstraintName("fk_messagevalues_parentelementt");
            });

            modelBuilder.Entity<Metaraamwerkupdate>(entity =>
            {
                entity.ToTable("metaraamwerkupdates");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('metaraamwerkupdates_seq'::regclass)");

                entity.Property(e => e.Confirmed).HasColumnName("confirmed");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data");

                entity.Property(e => e.Executed).HasColumnName("executed");

                entity.Property(e => e.Ingangsdatum)
                    .HasColumnType("date")
                    .HasColumnName("ingangsdatum");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Metaraamwerkupdates)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_metaraamwerkupdates_projects");
            });

            modelBuilder.Entity<Mit>(entity =>
            {
                entity.ToTable("mit");

                entity.HasIndex(e => new { e.Raamwerkid, e.Sid }, "ix_mit")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mit_seq'::regclass)");

                entity.Property(e => e.Demophase).HasColumnName("demophase");

                entity.Property(e => e.Firstmessage).HasColumnName("firstmessage");

                entity.Property(e => e.Groupid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("groupid");

                entity.Property(e => e.Iseditablebyeveryone).HasColumnName("iseditablebyeveryone");

                entity.Property(e => e.Messagetypeid).HasColumnName("messagetypeid");

                entity.Property(e => e.Opensecondarytransactionallowed).HasColumnName("opensecondarytransactionallowed");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sid");

                entity.Property(e => e.Transactiontypeid).HasColumnName("transactiontypeid");

                entity.HasOne(d => d.Messagetype)
                    .WithMany(p => p.Mits)
                    .HasForeignKey(d => d.Messagetypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mit_messagetypeid");

                entity.HasOne(d => d.Raamwerk)
                    .WithMany(p => p.Mits)
                    .HasForeignKey(d => d.Raamwerkid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mit_raamwerkid");

                entity.HasOne(d => d.Transactiontype)
                    .WithMany(p => p.Mits)
                    .HasForeignKey(d => d.Transactiontypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mit_transactiontypeid");
            });

            modelBuilder.Entity<Mitappendix>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mitappendices");

                entity.Property(e => e.Appendixid).HasColumnName("appendixid");

                entity.Property(e => e.Mitid).HasColumnName("mitid");

                entity.HasOne(d => d.Appendix)
                    .WithMany()
                    .HasForeignKey(d => d.Appendixid)
                    .HasConstraintName("fk_mitappendices_appendix");

                entity.HasOne(d => d.Mit)
                    .WithMany()
                    .HasForeignKey(d => d.Mitid)
                    .HasConstraintName("fk_mitappendices_mit");
            });

            modelBuilder.Entity<Mitcondition>(entity =>
            {
                entity.ToTable("mitconditions");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('mitconditions_seq'::regclass)");

                entity.Property(e => e.Helpinfo).HasColumnName("helpinfo");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sid");

                entity.HasOne(d => d.Raamwerk)
                    .WithMany(p => p.Mitconditions)
                    .HasForeignKey(d => d.Raamwerkid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mitconditions_raamwerken");
            });

            modelBuilder.Entity<Mitconditionlink>(entity =>
            {
                entity.HasKey(e => new { e.Conditionid, e.Mitid })
                    .HasName("pk_mitconditionlinks");

                entity.ToTable("mitconditionlinks");

                entity.Property(e => e.Conditionid).HasColumnName("conditionid");

                entity.Property(e => e.Mitid).HasColumnName("mitid");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.Mitconditionlinks)
                    .HasForeignKey(d => d.Conditionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mittypeconditionlinks_mittypeconditions");

                entity.HasOne(d => d.Mit)
                    .WithMany(p => p.Mitconditionlinks)
                    .HasForeignKey(d => d.Mitid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mittypeconditionlinks_mit");
            });

            modelBuilder.Entity<Mitpreviou>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("mitprevious");

                entity.HasIndex(e => e.Mitid, "mitid");

                entity.HasIndex(e => e.Previousmitid, "previousmitid");

                entity.Property(e => e.Mitid).HasColumnName("mitid");

                entity.Property(e => e.Previousmitid).HasColumnName("previousmitid");

                entity.HasOne(d => d.Mit)
                    .WithMany()
                    .HasForeignKey(d => d.Mitid)
                    .HasConstraintName("fk_mitprevious_mit");

                entity.HasOne(d => d.Previousmit)
                    .WithMany()
                    .HasForeignKey(d => d.Previousmitid)
                    .HasConstraintName("fk_mitprevious_previous");
            });

            modelBuilder.Entity<Mitsendaftercondition>(entity =>
            {
                entity.HasKey(e => new { e.Conditionid, e.Mitid })
                    .HasName("pk_mittypesendafterconditions");

                entity.ToTable("mitsendafterconditions");

                entity.Property(e => e.Conditionid).HasColumnName("conditionid");

                entity.Property(e => e.Mitid).HasColumnName("mitid");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.Mitsendafterconditions)
                    .HasForeignKey(d => d.Conditionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mittypesendafterconditions_mittypeconditions1");

                entity.HasOne(d => d.Mit)
                    .WithMany(p => p.Mitsendafterconditions)
                    .HasForeignKey(d => d.Mitid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mittypesendafterconditions_mit1");
            });

            modelBuilder.Entity<Mitsendbeforecondition>(entity =>
            {
                entity.HasKey(e => new { e.Conditionid, e.Mitid })
                    .HasName("pk_mittypesendbeforeconditions");

                entity.ToTable("mitsendbeforeconditions");

                entity.Property(e => e.Conditionid).HasColumnName("conditionid");

                entity.Property(e => e.Mitid).HasColumnName("mitid");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.Mitsendbeforeconditions)
                    .HasForeignKey(d => d.Conditionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mittypesendbeforeconditions_mittypeconditions");

                entity.HasOne(d => d.Mit)
                    .WithMany(p => p.Mitsendbeforeconditions)
                    .HasForeignKey(d => d.Mitid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mittypesendbeforeconditions_mit");
            });

            modelBuilder.Entity<Oldmessagevalue>(entity =>
            {
                entity.ToTable("oldmessagevalues");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('oldmessagevalues_seq'::regclass)");

                entity.Property(e => e.Complexelementid).HasColumnName("complexelementid");

                entity.Property(e => e.Datum).HasColumnName("datum");

                entity.Property(e => e.Elementid).HasColumnName("elementid");

                entity.Property(e => e.Htmlvalue)
                    .IsRequired()
                    .HasColumnName("htmlvalue");

                entity.Property(e => e.Messageid).HasColumnName("messageid");

                entity.Property(e => e.Parentcomplexelementid).HasColumnName("parentcomplexelementid");

                entity.Property(e => e.Rownumber).HasColumnName("rownumber");

                entity.Property(e => e.Screenvalue)
                    .IsRequired()
                    .HasColumnName("screenvalue");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.HasOne(d => d.Complexelement)
                    .WithMany(p => p.OldmessagevalueComplexelements)
                    .HasForeignKey(d => d.Complexelementid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_messages_complexelement2");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.OldmessagevalueElements)
                    .HasForeignKey(d => d.Elementid)
                    .HasConstraintName("fk_messages_element2");

                entity.HasOne(d => d.Message)
                    .WithMany(p => p.Oldmessagevalues)
                    .HasForeignKey(d => d.Messageid)
                    .HasConstraintName("fk_messages_oldmessagevalues2");

                entity.HasOne(d => d.Parentcomplexelement)
                    .WithMany(p => p.OldmessagevalueParentcomplexelements)
                    .HasForeignKey(d => d.Parentcomplexelementid)
                    .HasConstraintName("fk_messages_parentcomplexelement2");
            });

            modelBuilder.Entity<Organisatievolgnummer>(entity =>
            {
                entity.ToTable("organisatievolgnummers");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('organisatievolgnummers_seq'::regclass)");

                entity.Property(e => e.Organisatiesid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("organisatiesid");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Volgnummer).HasColumnName("volgnummer");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Organisatievolgnummers)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_organisatievolgnummers_projects");
            });

            modelBuilder.Entity<Organisationtype>(entity =>
            {
                entity.ToTable("organisationtypes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('organisationtypes_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sid");
            });

            modelBuilder.Entity<Organisationtypecontent>(entity =>
            {
                entity.HasKey(e => new { e.Organisationid, e.Counternr })
                    .HasName("pk__organisa__dd323cb7778ac167");

                entity.ToTable("organisationtypecontent");

                entity.Property(e => e.Organisationid).HasColumnName("organisationid");

                entity.Property(e => e.Counternr).HasColumnName("counternr");

                entity.Property(e => e.Elementid).HasColumnName("elementid");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Organisationtypecontents)
                    .HasForeignKey(d => d.Elementid)
                    .HasConstraintName("fk_organisationtypecontent_element");

                entity.HasOne(d => d.Organisation)
                    .WithMany(p => p.Organisationtypecontents)
                    .HasForeignKey(d => d.Organisationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk99f9d63654e1b20e");
            });

            modelBuilder.Entity<Organisaty>(entity =>
            {
                entity.HasKey(e => e.Organisatieid)
                    .HasName("pk__organisa__5b6a195d534d60f1");

                entity.ToTable("organisaties");

                entity.Property(e => e.Organisatieid)
                    .HasColumnName("organisatieid")
                    .HasDefaultValueSql("nextval('organisaties_seq'::regclass)");

                entity.Property(e => e.Abbr)
                    .HasMaxLength(255)
                    .HasColumnName("abbr");

                entity.Property(e => e.Contactpersoonid).HasColumnName("contactpersoonid");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Publickey)
                    .HasMaxLength(255)
                    .HasColumnName("publickey");

                entity.Property(e => e.Soapurl)
                    .HasMaxLength(255)
                    .HasColumnName("soapurl");

                entity.HasOne(d => d.Contactpersoon)
                    .WithMany(p => p.Organisaties)
                    .HasForeignKey(d => d.Contactpersoonid)
                    .HasConstraintName("fk_organisaties_personen");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Organisaties)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk70dd4cdded792f41");
            });

            modelBuilder.Entity<Personen>(entity =>
            {
                entity.HasKey(e => e.Persoonid)
                    .HasName("pk__personen__fa09140033d4b598");

                entity.ToTable("personen");

                entity.Property(e => e.Persoonid)
                    .HasColumnName("persoonid")
                    .HasDefaultValueSql("nextval('personen_seq'::regclass)");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("id");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("naam");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("type");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Personens)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk2f444428ed792f41");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Personens)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("fk_personen_users");
            });

            modelBuilder.Entity<Persontype>(entity =>
            {
                entity.ToTable("persontypes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('persontypes_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sid");
            });

            modelBuilder.Entity<Persontypecontent>(entity =>
            {
                entity.HasKey(e => new { e.Persontypeid, e.Counternr })
                    .HasName("pk__personty__764cb0d67f2be32f");

                entity.ToTable("persontypecontent");

                entity.Property(e => e.Persontypeid).HasColumnName("persontypeid");

                entity.Property(e => e.Counternr).HasColumnName("counternr");

                entity.Property(e => e.Elementid).HasColumnName("elementid");

                entity.HasOne(d => d.Element)
                    .WithMany(p => p.Persontypecontents)
                    .HasForeignKey(d => d.Elementid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk53a30db463e4a7a2");

                entity.HasOne(d => d.Persontype)
                    .WithMany(p => p.Persontypecontents)
                    .HasForeignKey(d => d.Persontypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk53a30db4d0e7e7e4");
            });

            modelBuilder.Entity<Persoonlijkemappen>(entity =>
            {
                entity.ToTable("persoonlijkemappen");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('persoonlijkemappen_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Persoonid2).HasColumnName("persoonid2");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.HasOne(d => d.Persoonid2Navigation)
                    .WithMany(p => p.Persoonlijkemappens)
                    .HasForeignKey(d => d.Persoonid2)
                    .HasConstraintName("fk_persoonlijkemap_persoon");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Persoonlijkemappens)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_persoonlijkemappen_projects");
            });

            modelBuilder.Entity<Persoonlijkemaptransaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("persoonlijkemaptransactions");

                entity.Property(e => e.Persoonlijkemapid).HasColumnName("persoonlijkemapid");

                entity.Property(e => e.Transactionid).HasColumnName("transactionid");

                entity.HasOne(d => d.Persoonlijkemap)
                    .WithMany()
                    .HasForeignKey(d => d.Persoonlijkemapid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_persoonlijkemaptransactions_persoonlijkemappen");

                entity.HasOne(d => d.Transaction)
                    .WithMany()
                    .HasForeignKey(d => d.Transactionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_persoonlijkemaptransactions_transactions");
            });

            modelBuilder.Entity<Persoonrollen>(entity =>
            {
                entity.ToTable("persoonrollen");

                entity.HasIndex(e => new { e.Gemachtigdnamenspersoonrolid, e.Successorpersoonrolid, e.Projectid, e.Isactive }, "gemachtigde");

                entity.HasIndex(e => new { e.Isactive, e.Sid }, "isactivesid");

                entity.HasIndex(e => e.Persoonid2, "persoonid2");

                entity.HasIndex(e => new { e.Rolid2, e.Isactive }, "rolid2isactive");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('persoonrollen_seq'::regclass)");

                entity.Property(e => e.Gemachtigdnamenspersoonrolid).HasColumnName("gemachtigdnamenspersoonrolid");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Islocked).HasColumnName("islocked");

                entity.Property(e => e.Organisatieid2).HasColumnName("organisatieid2");

                entity.Property(e => e.Persoonid2).HasColumnName("persoonid2");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Rolid2).HasColumnName("rolid2");

                entity.Property(e => e.Sid)
                    .HasMaxLength(255)
                    .HasColumnName("sid");

                entity.Property(e => e.Successorpersoonrolid).HasColumnName("successorpersoonrolid");

                entity.HasOne(d => d.Gemachtigdnamenspersoonrol)
                    .WithMany(p => p.InverseGemachtigdnamenspersoonrol)
                    .HasForeignKey(d => d.Gemachtigdnamenspersoonrolid)
                    .HasConstraintName("fk_persoonrol_gemachtigde");

                entity.HasOne(d => d.Organisatieid2Navigation)
                    .WithMany(p => p.Persoonrollens)
                    .HasForeignKey(d => d.Organisatieid2)
                    .HasConstraintName("fk_persoonrol_organisatie");

                entity.HasOne(d => d.Persoonid2Navigation)
                    .WithMany(p => p.Persoonrollens)
                    .HasForeignKey(d => d.Persoonid2)
                    .HasConstraintName("fk_persoonrol_persoon");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Persoonrollens)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_persoonrol_project");

                entity.HasOne(d => d.Rolid2Navigation)
                    .WithMany(p => p.Persoonrollens)
                    .HasForeignKey(d => d.Rolid2)
                    .HasConstraintName("fk_persoonrol_rol");

                entity.HasOne(d => d.Successorpersoonrol)
                    .WithMany(p => p.InverseSuccessorpersoonrol)
                    .HasForeignKey(d => d.Successorpersoonrolid)
                    .HasConstraintName("fk_persoonrollen_persoonrollen");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("projects");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('projects_seq'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Iscrm).HasColumnName("iscrm");

                entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");

                entity.Property(e => e.Isworkflowproject).HasColumnName("isworkflowproject");

                entity.Property(e => e.Modules)
                    .HasMaxLength(255)
                    .HasColumnName("modules");

                entity.Property(e => e.Moduleurls)
                    .HasMaxLength(255)
                    .HasColumnName("moduleurls");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Parentid)
                    .HasColumnName("parentid")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Projecttype)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("projecttype");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sid");

                entity.Property(e => e.Subtransactionallowed).HasColumnName("subtransactionallowed");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<Projectdate>(entity =>
            {
                entity.ToTable("projectdates");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('projectdates_seq'::regclass)");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Psbchanged).HasColumnName("psbchanged");
            });

            modelBuilder.Entity<Projectsetting>(entity =>
            {
                entity.ToTable("projectsettings");

                entity.HasIndex(e => new { e.Personid, e.Setting }, "ixprojectsettings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('projectsettings_seq'::regclass)");

                entity.Property(e => e.Personid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("personid");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Setting)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("setting");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Projectsettings)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk7c932999ed792f41");
            });

            modelBuilder.Entity<Raamwerkdatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("raamwerkdata");

                entity.Property(e => e.Mitsid).HasColumnName("mitsid");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Raamwerkxsd)
                    .IsRequired()
                    .HasColumnName("raamwerkxsd");

                entity.Property(e => e.Transactiontypesid).HasColumnName("transactiontypesid");

                entity.HasOne(d => d.Raamwerk)
                    .WithMany()
                    .HasForeignKey(d => d.Raamwerkid)
                    .HasConstraintName("fk_raamwerkdata_raamwerken");
            });

            modelBuilder.Entity<Raamwerken>(entity =>
            {
                entity.ToTable("raamwerken");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('raamwerken_seq'::regclass)");

                entity.Property(e => e.Counternr).HasColumnName("counternr");

                entity.Property(e => e.Isbasisraamwerk).HasColumnName("isbasisraamwerk");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Schemalocation)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("schemalocation");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sid");

                entity.Property(e => e.Systematiek)
                    .IsRequired()
                    .HasMaxLength(4)
                    .HasColumnName("systematiek");

                entity.Property(e => e.Xmlns)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("xmlns");

                entity.Property(e => e.Xsi)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("xsi");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Raamwerkens)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkef3d1d238bb46416");
            });

            modelBuilder.Entity<Raamwerksplitsen>(entity =>
            {
                entity.ToTable("raamwerksplitsen");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('raamwerksplitsen_seq'::regclass)");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Raamwerkxml)
                    .IsRequired()
                    .HasColumnName("raamwerkxml");

                entity.Property(e => e.Splitsattemptdate).HasColumnName("splitsattemptdate");

                entity.Property(e => e.Splitsattempts).HasColumnName("splitsattempts");

                entity.Property(e => e.Splitserror).HasColumnName("splitserror");

                entity.Property(e => e.Splitsstatus).HasColumnName("splitsstatus");
            });

            modelBuilder.Entity<Roletype>(entity =>
            {
                entity.ToTable("roletypes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('roletypes_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sid");
            });

            modelBuilder.Entity<Rollen>(entity =>
            {
                entity.HasKey(e => e.Rolid)
                    .HasName("pk__rollen__f92302d13f466844");

                entity.ToTable("rollen");

                entity.HasIndex(e => e.Projectid, "projectid");

                entity.Property(e => e.Rolid)
                    .HasColumnName("rolid")
                    .HasDefaultValueSql("nextval('rollen_seq'::regclass)");

                entity.Property(e => e.Naam)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("naam");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Roletype)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("roletype");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sid");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Rollens)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk8d6705ed792f41");
            });

            modelBuilder.Entity<Rootfolder>(entity =>
            {
                entity.ToTable("rootfolder");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('rootfolder_seq'::regclass)");

                entity.Property(e => e.Iconcls)
                    .HasMaxLength(1000)
                    .HasColumnName("iconcls");

                entity.Property(e => e.Isleaf).HasColumnName("isleaf");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Persoonid).HasColumnName("persoonid");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Treeid)
                    .IsRequired()
                    .HasColumnName("treeid");

                entity.HasOne(d => d.Persoon)
                    .WithMany(p => p.Rootfolders)
                    .HasForeignKey(d => d.Persoonid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rootfolder_persoon");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Rootfolders)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rootfolder_project");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.Gid)
                    .HasName("pk__session__c51f0f3e30f848ed");

                entity.ToTable("session");

                entity.Property(e => e.Gid)
                    .ValueGeneratedNever()
                    .HasColumnName("gid");

                entity.Property(e => e.Duration).HasColumnName("duration");

                entity.Property(e => e.Filereadyfordownload)
                    .HasMaxLength(255)
                    .HasColumnName("filereadyfordownload");

                entity.Property(e => e.Hostname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("hostname");

                entity.Property(e => e.Ip)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("ip");

                entity.Property(e => e.Persoonid).HasColumnName("persoonid");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Start).HasColumnName("start");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.Useragent)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("useragent");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Useridadministrator).HasColumnName("useridadministrator");

                entity.HasOne(d => d.Persoon)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.Persoonid)
                    .HasConstraintName("fk_session_personen");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.Projectid)
                    .HasConstraintName("fk_session_projects");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SessionUsers)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_session_users");

                entity.HasOne(d => d.UseridadministratorNavigation)
                    .WithMany(p => p.SessionUseridadministratorNavigations)
                    .HasForeignKey(d => d.Useridadministrator)
                    .HasConstraintName("fk_session_usersadministrator");
            });

            modelBuilder.Entity<Sessioncall>(entity =>
            {
                entity.ToTable("sessioncall");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('sessioncall_seq'::regclass)");

                entity.Property(e => e.Input)
                    .IsRequired()
                    .HasColumnName("input");

                entity.Property(e => e.Output).HasColumnName("output");

                entity.Property(e => e.Sessionid).HasColumnName("sessionid");
            });

            modelBuilder.Entity<Sessioncit>(entity =>
            {
                entity.ToTable("sessioncit");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('sessioncit_seq'::regclass)");

                entity.Property(e => e.Inlogname)
                    .IsRequired()
                    .HasColumnName("inlogname");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.Startdate).HasColumnName("startdate");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasColumnName("token");

                entity.Property(e => e.Uniqueid).HasColumnName("uniqueid");
            });

            modelBuilder.Entity<Sessioncitlog>(entity =>
            {
                entity.ToTable("sessioncitlog");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('sessioncitlog_seq'::regclass)");

                entity.Property(e => e.Inlogname)
                    .IsRequired()
                    .HasColumnName("inlogname");

                entity.Property(e => e.Source).HasColumnName("source");

                entity.Property(e => e.Startdate).HasColumnName("startdate");

                entity.Property(e => e.Uniqueid).HasColumnName("uniqueid");
            });

            modelBuilder.Entity<Soapmessage>(entity =>
            {
                entity.ToTable("soapmessages");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('soapmessages_seq'::regclass)");

                entity.Property(e => e.Direction).HasColumnName("direction");

                entity.Property(e => e.Soapurlreceiver)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("soapurlreceiver");

                entity.Property(e => e.Soapurlsender)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("soapurlsender");

                entity.Property(e => e.Soapxml).HasColumnName("soapxml");

                entity.Property(e => e.Uniqueid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("uniqueid");
            });

            modelBuilder.Entity<Succeeded>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("succeeded");

                entity.Property(e => e.Persoonrolid).HasColumnName("persoonrolid");

                entity.Property(e => e.Succeededpersoonrolid).HasColumnName("succeededpersoonrolid");

                entity.HasOne(d => d.Persoonrol)
                    .WithMany()
                    .HasForeignKey(d => d.Persoonrolid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_succeeded_persoonrollen");

                entity.HasOne(d => d.Succeededpersoonrol)
                    .WithMany()
                    .HasForeignKey(d => d.Succeededpersoonrolid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_succeeded_persoonrollen1");
            });

            modelBuilder.Entity<Text>(entity =>
            {
                entity.ToTable("texts");

                entity.HasIndex(e => e.Name, "uq__texts__737584f60519c6af")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(md5(((random())::text || (clock_timestamp())::text)))::uuid");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Textgroup>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Textid })
                    .HasName("pk_textgroups");

                entity.ToTable("textgroups");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Textid).HasColumnName("textid");

                entity.HasOne(d => d.Text)
                    .WithMany(p => p.Textgroups)
                    .HasForeignKey(d => d.Textid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_textgroups_texts");
            });

            modelBuilder.Entity<Textversion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("textversion");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transactions");

                entity.HasIndex(e => new { e.Projectid, e.Verborgen }, "ix_trans_hidden");

                entity.HasIndex(e => e.Parenttransactionid, "ix_trans_parent");

                entity.HasIndex(e => e.Projectid, "ix_trans_project");

                entity.HasIndex(e => e.Transactiontypeid, "ix_trans_transtype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('transactions_seq'::regclass)");

                entity.Property(e => e.Agenderen).HasColumnName("agenderen");

                entity.Property(e => e.Alleberichtengelezen).HasColumnName("alleberichtengelezen");

                entity.Property(e => e.Coordx)
                    .HasPrecision(15, 8)
                    .HasColumnName("coordx");

                entity.Property(e => e.Coordy)
                    .HasPrecision(15, 8)
                    .HasColumnName("coordy");

                entity.Property(e => e.Executorpersoonrolid).HasColumnName("executorpersoonrolid");

                entity.Property(e => e.Gereed).HasColumnName("gereed");

                entity.Property(e => e.Initiatingmessnr).HasColumnName("initiatingmessnr");

                entity.Property(e => e.Initiatorpersoonrolid).HasColumnName("initiatorpersoonrolid");

                entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");

                entity.Property(e => e.Laatstedatumverzonden).HasColumnName("laatstedatumverzonden");

                entity.Property(e => e.Laatsteontvangerpersoonrolid).HasColumnName("laatsteontvangerpersoonrolid");

                entity.Property(e => e.Laatstereactietermijn).HasColumnName("laatstereactietermijn");

                entity.Property(e => e.Laatsteverzenderpersoonrolid).HasColumnName("laatsteverzenderpersoonrolid");

                entity.Property(e => e.Lastmessageid)
                    .HasColumnName("lastmessageid")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Messageconfirmationreceived).HasColumnName("messageconfirmationreceived");

                entity.Property(e => e.Messagesenderror)
                    .HasColumnType("character varying")
                    .HasColumnName("messagesenderror");

                entity.Property(e => e.Messagesendstatus).HasColumnName("messagesendstatus");

                entity.Property(e => e.Nextsenddate)
                    .HasColumnType("date")
                    .HasColumnName("nextsenddate");

                entity.Property(e => e.Parenttransactionid).HasColumnName("parenttransactionid");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Reactietermijnverlopenmailsent).HasColumnName("reactietermijnverlopenmailsent");

                entity.Property(e => e.Sendservicemessageid).HasColumnName("sendservicemessageid");

                entity.Property(e => e.Sentmessageconfirmationerror)
                    .HasColumnType("character varying")
                    .HasColumnName("sentmessageconfirmationerror");

                entity.Property(e => e.Showassubtransaction)
                    .IsRequired()
                    .HasColumnName("showassubtransaction")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Showinlinkedlist)
                    .IsRequired()
                    .HasColumnName("showinlinkedlist")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Soapid)
                    .HasMaxLength(255)
                    .HasColumnName("soapid");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Statusid).HasColumnName("statusid");

                entity.Property(e => e.Titel)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("titel");

                entity.Property(e => e.Transactiontypeid).HasColumnName("transactiontypeid");

                entity.Property(e => e.Verborgen).HasColumnName("verborgen");

                entity.Property(e => e.Volgnummer).HasColumnName("volgnummer");

                entity.Property(e => e.Volgnummer13).HasColumnName("volgnummer13");

                entity.Property(e => e.Volgnummerafk)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("volgnummerafk")
                    .HasDefaultValueSql("''::character varying");

                entity.Property(e => e.Volgnummersub).HasColumnName("volgnummersub");

                entity.HasOne(d => d.Executorpersoonrol)
                    .WithMany(p => p.TransactionExecutorpersoonrols)
                    .HasForeignKey(d => d.Executorpersoonrolid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transactions_executor");

                entity.HasOne(d => d.Initiatorpersoonrol)
                    .WithMany(p => p.TransactionInitiatorpersoonrols)
                    .HasForeignKey(d => d.Initiatorpersoonrolid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transactions_initiator");

                entity.HasOne(d => d.Laatsteontvangerpersoonrol)
                    .WithMany(p => p.TransactionLaatsteontvangerpersoonrols)
                    .HasForeignKey(d => d.Laatsteontvangerpersoonrolid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transactions_ontvangerpersoonrollen");

                entity.HasOne(d => d.Laatsteverzenderpersoonrol)
                    .WithMany(p => p.TransactionLaatsteverzenderpersoonrols)
                    .HasForeignKey(d => d.Laatsteverzenderpersoonrolid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transactions_verzenderpersoonrollen");

                entity.HasOne(d => d.Lastmessage)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Lastmessageid)
                    .HasConstraintName("fk_transactions_messages1");

                entity.HasOne(d => d.Parenttransaction)
                    .WithMany(p => p.InverseParenttransaction)
                    .HasForeignKey(d => d.Parenttransactionid)
                    .HasConstraintName("fk_transactions_parenttransaction");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transactions_projects");

                entity.HasOne(d => d.Transactiontype)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.Transactiontypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk33a9128b1fafa49");
            });

            modelBuilder.Entity<Transactionlink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("transactionlinks");

                entity.HasIndex(e => e.Parenttransactionid, "ixparent");

                entity.HasIndex(e => new { e.Parenttransactionid, e.Childtransactionid }, "ixparentchild");

                entity.Property(e => e.Childtransactionid).HasColumnName("childtransactionid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('transactionlinks_seq'::regclass)");

                entity.Property(e => e.Parenttransactionid).HasColumnName("parenttransactionid");

                entity.HasOne(d => d.Childtransaction)
                    .WithMany()
                    .HasForeignKey(d => d.Childtransactionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk12b4fdb9ea3874f");

                entity.HasOne(d => d.Parenttransaction)
                    .WithMany()
                    .HasForeignKey(d => d.Parenttransactionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk12b4fdb9d8237b81");
            });

            modelBuilder.Entity<Transactiontype>(entity =>
            {
                entity.ToTable("transactiontypes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('transactiontypes_seq'::regclass)");

                entity.Property(e => e.Executorroletype)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("executorroletype");

                entity.Property(e => e.Helpinfo).HasColumnName("helpinfo");

                entity.Property(e => e.Initiatorroletype)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("initiatorroletype");

                entity.Property(e => e.Iscrm).HasColumnName("iscrm");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.Passive).HasColumnName("passive");

                entity.Property(e => e.Raamwerkid).HasColumnName("raamwerkid");

                entity.Property(e => e.Sid)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sid");

                entity.HasOne(d => d.Raamwerk)
                    .WithMany(p => p.Transactiontypes)
                    .HasForeignKey(d => d.Raamwerkid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transactiontypes_raamwerken");
            });

            modelBuilder.Entity<Transactiontypeappendix>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("transactiontypeappendices");

                entity.Property(e => e.Appendixid).HasColumnName("appendixid");

                entity.Property(e => e.Transactiontypeid).HasColumnName("transactiontypeid");

                entity.HasOne(d => d.Appendix)
                    .WithMany()
                    .HasForeignKey(d => d.Appendixid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transactiontypeappendices_appendixes");

                entity.HasOne(d => d.Transactiontype)
                    .WithMany()
                    .HasForeignKey(d => d.Transactiontypeid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_transactiontypeappendices_transactiontypes");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Inlogname, "uq__users__82970abf300424b4")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('users_seq'::regclass)");

                entity.Property(e => e.Adminprojectid).HasColumnName("adminprojectid");

                entity.Property(e => e.Allowedtologin).HasColumnName("allowedtologin");

                entity.Property(e => e.Emailadres)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("emailadres");

                entity.Property(e => e.Emailnotificatie).HasColumnName("emailnotificatie");

                entity.Property(e => e.Externalid)
                    .HasMaxLength(255)
                    .HasColumnName("externalid");

                entity.Property(e => e.Failedloginattempts).HasColumnName("failedloginattempts");

                entity.Property(e => e.Inlogname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("inlogname");

                entity.Property(e => e.Lastpasswordchanged)
                    .HasColumnName("lastpasswordchanged")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.Lastprojectid).HasColumnName("lastprojectid");

                entity.Property(e => e.Localeid).HasColumnName("localeid");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password");

                entity.Property(e => e.Reactietermijnmaildagen).HasColumnName("reactietermijnmaildagen");

                entity.Property(e => e.Rechten).HasColumnName("rechten");

                entity.Property(e => e.Scimdeleted)
                    .HasColumnName("scimdeleted")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Temppassword)
                    .HasMaxLength(255)
                    .HasColumnName("temppassword");

                entity.Property(e => e.Twofactorauthtoken)
                    .HasMaxLength(8)
                    .HasColumnName("twofactorauthtoken");

                entity.Property(e => e.Twofactorauthtokendate).HasColumnName("twofactorauthtokendate");

                entity.Property(e => e.Twostepsauthenticatorsecret)
                    .HasMaxLength(255)
                    .HasColumnName("twostepsauthenticatorsecret");

                entity.HasOne(d => d.Lastproject)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Lastprojectid)
                    .HasConstraintName("fk_users_projects");

                entity.HasOne(d => d.Locale)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Localeid)
                    .HasConstraintName("fk_users_locales");
            });

            modelBuilder.Entity<Userproject>(entity =>
            {
                entity.HasKey(e => new { e.Userid, e.Projectid })
                    .HasName("pk__userproj__00e9674119aacf41");

                entity.ToTable("userprojects");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.Projectid).HasColumnName("projectid");

                entity.Property(e => e.Datecreated)
                    .HasColumnName("datecreated")
                    .HasDefaultValueSql("timezone('utc'::text, now())");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Userprojects)
                    .HasForeignKey(d => d.Projectid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk6175ddf8ed792f41");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userprojects)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk6175ddf8fa17d8e9");
            });

            modelBuilder.Entity<Userrole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("userroles");

                entity.Property(e => e.Counternr).HasColumnName("counternr");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_users");
            });

            modelBuilder.Entity<Visifile>(entity =>
            {
                entity.ToTable("visifiles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('visifiles_seq'::regclass)");

                entity.Property(e => e.Bestand).HasColumnName("bestand");

                entity.Property(e => e.Bestandsnaam)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("bestandsnaam");

                entity.Property(e => e.Checksum)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("checksum");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.Uniqueid)
                    .HasMaxLength(255)
                    .HasColumnName("uniqueid");
            });

            modelBuilder.HasSequence("appendixes_seq").StartsAt(4);

            modelBuilder.HasSequence("applicationreports_seq");

            modelBuilder.HasSequence("auxfiles_seq");

            modelBuilder.HasSequence("auxfunctions_seq");

            modelBuilder.HasSequence("concepts_seq");

            modelBuilder.HasSequence("element_seq").StartsAt(128);

            modelBuilder.HasSequence("elementconditions_seq").StartsAt(4);

            modelBuilder.HasSequence("executescript_seq");

            modelBuilder.HasSequence("favorietenmap_seq");

            modelBuilder.HasSequence("grouptypes_seq").StartsAt(2);

            modelBuilder.HasSequence("log_seq");

            modelBuilder.HasSequence("messagefiles_seq");

            modelBuilder.HasSequence("messagefilevalues_seq");

            modelBuilder.HasSequence("messages_seq").StartsAt(4);

            modelBuilder.HasSequence("messagetypes_seq").StartsAt(47);

            modelBuilder.HasSequence("messagevalues_seq").StartsAt(16);

            modelBuilder.HasSequence("metaraamwerkupdates_seq");

            modelBuilder.HasSequence("mit_seq").StartsAt(77);

            modelBuilder.HasSequence("mitconditions_seq");

            modelBuilder.HasSequence("oldmessagevalues_seq");

            modelBuilder.HasSequence("organisaties_seq").StartsAt(2);

            modelBuilder.HasSequence("organisatievolgnummers_seq");

            modelBuilder.HasSequence("organisationtypes_seq");

            modelBuilder.HasSequence("personen_seq").StartsAt(2);

            modelBuilder.HasSequence("persontypes_seq");

            modelBuilder.HasSequence("persoonlijkemappen_seq");

            modelBuilder.HasSequence("persoonrollen_seq").StartsAt(2);

            modelBuilder.HasSequence("projectdates_seq");

            modelBuilder.HasSequence("projects_seq").StartsAt(2);

            modelBuilder.HasSequence("projectsettings_seq");

            modelBuilder.HasSequence("raamwerkdata_seq");

            modelBuilder.HasSequence("raamwerken_seq").StartsAt(2);

            modelBuilder.HasSequence("raamwerksplitsen_seq");

            modelBuilder.HasSequence("roletypes_seq").StartsAt(5);

            modelBuilder.HasSequence("rollen_seq").StartsAt(3);

            modelBuilder.HasSequence("rootfolder_seq");

            modelBuilder.HasSequence("sessioncall_seq");

            modelBuilder.HasSequence("sessioncit_seq");

            modelBuilder.HasSequence("sessioncitlog_seq");

            modelBuilder.HasSequence("soapmessagefiles_seq");

            modelBuilder.HasSequence("soapmessages_seq");

            modelBuilder.HasSequence("transactionlinks_seq");

            modelBuilder.HasSequence("transactions_seq").StartsAt(4);

            modelBuilder.HasSequence("transactiontypes_seq").StartsAt(17);

            modelBuilder.HasSequence("users_seq").StartsAt(2);

            modelBuilder.HasSequence("visifiles_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
