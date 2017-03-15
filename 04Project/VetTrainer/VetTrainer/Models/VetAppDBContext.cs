namespace VetTrainer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MySql.Data.Entity;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class VetAppDBContext : DbContext
    {
        public VetAppDBContext()
            : base("name=VetAppDBContext")
        {
        }

        public virtual DbSet<Analysis> Analyses { get; set; }
        public virtual DbSet<Charge> Charges { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<DiseaseCase> DiseaseCases { get; set; }
        public virtual DbSet<DiseaseCaseTab> DiseaseCaseTabs { get; set; }
        public virtual DbSet<DiseaseType> DiseaseTypes { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<Instrument> Instruments { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Text> Texts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<RPRecord> RPRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<VetAppDBContext>(null);

            //modelBuilder.HasDefaultSchema("vet_app");
            #region Analyses

            modelBuilder.Entity<Analysis>()
                .ToTable("tb_analyses")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Analysis>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            modelBuilder.Entity<Analysis>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Analysis>()
                .Property(e => e.Amount)
                .HasColumnName("amount")
                .IsRequired();

            #endregion

            #region Charge

            modelBuilder.Entity<Charge>()
                .ToTable("tb_charges")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Charge>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Charge>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Charge>()
                .Property(e => e.Description)
                .HasColumnName("desp")
                .HasMaxLength(3000);

            modelBuilder.Entity<Charge>()
                .Property(e => e.Amount)
                .HasColumnName("amount")
                .IsRequired();

            #endregion

            #region Clinic

            modelBuilder.Entity<Clinic>()
                .ToTable("tb_clinics")
                .HasKey(e => e.Id)
                .HasMany(c => c.Instruments)
                .WithMany(i => i.Clinics)
                .Map(m =>
                {
                    m.ToTable("ref_clinic_instr");
                    m.MapLeftKey("clinic_id");
                    m.MapRightKey("instr_id");
                });

            modelBuilder.Entity<Clinic>()
                .HasMany(c => c.Texts)
                .WithOptional(t => t.RelatedClinic)
                .HasForeignKey(t => t.RelatedClinicId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clinic>()
                .HasMany(c => c.Pictures)
                .WithOptional(p => p.RelatedClinic)
                .HasForeignKey(p => p.RelatedClinicId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clinic>()
                .HasMany(c => c.Videos)
                .WithOptional(v => v.RelatedClinic)
                .HasForeignKey(v => v.RelatedClinicId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Clinic>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Clinic>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Clinic>()
                .Property(e => e.Description)
                .HasColumnName("desp")
                .HasMaxLength(3000);

            modelBuilder.Entity<Clinic>()
                .Property(e => e.PositionX)
                .HasColumnName("pos_x");

            modelBuilder.Entity<Clinic>()
                .Property(e => e.PositionY)
                .HasColumnName("pos_y");

            #endregion

            #region Diseases

            modelBuilder.Entity<Disease>()
                .ToTable("tb_diseases")
                .HasKey(e => e.Id)
                .HasMany(d => d.DiseaseCases)
                .WithMany(d => d.Diseases)
                .Map(m =>
                {
                    m.ToTable("ref_dise_dc");
                    m.MapLeftKey("dise_id");
                    m.MapRightKey("dise_case_id");
                });

            modelBuilder.Entity<Disease>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Disease>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Disease>()
                .Property(e => e.DiseaseTypeId)
                .HasColumnName("dise_type_id");

            #endregion

            #region DiseaseCase

            modelBuilder.Entity<DiseaseCase>()
                .ToTable("tb_dise_case")
                .HasKey(e => e.Id)
                .HasRequired(d => d.Charge)
                .WithRequiredPrincipal(c => c.DiseaseCase);

            modelBuilder.Entity<DiseaseCase>()
                .HasMany(d => d.DiseaseCaseTabs)
                .WithRequired(d => d.DiseaseCase)
                .HasForeignKey(d => d.DiseaseCaseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DiseaseCase>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DiseaseCase>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<DiseaseCase>()
                .Property(e => e.Discription)
                .HasColumnName("desp")
                .HasMaxLength(3000);

            #endregion

            #region DiseaseCaseTab

            modelBuilder.Entity<DiseaseCaseTab>()
                .ToTable("tb_dise_case_tab")
                .HasKey(e => e.Id)
                .HasMany(d => d.Analyses)
                .WithMany(a => a.DiseaseCaseTabs)
                .Map(m =>
                {
                    m.ToTable("ref_dctab_analysis");
                    m.MapLeftKey("dise_case_tab_id");
                    m.MapRightKey("analysis_id");
                });

            modelBuilder.Entity<DiseaseCaseTab>()
                .HasMany(d => d.Drugs)
                .WithMany(d => d.DiseaseCaseTabs)
                .Map(m =>
                {
                    m.ToTable("ref_dctab_drug");
                    m.MapLeftKey("dise_case_tab_id");
                    m.MapRightKey("drug_id");
                });

            modelBuilder.Entity<DiseaseCaseTab>()
                .HasMany(d => d.Texts)
                .WithMany(t => t.RelatedDiseaseCaseTabs)
                .Map(m =>
                {
                    m.ToTable("ref_dctab_text");
                    m.MapLeftKey("dise_case_tab_id");
                    m.MapRightKey("text_id");
                });

            modelBuilder.Entity<DiseaseCaseTab>()
                .HasMany(d => d.Pictures)
                .WithMany(p => p.RelatedDiseaseCaseTabs)
                .Map(m =>
                {
                    m.ToTable("ref_dctab_pic");
                    m.MapLeftKey("dise_case_tab_id");
                    m.MapRightKey("pic_id");
                });

            modelBuilder.Entity<DiseaseCaseTab>()
                .HasMany(d => d.Videos)
                .WithMany(v => v.RelatedDiseaseCaseTabs)
                .Map(m =>
                {
                    m.ToTable("ref_dctab_video");
                    m.MapLeftKey("dise_case_tab_id");
                    m.MapRightKey("video_id");
                });

            modelBuilder.Entity<DiseaseCaseTab>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DiseaseCaseTab>()
                .Property(e => e.Index)
                .HasColumnName("index")
                .IsRequired();

            modelBuilder.Entity<DiseaseCaseTab>()
                .Property(e => e.DiseaseCaseId)
                .HasColumnName("dise_case_id");

            #endregion

            #region DiseType

            modelBuilder.Entity<DiseaseType>()
                .ToTable("tb_dise_type")
                .HasKey(e => e.Id)
                .HasMany(d => d.Diseases)
                .WithRequired(d => d.DiseaseType)
                .HasForeignKey(d => d.DiseaseTypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DiseaseType>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DiseaseType>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            #endregion

            #region Drug

            modelBuilder.Entity<Drug>()
                .ToTable("tb_drugs")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Drug>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Drug>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Drug>()
                .Property(e => e.Price)
                .HasColumnName("price")
                .IsRequired();

            #endregion

            #region Instrument

            modelBuilder.Entity<Instrument>()
                .ToTable("tb_instruments")
                .HasKey(e => e.Id)
                .HasMany(i => i.Texts)
                .WithMany(t => t.RelatedInstruments)
                .Map(m =>
                {
                    m.ToTable("ref_instr_text");
                    m.MapLeftKey("instr_id");
                    m.MapRightKey("text_id");
                });

            modelBuilder.Entity<Instrument>()
                .HasMany(i => i.Pictures)
                .WithMany(p => p.RelatedInstruments)
                .Map(m =>
                {
                    m.ToTable("ref_instr_pic");
                    m.MapLeftKey("instr_id");
                    m.MapRightKey("pic_id");
                });

            modelBuilder.Entity<Instrument>()
                .HasMany(i => i.Videos)
                .WithMany(v => v.RelatedInstruments)
                .Map(m =>
                {
                    m.ToTable("ref_instr_video");
                    m.MapLeftKey("instr_id");
                    m.MapRightKey("video_id");
                });

            modelBuilder.Entity<Instrument>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Instrument>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Instrument>()
                .Property(e => e.Description)
                .HasColumnName("desp")
                .HasMaxLength(3000);

            modelBuilder.Entity<Instrument>()
                .Property(e => e.ModelUrl)
                .HasColumnName("model_url")
                .HasMaxLength(3000);

            #endregion

            #region Picture

            modelBuilder.Entity<Picture>()
                .ToTable("tb_pics")
                .HasKey(e => e.Id);

            //×ÔÔö³¤
            modelBuilder.Entity<Picture>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Picture>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Picture>()
                .Property(e => e.Description)
                .HasColumnName("desp")
                .HasMaxLength(3000);

            modelBuilder.Entity<Picture>()
                .Property(e => e.Url)
                .HasColumnName("url")
                .HasMaxLength(3000)
                .IsRequired();

            modelBuilder.Entity<Picture>()
                .Property(e => e.RelatedClinicId)
                .HasColumnName("clinic_id");

            #endregion

            #region Roles

            modelBuilder.Entity<Role>()
                .ToTable("tb_roles")
                .HasKey(e => e.Id)
                .HasMany(r => r.Clinics)
                .WithMany(c => c.Roles)
                .Map(m =>
                {
                    m.ToTable("ref_role_clinic");
                    m.MapLeftKey("role_id");
                    m.MapRightKey("clinic_id");
                });

            modelBuilder.Entity<Role>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(e => e.Description)
                .HasColumnName("desp")
                .HasMaxLength(3000);

            modelBuilder.Entity<Role>()
                .Property(e => e.RolePicUrl)
                .HasColumnName("role_pic_url")
                .HasMaxLength(3000);

            #endregion

            #region Text

            modelBuilder.Entity<Text>()
                .ToTable("tb_texts")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Text>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Text>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Text>()
                .Property(e => e.Content)
                .HasColumnName("content")
                .HasMaxLength(3000);

            modelBuilder.Entity<Text>()
                .Property(e => e.RelatedClinicId)
                .HasColumnName("clinic_id");

            #endregion

            #region User

            modelBuilder.Entity<User>()
                .ToTable("tb_users")
                .HasKey(e => e.Id);

            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<User>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .HasColumnName("password")
                .HasMaxLength(60)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.Authority)
                .HasColumnName("authority")
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(e => e.IsToRememberMe)
                .HasColumnName("is_to_remember")
                .IsRequired();

            #endregion

            #region Videos

            modelBuilder.Entity<Video>()
                .ToTable("tb_videos")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Video>()
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Video>()
                .Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            modelBuilder.Entity<Video>()
                .Property(e => e.Description)
                .HasColumnName("desp")
                .HasMaxLength(3000);

            modelBuilder.Entity<Video>()
                .Property(e => e.Url)
                .HasColumnName("url")
                .HasMaxLength(3000);

            modelBuilder.Entity<Video>()
                .Property(e => e.RelatedClinicId)
                .HasColumnName("clinic_id");

            #endregion

            #region RPRecords

            modelBuilder.Entity<RPRecord>()
                .ToTable("tb_role_play_records")
                .HasKey(e => new { e.RoleId, e.ClinicId })
                .HasMany(e => e.Pictures)
                .WithMany(p => p.RelatedRPRecords)
                .Map(m =>
                {
                    m.ToTable("ref_rprec_pic");
                    m.MapLeftKey("role_id", "clinic_id");
                    m.MapRightKey("pic_id");
                });

            modelBuilder.Entity<RPRecord>()
                .HasMany(e => e.Videos)
                .WithMany(v => v.RelatedRPRecords)
                .Map(m =>
                {
                    m.ToTable("ref_rprec_video");
                    m.MapLeftKey("role_id", "clinic_id");
                    m.MapRightKey("video_id");
                });

            modelBuilder.Entity<RPRecord>()
                .Property(e => e.ClinicId)
                .HasColumnName("clinic_id");

            modelBuilder.Entity<RPRecord>()
                .Property(e => e.RoleId)
                .HasColumnName("role_id");

            modelBuilder.Entity<RPRecord>()
                .Property(e => e.Description)
                .HasColumnName("desp")
                .HasMaxLength(3000);

            #endregion
        }
    }
}
