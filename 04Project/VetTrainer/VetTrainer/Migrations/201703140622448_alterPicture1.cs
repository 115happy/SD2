namespace VetTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterPicture1 : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "vet_app.tbref_disecasetab_analyses", newSchema: "dbo");
            DropForeignKey("vet_app.tbref_disecasetab_analyses", "analysis_id", "vet_app.tb_analyses");
            DropForeignKey("vet_app.tbref_disecasetab_pics", "pic_id", "vet_app.tb_pics");
            DropForeignKey("vet_app.tbref_instruments_pics", "pic_id", "vet_app.tb_pics");
            DropForeignKey("vet_app.tbref_roles_clinics_pics", "pic_id", "vet_app.tb_pics");
            DropForeignKey("vet_app.tbref_roles_clinics_pics", "role_id", "vet_app.tb_roles");
            DropForeignKey("vet_app.tbref_roles_clinics_texts", "role_id", "vet_app.tb_roles");
            DropForeignKey("vet_app.tbref_roles_clinics_videos", "role_id", "vet_app.tb_roles");
            DropIndex("dbo.tbref_disecasetab_analyses", new[] { "analysis_id" });
            DropIndex("vet_app.tbref_disecasetab_pics", new[] { "pic_id" });
            DropIndex("vet_app.tbref_instruments_pics", new[] { "pic_id" });
            DropIndex("vet_app.tbref_roles_clinics_pics", new[] { "pic_id" });
            CreateTable(
                "dbo.tb_analyses",
                c => new
                    {
                        AnalysisId = c.Int(nullable: false, identity: true),
                        analysis_id = c.String(nullable: false, maxLength: 45, unicode: false),
                        AnalysisAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AnalysisId);
            
            CreateTable(
                "dbo.tb_pics",
                c => new
                    {
                        pic_id = c.Int(nullable: false, identity: true),
                        pic_name = c.String(nullable: false, maxLength: 45, unicode: false),
                        pic_url = c.String(nullable: false, maxLength: 3000, unicode: false),
                        tb_clinics_clinic_id = c.Int(),
                    })
                .PrimaryKey(t => t.pic_id)
                .ForeignKey("vet_app.tb_clinics", t => t.tb_clinics_clinic_id)
                .Index(t => t.tb_clinics_clinic_id);
            
            AddColumn("dbo.tbref_disecasetab_analyses", "tb_analyses_AnalysisId", c => c.Int(nullable: false));
            AddColumn("vet_app.tbref_disecasetab_pics", "tb_pics_PicId", c => c.Int());
            AddColumn("vet_app.tbref_instruments_pics", "tb_pics_PicId", c => c.Int());
            AddColumn("vet_app.tb_instruments", "tb_clinics_clinic_id", c => c.Int());
            AddColumn("vet_app.tb_clinics", "MyProperty_PicId", c => c.Int());
            AddColumn("vet_app.tbref_roles_clinics_pics", "tb_pics_PicId", c => c.Int());
            AddColumn("dbo.tb_users", "user_name", c => c.String(nullable: false, maxLength: 45, unicode: false));
            CreateIndex("dbo.tbref_disecasetab_analyses", "tb_analyses_AnalysisId");
            CreateIndex("vet_app.tbref_disecasetab_pics", "tb_pics_PicId");
            CreateIndex("vet_app.tb_instruments", "tb_clinics_clinic_id");
            CreateIndex("vet_app.tb_clinics", "MyProperty_PicId");
            CreateIndex("vet_app.tbref_roles_clinics_pics", "tb_pics_PicId");
            CreateIndex("vet_app.tbref_instruments_pics", "tb_pics_PicId");
            AddForeignKey("vet_app.tb_instruments", "tb_clinics_clinic_id", "vet_app.tb_clinics", "clinic_id");
            AddForeignKey("vet_app.tb_clinics", "MyProperty_PicId", "dbo.tb_pics", "pic_id");
            AddForeignKey("dbo.tbref_disecasetab_analyses", "tb_analyses_AnalysisId", "dbo.tb_analyses", "AnalysisId");
            AddForeignKey("vet_app.tbref_disecasetab_pics", "tb_pics_PicId", "dbo.tb_pics", "pic_id");
            AddForeignKey("vet_app.tbref_instruments_pics", "tb_pics_PicId", "dbo.tb_pics", "pic_id");
            AddForeignKey("vet_app.tbref_roles_clinics_pics", "tb_pics_PicId", "dbo.tb_pics", "pic_id");
            AddForeignKey("vet_app.tbref_roles_clinics_pics", "role_id", "vet_app.tb_roles", "role_id", cascadeDelete: true);
            AddForeignKey("vet_app.tbref_roles_clinics_texts", "role_id", "vet_app.tb_roles", "role_id", cascadeDelete: true);
            AddForeignKey("vet_app.tbref_roles_clinics_videos", "role_id", "vet_app.tb_roles", "role_id", cascadeDelete: true);
            DropColumn("dbo.tb_users", "username");
            DropTable("vet_app.tb_analyses");
            DropTable("vet_app.tb_pics");
        }
        
        public override void Down()
        {
            CreateTable(
                "vet_app.tb_pics",
                c => new
                    {
                        pic_id = c.Int(nullable: false, identity: true),
                        pic_name = c.String(nullable: false, maxLength: 45, unicode: false),
                        pic_url = c.String(nullable: false, maxLength: 3000, unicode: false),
                    })
                .PrimaryKey(t => t.pic_id);
            
            CreateTable(
                "vet_app.tb_analyses",
                c => new
                    {
                        analysis_id = c.Int(nullable: false, identity: true),
                        analysis_name = c.String(nullable: false, maxLength: 45, unicode: false),
                        analysis_amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.analysis_id);
            
            AddColumn("dbo.tb_users", "username", c => c.String(nullable: false, maxLength: 45, unicode: false));
            DropForeignKey("vet_app.tbref_roles_clinics_videos", "role_id", "vet_app.tb_roles");
            DropForeignKey("vet_app.tbref_roles_clinics_texts", "role_id", "vet_app.tb_roles");
            DropForeignKey("vet_app.tbref_roles_clinics_pics", "role_id", "vet_app.tb_roles");
            DropForeignKey("vet_app.tbref_roles_clinics_pics", "tb_pics_PicId", "dbo.tb_pics");
            DropForeignKey("vet_app.tbref_instruments_pics", "tb_pics_PicId", "dbo.tb_pics");
            DropForeignKey("vet_app.tbref_disecasetab_pics", "tb_pics_PicId", "dbo.tb_pics");
            DropForeignKey("dbo.tbref_disecasetab_analyses", "tb_analyses_AnalysisId", "dbo.tb_analyses");
            DropForeignKey("dbo.tb_pics", "tb_clinics_clinic_id", "vet_app.tb_clinics");
            DropForeignKey("vet_app.tb_clinics", "MyProperty_PicId", "dbo.tb_pics");
            DropForeignKey("vet_app.tb_instruments", "tb_clinics_clinic_id", "vet_app.tb_clinics");
            DropIndex("vet_app.tbref_instruments_pics", new[] { "tb_pics_PicId" });
            DropIndex("vet_app.tbref_roles_clinics_pics", new[] { "tb_pics_PicId" });
            DropIndex("vet_app.tb_clinics", new[] { "MyProperty_PicId" });
            DropIndex("vet_app.tb_instruments", new[] { "tb_clinics_clinic_id" });
            DropIndex("dbo.tb_pics", new[] { "tb_clinics_clinic_id" });
            DropIndex("vet_app.tbref_disecasetab_pics", new[] { "tb_pics_PicId" });
            DropIndex("dbo.tbref_disecasetab_analyses", new[] { "tb_analyses_AnalysisId" });
            DropColumn("dbo.tb_users", "user_name");
            DropColumn("vet_app.tbref_roles_clinics_pics", "tb_pics_PicId");
            DropColumn("vet_app.tb_clinics", "MyProperty_PicId");
            DropColumn("vet_app.tb_instruments", "tb_clinics_clinic_id");
            DropColumn("vet_app.tbref_instruments_pics", "tb_pics_PicId");
            DropColumn("vet_app.tbref_disecasetab_pics", "tb_pics_PicId");
            DropColumn("dbo.tbref_disecasetab_analyses", "tb_analyses_AnalysisId");
            DropTable("dbo.tb_pics");
            DropTable("dbo.tb_analyses");
            CreateIndex("vet_app.tbref_roles_clinics_pics", "pic_id");
            CreateIndex("vet_app.tbref_instruments_pics", "pic_id");
            CreateIndex("vet_app.tbref_disecasetab_pics", "pic_id");
            CreateIndex("dbo.tbref_disecasetab_analyses", "analysis_id");
            AddForeignKey("vet_app.tbref_roles_clinics_videos", "role_id", "vet_app.tb_roles", "role_id");
            AddForeignKey("vet_app.tbref_roles_clinics_texts", "role_id", "vet_app.tb_roles", "role_id");
            AddForeignKey("vet_app.tbref_roles_clinics_pics", "role_id", "vet_app.tb_roles", "role_id");
            AddForeignKey("vet_app.tbref_roles_clinics_pics", "pic_id", "vet_app.tb_pics", "pic_id");
            AddForeignKey("vet_app.tbref_instruments_pics", "pic_id", "vet_app.tb_pics", "pic_id");
            AddForeignKey("vet_app.tbref_disecasetab_pics", "pic_id", "vet_app.tb_pics", "pic_id");
            AddForeignKey("vet_app.tbref_disecasetab_analyses", "analysis_id", "vet_app.tb_analyses", "analysis_id");
            MoveTable(name: "dbo.tbref_disecasetab_analyses", newSchema: "vet_app");
        }
    }
}
