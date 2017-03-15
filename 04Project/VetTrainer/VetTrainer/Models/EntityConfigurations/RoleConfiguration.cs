using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("tb_roles");

            HasKey(e => e.Id);

            Property(e => e.Id)
            .HasColumnName("id")
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(45)
            .IsRequired();

            Property(e => e.Description)
            .HasColumnName("desp")
            .HasMaxLength(3000);

            Property(e => e.RolePicUrl)
            .HasColumnName("role_pic_url")
            .HasMaxLength(3000);

            HasMany(r => r.Clinics)
            .WithMany(c => c.Roles)
            .Map(m =>
            {
                m.ToTable("ref_role_clinic");
                m.MapLeftKey("role_id");
                m.MapRightKey("clinic_id");
            });
        }
    }
}