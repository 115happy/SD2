namespace VetTrainer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using MySql.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using VetTrainer.Models.EntityConfigurations;
    using static VetTrainer.Views.Strings.Global;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public partial class VetAppDBContext : DbContext
    {
        public VetAppDBContext()
            : base($"name={ConnectionStringName}")
        {
        }

        public virtual DbSet<Analysis> Analyses { get; set; }
        public virtual DbSet<Charge> Charges { get; set; }
        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<Disease> Diseases { get; set; }
        public virtual DbSet<DiseaseCase> DiseaseCases { get; set; }
        public virtual DbSet<DiseaseCaseTab> DiseaseCaseTabs { get; set; }
        public virtual DbSet<DiseaseType> DiseaseType { get; set; }
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
            modelBuilder.Configurations.Add(new AnalysisConfiguration());
            modelBuilder.Configurations.Add(new ChargeConfiguration());
            modelBuilder.Configurations.Add(new ClinicConfiguration());
            modelBuilder.Configurations.Add(new DiseaseConfiguration());
            modelBuilder.Configurations.Add(new DiseaseCaseConfiguration());
            modelBuilder.Configurations.Add(new DiseaseCaseTabConfiguration());
            modelBuilder.Configurations.Add(new DiseaseTypeConfiguration());
            modelBuilder.Configurations.Add(new DrugConfiguration());
            modelBuilder.Configurations.Add(new InstrumentConfiguration());
            modelBuilder.Configurations.Add(new PictureConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new TextConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new VideoConfiguration());
            modelBuilder.Configurations.Add(new RPRecordConfiguration());
        }
    }
}
