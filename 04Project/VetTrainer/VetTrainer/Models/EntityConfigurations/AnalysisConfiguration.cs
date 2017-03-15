using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class AnalysisConfiguration : EntityTypeConfiguration<Analysis>
    {
        public AnalysisConfiguration()
        {
            ToTable("tb_analyses");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(e => e.Name)
                 .HasColumnName("name")
                 .HasMaxLength(45)
                 .IsRequired();

            Property(e => e.Amount)
                 .HasColumnName("amount")
                 .IsRequired();
        }
    }
}