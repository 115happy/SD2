using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class RPRecordConfiguration : EntityTypeConfiguration<RPRecord>
    {
        public RPRecordConfiguration()
        {
            ToTable("tb_role_play_records");

            HasKey(e => new { e.RoleId, e.ClinicId });

            Property(e => e.ClinicId)
            .HasColumnName("clinic_id");

            Property(e => e.RoleId)
            .HasColumnName("role_id");

            Property(e => e.Description)
            .HasColumnName("desp")
            .HasMaxLength(3000);

            HasMany(e => e.Pictures)
             .WithMany(p => p.RelatedRPRecords)
             .Map(m =>
             {
                 m.ToTable("ref_rprec_pic");
                 m.MapLeftKey("role_id", "clinic_id");
                 m.MapRightKey("pic_id");
             });

            HasMany(e => e.Videos)
            .WithMany(v => v.RelatedRPRecords)
            .Map(m =>
            {
                m.ToTable("ref_rprec_video");
                m.MapLeftKey("role_id", "clinic_id");
                m.MapRightKey("video_id");
            });
        }
    }
}