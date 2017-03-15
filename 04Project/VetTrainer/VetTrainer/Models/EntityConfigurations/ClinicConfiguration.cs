using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class ClinicConfiguration : EntityTypeConfiguration<Clinic>
    {
        public ClinicConfiguration()
        {
            ToTable("tb_clinics");

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

            Property(e => e.PositionX)
                .HasColumnName("pos_x");

            Property(e => e.PositionY)
                .HasColumnName("pos_y");

            HasMany(c => c.Instruments)
                .WithMany(i => i.Clinics)
                .Map(m =>
                {
                    m.ToTable("ref_clinic_instr");
                    m.MapLeftKey("clinic_id");
                    m.MapRightKey("instr_id");
                });

            HasMany(c => c.Texts)
                .WithOptional(t => t.RelatedClinic)
                .HasForeignKey(t => t.RelatedClinicId)
                .WillCascadeOnDelete(false);

            HasMany(c => c.Pictures)
                .WithOptional(p => p.RelatedClinic)
                .HasForeignKey(p => p.RelatedClinicId)
                .WillCascadeOnDelete(false);

            HasMany(c => c.Videos)
                .WithOptional(v => v.RelatedClinic)
                .HasForeignKey(v => v.RelatedClinicId)
                .WillCascadeOnDelete(false);
        }
    }
}