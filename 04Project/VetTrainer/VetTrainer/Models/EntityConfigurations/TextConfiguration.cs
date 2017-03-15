using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class TextConfiguration : EntityTypeConfiguration<Text>
    {
        public TextConfiguration()
        {
            ToTable("tb_texts");

            HasKey(e => e.Id);

            Property(e => e.Id)
            .HasColumnName("id")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(45)
            .IsRequired();

            Property(e => e.Content)
            .HasColumnName("content")
            .HasMaxLength(3000);

            Property(e => e.RelatedClinicId)
            .HasColumnName("clinic_id");
        }
    }
}