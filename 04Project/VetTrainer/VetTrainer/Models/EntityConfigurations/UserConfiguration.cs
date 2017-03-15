using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("tb_users");

            HasKey(e => e.Id);

            Property(e => e.Id)
            .HasColumnName("id")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(45)
            .IsRequired();

            Property(e => e.Password)
            .HasColumnName("password")
            .HasMaxLength(60)
            .IsRequired();

            Property(e => e.Authority)
            .HasColumnName("authority")
            .IsRequired();

            Property(e => e.IsToRememberMe)
            .HasColumnName("is_to_remember")
            .IsRequired();
        }
    }
}