using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class DiseaseTypeConfiguration : EntityTypeConfiguration<DiseaseType>
    {
        public DiseaseTypeConfiguration()
        {
            ToTable("tb_dise_type");

            HasKey(e => e.Id);

            Property(e => e.Id)
            .HasColumnName("id")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(45)
            .IsRequired();

            HasMany(d => d.Diseases)
            .WithRequired(d => d.DiseaseType)
            .HasForeignKey(d => d.DiseaseTypeId)
            .WillCascadeOnDelete(false);
        }
    }
}