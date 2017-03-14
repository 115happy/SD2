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

        public virtual DbSet<Analysis> tb_analyses { get; set; }
        public virtual DbSet<Charge> tb_charges { get; set; }
        public virtual DbSet<Clinic> tb_clinics { get; set; }
        public virtual DbSet<DiseaseCase> tb_dise_case { get; set; }
        public virtual DbSet<DiseaseCaseTab> tb_dise_case_tab { get; set; }
        public virtual DbSet<DiseaseType> tb_dise_type { get; set; }
        public virtual DbSet<Disease> tb_diseases { get; set; }
        public virtual DbSet<Drug> tb_drugs { get; set; }
        public virtual DbSet<Instrument> tb_instruments { get; set; }
        public virtual DbSet<Picture> tb_pics { get; set; }
        public virtual DbSet<Role> tb_roles { get; set; }
        public virtual DbSet<Text> tb_texts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Video> tb_videos { get; set; }
        public virtual DbSet<tbref_clinics_instruments> tbref_clinics_instruments { get; set; }
        public virtual DbSet<tbref_diseases_disecase> tbref_diseases_disecase { get; set; }
        public virtual DbSet<tbref_disecase_charges> tbref_disecase_charges { get; set; }
        public virtual DbSet<tbref_disecase_disecasetab> tbref_disecase_disecasetab { get; set; }
        public virtual DbSet<tbref_disecasetab_analyses> tbref_disecasetab_analyses { get; set; }
        public virtual DbSet<tbref_disecasetab_drugs> tbref_disecasetab_drugs { get; set; }
        public virtual DbSet<tbref_disecasetab_pics> tbref_disecasetab_pics { get; set; }
        public virtual DbSet<tbref_disecasetab_texts> tbref_disecasetab_texts { get; set; }
        public virtual DbSet<tbref_disecasetab_videos> tbref_disecasetab_videos { get; set; }
        public virtual DbSet<tbref_disetype_diseases> tbref_disetype_diseases { get; set; }
        public virtual DbSet<tbref_instruments_pics> tbref_instruments_pics { get; set; }
        public virtual DbSet<tbref_instruments_texts> tbref_instruments_texts { get; set; }
        public virtual DbSet<tbref_instruments_videos> tbref_instruments_videos { get; set; }
        public virtual DbSet<tbref_roles_clinics_pics> tbref_roles_clinics_pics { get; set; }
        public virtual DbSet<tbref_roles_clinics_texts> tbref_roles_clinics_texts { get; set; }
        public virtual DbSet<tbref_roles_clinics_videos> tbref_roles_clinics_videos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<VetAppDBContext>(null);

            //modelBuilder.HasDefaultSchema("vet_app");
            #region Analyses

            modelBuilder.Entity<Analysis>()
                .ToTable("tb_analyses")
                .HasKey(e => e.AnalysisId);

            modelBuilder.Entity<Analysis>()
                .Property(e => e.AnalysisId)
                .HasColumnName("analysis_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            modelBuilder.Entity<Analysis>()
                .Property(e => e.AnalysisName)
                .HasColumnName("analysis_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Analysis>()
                .Property(e => e.AnalysisAmount)
                .HasColumnName("analysis_amount")
                .IsRequired();

            #endregion

            #region Charge

            modelBuilder.Entity<Charge>()
                .ToTable("tb_charges")
                .HasKey(e => e.ChargeId);

            modelBuilder.Entity<Charge>()
                .Property(e => e.ChargeId)
                .HasColumnName("charge_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                
            modelBuilder.Entity<Charge>()
                .Property(e => e.ChargeName)
                .HasColumnName("charge_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Charge>()
                .Property(e => e.ChargeDescription)
                .HasColumnName("charge_desp")
                .HasMaxLength(3000)
                .IsUnicode(false);

            #endregion

            #region Clinic

            modelBuilder.Entity<Clinic>()
                .ToTable("tb_clinics")
                .HasKey(e => e.ClinicId);

            modelBuilder.Entity<Clinic>()
                .Property(e => e.ClinicId)
                .HasColumnName("clinic_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Clinic>()
                .Property(e => e.ClinicName)
                .HasColumnName("clinic_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Clinic>()
                .Property(e => e.ClinicDescription)
                .HasColumnName("clinic_desp")
                .HasMaxLength(3000)
                .IsUnicode(false);

            modelBuilder.Entity<Clinic>()
                .Property(e => e.ClinicPositionX)
                .HasColumnName("clinic_pos_x");

            modelBuilder.Entity<Clinic>()
                .Property(e => e.ClinicPositionY)
                .HasColumnName("clinic_pos_y");

            #endregion

            #region diseases

            modelBuilder.Entity<Disease>()
                .ToTable("tb_diseases")
                .HasKey(e => e.DiseaseId);

            modelBuilder.Entity<Disease>()
                .Property(e => e.DiseaseId)
                .HasColumnName("disease_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Disease>()
                .Property(e => e.DiseaseName)
                .HasColumnName("disease_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            #endregion

            #region DiseaseCase

            modelBuilder.Entity<DiseaseCase>()
                .ToTable("tb_dise_case")
                .HasKey(e => e.CaseId);

            modelBuilder.Entity<DiseaseCase>()
                .Property(e => e.CaseId)
                .HasColumnName("case_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DiseaseCase>()
                .Property(e => e.CaseName)
                .HasColumnName("case_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<DiseaseCase>()
                .Property(e => e.CaseDiscription)
                .HasColumnName("case_desp")
                .HasMaxLength(3000)
                .IsUnicode(false);

            #endregion


            #region DiseaseCaseTab

            modelBuilder.Entity<DiseaseCaseTab>()
                .ToTable("tb_dise_case_tab")
                .HasKey(e => e.TabId);

            modelBuilder.Entity<DiseaseCaseTab>()
                .Property(e => e.TabId)
                .HasColumnName("tab_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DiseaseCaseTab>()
                .Property(e => e.TabIndex)
                .HasColumnName("tab_index")
                .IsRequired()
                .IsUnicode(false);

            #endregion

            #region DiseType

            modelBuilder.Entity<DiseaseType>()
                .ToTable("tb_dise_type")
                .HasKey(e => e.TypeId);

            modelBuilder.Entity<DiseaseType>()
                .Property(e => e.TypeId)
                .HasColumnName("type_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<DiseaseType>()
                .Property(e => e.TypeName)
                .HasColumnName("type_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            #endregion


            #region Drug

            modelBuilder.Entity<Drug>()
                .ToTable("tb_drugs")
                .HasKey(e => e.DrugId);

            modelBuilder.Entity<Drug>()
                .Property(e => e.DrugId)
                .HasColumnName("drug_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Drug>()
                .Property(e => e.DrugName)
                .HasColumnName("drug_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Drug>()
                .Property(e => e.DrugPrice)
                .HasColumnName("drug_price")
                .IsRequired();

            #endregion

            #region instrument

            modelBuilder.Entity<Instrument>()
                .ToTable("tb_instruments")
                .HasKey(e => e.InstrumentId);

            modelBuilder.Entity<Instrument>()
                .Property(e => e.InstrumentId)
                .HasColumnName("instrument_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Instrument>()
                .Property(e => e.InstrumentName)
                .HasColumnName("instrument_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Instrument>()
                .Property(e => e.InstrumentDescription)
                .HasColumnName("instrument_desp")
                .HasMaxLength(3000)
                .IsUnicode(false);

            modelBuilder.Entity<Instrument>()
                .Property(e => e.ModelUrl)
                .HasColumnName("model_url")
                .HasMaxLength(3000)
                .IsUnicode(false);

            #endregion

            #region Picture

            modelBuilder.Entity<Picture>()
                .ToTable("tb_pics")
                .HasKey(e => e.PicId);
            
            //×ÔÔö³¤
            modelBuilder.Entity<Picture>()
                .Property(e => e.PicId)
                .HasColumnName("pic_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Picture>()
                .Property(e => e.PicName)
                .HasColumnName("pic_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Picture>()
                .Property(e => e.PicUrl)
                .HasColumnName("pic_url")
                .HasMaxLength(3000)
                .IsRequired()
                .IsUnicode(false);

            #endregion


            #region Roles

            modelBuilder.Entity<Role>()
                .ToTable("tb_roles")
                .HasKey(e => e.RoleId);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleId)
                .HasColumnName("role_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .HasColumnName("role_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RoleDescription)
                .HasColumnName("role_desp")
                .HasMaxLength(3000)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .Property(e => e.RolePicUrl)
                .HasColumnName("role_pic_url")
                .HasMaxLength(3000)
                .IsUnicode(false);

            #endregion

            #region text

            modelBuilder.Entity<Text>()
                .ToTable("tb_texts")
                .HasKey(e => e.TextId);

            modelBuilder.Entity<Text>()
                .Property(e => e.TextId)
                .HasColumnName("text_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Text>()
                .Property(e => e.TextName)
                .HasColumnName("text_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Text>()
                .Property(e => e.TextContent)
                .HasColumnName("text_content")
                .HasMaxLength(3000)
                .IsUnicode(false);

            #endregion

            #region user

            modelBuilder.Entity<User>()
                .ToTable("tb_users")
                .HasKey(b => b.UserId);

            modelBuilder.Entity<User>()
                .Property(e => e.UserId)
                .HasColumnName("user_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .HasColumnName("user_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .HasColumnName("password")
                .HasMaxLength(60)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Authority)
                .HasColumnName("authority")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.IsToRememberMe)
                .HasColumnName("is_to_remember")
                .IsRequired();

            #endregion

            #region Videos

            modelBuilder.Entity<Video>()
                .ToTable("tb_videos")
                .HasKey(e => e.VideoId);

            modelBuilder.Entity<Video>()
                .Property(e => e.VideoId)
                .HasColumnName("video_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Video>()
                .Property(e => e.VideoName)
                .HasColumnName("video_name")
                .HasMaxLength(45)
                .IsRequired()
                .IsUnicode(false);

            modelBuilder.Entity<Video>()
                .Property(e => e.VideoUrl)
                .HasColumnName("video_url")
                .HasMaxLength(3000)
                .IsUnicode(false);
        }
    }
}
