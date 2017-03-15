using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace VetTrainer.Models.EntityConfigurations
{
    public class DiseaseCaseTabConfiguration : EntityTypeConfiguration<DiseaseCaseTab>
    {
        public DiseaseCaseTabConfiguration()
        {
            ToTable("tb_dise_case_tab");

            HasKey(e => e.Id);

            Property(e => e.Id)
                .HasColumnName("id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(e => e.Index)
                .HasColumnName("index")
                .IsRequired();

            Property(e => e.DiseaseCaseId)
                .HasColumnName("dise_case_id");

            HasMany(d => d.Analyses)
            .WithMany(a => a.DiseaseCaseTabs)
            .Map(m =>
            {
                m.ToTable("ref_dctab_analysis");
                m.MapLeftKey("dise_case_tab_id");
                m.MapRightKey("analysis_id");
            });

            HasMany(d => d.Drugs)
            .WithMany(d => d.DiseaseCaseTabs)
            .Map(m =>
            {
                m.ToTable("ref_dctab_drug");
                m.MapLeftKey("dise_case_tab_id");
                m.MapRightKey("drug_id");
            });

            HasMany(d => d.Texts)
            .WithMany(t => t.RelatedDiseaseCaseTabs)
            .Map(m =>
            {
                m.ToTable("ref_dctab_text");
                m.MapLeftKey("dise_case_tab_id");
                m.MapRightKey("text_id");
            });

            HasMany(d => d.Pictures)
            .WithMany(p => p.RelatedDiseaseCaseTabs)
            .Map(m =>
            {
                m.ToTable("ref_dctab_pic");
                m.MapLeftKey("dise_case_tab_id");
                m.MapRightKey("pic_id");
            });

            HasMany(d => d.Videos)
            .WithMany(v => v.RelatedDiseaseCaseTabs)
            .Map(m =>
            {
                m.ToTable("ref_dctab_video");
                m.MapLeftKey("dise_case_tab_id");
                m.MapRightKey("video_id");
            });
        }
    }
}