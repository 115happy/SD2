using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class DiseaseCaseConfiguration : EntityTypeConfiguration<DiseaseCase>
    {
        public DiseaseCaseConfiguration()
        {
            ToTable("tb_dise_case");

            HasKey(e => e.Id);

            Property(e => e.Id)
            .HasColumnName("id")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(45)
            .IsRequired();

            Property(e => e.Discription)
            .HasColumnName("desp")
            .HasMaxLength(3000);

            HasRequired(d => d.Charge)
               .WithRequiredPrincipal(c => c.DiseaseCase);

            HasMany(d => d.DiseaseCaseTabs)
            .WithRequired(d => d.DiseaseCase)
            .HasForeignKey(d => d.DiseaseCaseId)
            .WillCascadeOnDelete(false);
        }
    }
}