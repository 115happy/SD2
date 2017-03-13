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

        public virtual DbSet<tb_analyses> tb_analyses { get; set; }
        public virtual DbSet<tb_charges> tb_charges { get; set; }
        public virtual DbSet<tb_clinics> tb_clinics { get; set; }
        public virtual DbSet<tb_dise_case> tb_dise_case { get; set; }
        public virtual DbSet<tb_dise_case_tab> tb_dise_case_tab { get; set; }
        public virtual DbSet<tb_dise_type> tb_dise_type { get; set; }
        public virtual DbSet<tb_diseases> tb_diseases { get; set; }
        public virtual DbSet<tb_drugs> tb_drugs { get; set; }
        public virtual DbSet<tb_instruments> tb_instruments { get; set; }
        public virtual DbSet<tb_pics> tb_pics { get; set; }
        public virtual DbSet<tb_roles> tb_roles { get; set; }
        public virtual DbSet<tb_texts> tb_texts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<tb_videos> tb_videos { get; set; }
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

            modelBuilder.Entity<tb_analyses>()
                .Property(e => e.analysis_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_analyses>()
                .HasMany(e => e.tbref_disecasetab_analyses)
                .WithRequired(e => e.tb_analyses)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_charges>()
                .Property(e => e.charge_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_charges>()
                .Property(e => e.charge_desp)
                .IsUnicode(false);

            modelBuilder.Entity<tb_charges>()
                .HasMany(e => e.tbref_disecase_charges)
                .WithRequired(e => e.tb_charges)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_clinics>()
                .Property(e => e.clinic_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_clinics>()
                .Property(e => e.clinic_desp)
                .IsUnicode(false);

            modelBuilder.Entity<tb_clinics>()
                .HasMany(e => e.tbref_clinics_instruments)
                .WithRequired(e => e.tb_clinics)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_clinics>()
                .HasMany(e => e.tbref_roles_clinics_pics)
                .WithRequired(e => e.tb_clinics)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_clinics>()
                .HasMany(e => e.tbref_roles_clinics_texts)
                .WithRequired(e => e.tb_clinics)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_clinics>()
                .HasMany(e => e.tbref_roles_clinics_videos)
                .WithRequired(e => e.tb_clinics)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_dise_case>()
                .Property(e => e.case_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_dise_case>()
                .Property(e => e.case_desp)
                .IsUnicode(false);

            modelBuilder.Entity<tb_dise_case>()
                .HasMany(e => e.tbref_diseases_disecase)
                .WithRequired(e => e.tb_dise_case)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_dise_case>()
                .HasMany(e => e.tbref_disecase_disecasetab)
                .WithRequired(e => e.tb_dise_case)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_dise_case>()
                .HasMany(e => e.tbref_disecase_charges)
                .WithRequired(e => e.tb_dise_case)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_dise_case_tab>()
                .Property(e => e.tab_index)
                .IsUnicode(false);

            modelBuilder.Entity<tb_dise_case_tab>()
                .HasMany(e => e.tbref_disecase_disecasetab)
                .WithRequired(e => e.tb_dise_case_tab)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_dise_case_tab>()
                .HasMany(e => e.tbref_disecasetab_analyses)
                .WithRequired(e => e.tb_dise_case_tab)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_dise_case_tab>()
                .HasMany(e => e.tbref_disecasetab_drugs)
                .WithRequired(e => e.tb_dise_case_tab)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_dise_case_tab>()
                .HasMany(e => e.tbref_disecasetab_pics)
                .WithRequired(e => e.tb_dise_case_tab)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_dise_case_tab>()
                .HasMany(e => e.tbref_disecasetab_texts)
                .WithRequired(e => e.tb_dise_case_tab)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_dise_case_tab>()
                .HasMany(e => e.tbref_disecasetab_videos)
                .WithRequired(e => e.tb_dise_case_tab)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_dise_type>()
                .Property(e => e.type_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_dise_type>()
                .HasMany(e => e.tbref_disetype_diseases)
                .WithRequired(e => e.tb_dise_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_diseases>()
                .Property(e => e.disease_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_diseases>()
                .HasMany(e => e.tbref_diseases_disecase)
                .WithRequired(e => e.tb_diseases)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_diseases>()
                .HasMany(e => e.tbref_disetype_diseases)
                .WithRequired(e => e.tb_diseases)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_drugs>()
                .Property(e => e.drug_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_drugs>()
                .HasMany(e => e.tbref_disecasetab_drugs)
                .WithRequired(e => e.tb_drugs)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_instruments>()
                .Property(e => e.instument_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_instruments>()
                .Property(e => e.instrument_desp)
                .IsUnicode(false);

            modelBuilder.Entity<tb_instruments>()
                .Property(e => e.model_url)
                .IsUnicode(false);

            modelBuilder.Entity<tb_instruments>()
                .HasMany(e => e.tbref_clinics_instruments)
                .WithRequired(e => e.tb_instruments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_instruments>()
                .HasMany(e => e.tbref_instruments_pics)
                .WithRequired(e => e.tb_instruments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_instruments>()
                .HasMany(e => e.tbref_instruments_texts)
                .WithRequired(e => e.tb_instruments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_instruments>()
                .HasMany(e => e.tbref_instruments_videos)
                .WithRequired(e => e.tb_instruments)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_pics>()
                .Property(e => e.pic_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_pics>()
                .Property(e => e.pic_url)
                .IsUnicode(false);

            modelBuilder.Entity<tb_pics>()
                .HasMany(e => e.tbref_disecasetab_pics)
                .WithRequired(e => e.tb_pics)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_pics>()
                .HasMany(e => e.tbref_instruments_pics)
                .WithRequired(e => e.tb_pics)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_pics>()
                .HasMany(e => e.tbref_roles_clinics_pics)
                .WithRequired(e => e.tb_pics)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_roles>()
                .Property(e => e.role_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_roles>()
                .Property(e => e.role_desp)
                .IsUnicode(false);

            modelBuilder.Entity<tb_roles>()
                .Property(e => e.role_pic_url)
                .IsUnicode(false);

            modelBuilder.Entity<tb_roles>()
                .HasMany(e => e.tbref_roles_clinics_pics)
                .WithRequired(e => e.tb_roles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_roles>()
                .HasMany(e => e.tbref_roles_clinics_texts)
                .WithRequired(e => e.tb_roles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_roles>()
                .HasMany(e => e.tbref_roles_clinics_videos)
                .WithRequired(e => e.tb_roles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_texts>()
                .Property(e => e.text_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_texts>()
                .Property(e => e.text_content)
                .IsUnicode(false);

            modelBuilder.Entity<tb_texts>()
                .HasMany(e => e.tbref_disecasetab_texts)
                .WithRequired(e => e.tb_texts)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_texts>()
                .HasMany(e => e.tbref_instruments_texts)
                .WithRequired(e => e.tb_texts)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_texts>()
                .HasMany(e => e.tbref_roles_clinics_texts)
                .WithRequired(e => e.tb_texts)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .ToTable("tb_users")
                .HasKey(b => b.UserId);

            modelBuilder.Entity<User>()
                .Property(e => e.UserId)
                .HasColumnName("user_id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .HasColumnName("username")
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

            modelBuilder.Entity<tb_videos>()
                .Property(e => e.video_name)
                .IsUnicode(false);

            modelBuilder.Entity<tb_videos>()
                .Property(e => e.video_url)
                .IsUnicode(false);

            modelBuilder.Entity<tb_videos>()
                .HasMany(e => e.tbref_disecasetab_videos)
                .WithRequired(e => e.tb_videos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_videos>()
                .HasMany(e => e.tbref_instruments_videos)
                .WithRequired(e => e.tb_videos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tb_videos>()
                .HasMany(e => e.tbref_roles_clinics_videos)
                .WithRequired(e => e.tb_videos)
                .WillCascadeOnDelete(false);
        }
    }
}
