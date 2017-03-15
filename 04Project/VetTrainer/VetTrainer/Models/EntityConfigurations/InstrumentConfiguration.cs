using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class InstrumentConfiguration : EntityTypeConfiguration<Instrument>
    {
        public InstrumentConfiguration()
        {
            ToTable("tb_instruments");

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

            Property(e => e.ModelUrl)
                 .HasColumnName("model_url")
                 .HasMaxLength(3000);

            HasMany(i => i.Texts)
               .WithMany(t => t.RelatedInstruments)
               .Map(m =>
               {
                   m.ToTable("ref_instr_text");
                   m.MapLeftKey("instr_id");
                   m.MapRightKey("text_id");
               });

            HasMany(i => i.Pictures)
            .WithMany(p => p.RelatedInstruments)
            .Map(m =>
            {
                m.ToTable("ref_instr_pic");
                m.MapLeftKey("instr_id");
                m.MapRightKey("pic_id");
            });

            HasMany(i => i.Videos)
            .WithMany(v => v.RelatedInstruments)
            .Map(m =>
            {
                m.ToTable("ref_instr_video");
                m.MapLeftKey("instr_id");
                m.MapRightKey("video_id");
            });
        }
    }
}