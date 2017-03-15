using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class DrugConfiguration : EntityTypeConfiguration<Drug>
    {
        public DrugConfiguration()
        {
            ToTable("tb_drugs");

            HasKey(e => e.Id);

            Property(e => e.Id)
            .HasColumnName("id")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(45)
            .IsRequired();

            Property(e => e.Price)
            .HasColumnName("price")
            .IsRequired();
        }
    }
}