using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class DiseaseConfiguration : EntityTypeConfiguration<Disease>
    {
        public DiseaseConfiguration()
        {
            ToTable("tb_diseases");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
                .HasColumnName("name")
                .HasMaxLength(45)
                .IsRequired();

            Property(e => e.DiseaseTypeId)
                .HasColumnName("dise_type_id");

            HasMany(d => d.DiseaseCases)
                .WithMany(d => d.Diseases)
                .Map(m =>
                {
                    m.ToTable("ref_dise_dc");
                    m.MapLeftKey("dise_id");
                    m.MapRightKey("dise_case_id");
                });
        }
    }
}