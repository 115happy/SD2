namespace VetTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_analyses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tb_dise_case_tab",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        index = c.String(nullable: false, unicode: false),
                        dise_case_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tb_dise_case", t => t.dise_case_id)
                .Index(t => t.dise_case_id);
            
            CreateTable(
                "dbo.tb_dise_case",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        desp = c.String(maxLength: 3000, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tb_charges",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        desp = c.String(maxLength: 3000, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tb_dise_case", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.tb_diseases",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        dise_type_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tb_dise_type", t => t.dise_type_id)
                .Index(t => t.dise_type_id);
            
            CreateTable(
                "dbo.tb_dise_type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tb_drugs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tb_pics",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        url = c.String(nullable: false, maxLength: 3000, storeType: "nvarchar"),
                        desp = c.String(maxLength: 3000, storeType: "nvarchar"),
                        clinic_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tb_clinics", t => t.clinic_id)
                .Index(t => t.clinic_id);
            
            CreateTable(
                "dbo.tb_clinics",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        desp = c.String(maxLength: 3000, storeType: "nvarchar"),
                        pos_x = c.Decimal(precision: 18, scale: 2),
                        pos_y = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tb_instruments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        desp = c.String(maxLength: 3000, storeType: "nvarchar"),
                        model_url = c.String(maxLength: 3000, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tb_texts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        content = c.String(maxLength: 3000, storeType: "nvarchar"),
                        clinic_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tb_clinics", t => t.clinic_id)
                .Index(t => t.clinic_id);
            
            CreateTable(
                "dbo.tb_videos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        url = c.String(maxLength: 3000, storeType: "nvarchar"),
                        desp = c.String(maxLength: 3000, storeType: "nvarchar"),
                        clinic_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tb_clinics", t => t.clinic_id)
                .Index(t => t.clinic_id);
            
            CreateTable(
                "dbo.tb_role_play_records",
                c => new
                    {
                        role_id = c.Int(nullable: false),
                        clinic_id = c.Int(nullable: false),
                        desp = c.String(maxLength: 3000, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.role_id, t.clinic_id })
                .ForeignKey("dbo.tb_clinics", t => t.clinic_id, cascadeDelete: true)
                .ForeignKey("dbo.tb_roles", t => t.role_id, cascadeDelete: true)
                .Index(t => t.role_id)
                .Index(t => t.clinic_id);
            
            CreateTable(
                "dbo.tb_roles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        desp = c.String(maxLength: 3000, storeType: "nvarchar"),
                        role_pic_url = c.String(maxLength: 3000, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tb_users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 45, storeType: "nvarchar"),
                        password = c.String(nullable: false, maxLength: 60, storeType: "nvarchar"),
                        authority = c.Int(nullable: false),
                        is_to_remember = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ref_dctab_analysis",
                c => new
                    {
                        dise_case_tab_id = c.Int(nullable: false),
                        analysis_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.dise_case_tab_id, t.analysis_id })
                .ForeignKey("dbo.tb_dise_case_tab", t => t.dise_case_tab_id, cascadeDelete: true)
                .ForeignKey("dbo.tb_analyses", t => t.analysis_id, cascadeDelete: true)
                .Index(t => t.dise_case_tab_id)
                .Index(t => t.analysis_id);
            
            CreateTable(
                "dbo.ref_dise_dc",
                c => new
                    {
                        dise_id = c.Int(nullable: false),
                        dise_case_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.dise_id, t.dise_case_id })
                .ForeignKey("dbo.tb_diseases", t => t.dise_id, cascadeDelete: true)
                .ForeignKey("dbo.tb_dise_case", t => t.dise_case_id, cascadeDelete: true)
                .Index(t => t.dise_id)
                .Index(t => t.dise_case_id);
            
            CreateTable(
                "dbo.ref_dctab_drug",
                c => new
                    {
                        dise_case_tab_id = c.Int(nullable: false),
                        drug_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.dise_case_tab_id, t.drug_id })
                .ForeignKey("dbo.tb_dise_case_tab", t => t.dise_case_tab_id, cascadeDelete: true)
                .ForeignKey("dbo.tb_drugs", t => t.drug_id, cascadeDelete: true)
                .Index(t => t.dise_case_tab_id)
                .Index(t => t.drug_id);
            
            CreateTable(
                "dbo.ref_instr_pic",
                c => new
                    {
                        instr_id = c.Int(nullable: false),
                        pic_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.instr_id, t.pic_id })
                .ForeignKey("dbo.tb_instruments", t => t.instr_id, cascadeDelete: true)
                .ForeignKey("dbo.tb_pics", t => t.pic_id, cascadeDelete: true)
                .Index(t => t.instr_id)
                .Index(t => t.pic_id);
            
            CreateTable(
                "dbo.ref_instr_text",
                c => new
                    {
                        instr_id = c.Int(nullable: false),
                        text_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.instr_id, t.text_id })
                .ForeignKey("dbo.tb_instruments", t => t.instr_id, cascadeDelete: true)
                .ForeignKey("dbo.tb_texts", t => t.text_id, cascadeDelete: true)
                .Index(t => t.instr_id)
                .Index(t => t.text_id);
            
            CreateTable(
                "dbo.ref_rprec_pic",
                c => new
                    {
                        role_id = c.Int(nullable: false),
                        clinic_id = c.Int(nullable: false),
                        pic_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.role_id, t.clinic_id, t.pic_id })
                .ForeignKey("dbo.tb_role_play_records", t => new { t.role_id, t.clinic_id }, cascadeDelete: true)
                .ForeignKey("dbo.tb_pics", t => t.pic_id, cascadeDelete: true)
                .Index(t => new { t.role_id, t.clinic_id })
                .Index(t => t.pic_id);
            
            CreateTable(
                "dbo.ref_role_clinic",
                c => new
                    {
                        role_id = c.Int(nullable: false),
                        clinic_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.role_id, t.clinic_id })
                .ForeignKey("dbo.tb_roles", t => t.role_id, cascadeDelete: true)
                .ForeignKey("dbo.tb_clinics", t => t.clinic_id, cascadeDelete: true)
                .Index(t => t.role_id)
                .Index(t => t.clinic_id);
            
            CreateTable(
                "dbo.ref_rprec_video",
                c => new
                    {
                        role_id = c.Int(nullable: false),
                        clinic_id = c.Int(nullable: false),
                        video_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.role_id, t.clinic_id, t.video_id })
                .ForeignKey("dbo.tb_role_play_records", t => new { t.role_id, t.clinic_id }, cascadeDelete: true)
                .ForeignKey("dbo.tb_videos", t => t.video_id, cascadeDelete: true)
                .Index(t => new { t.role_id, t.clinic_id })
                .Index(t => t.video_id);
            
            CreateTable(
                "dbo.ref_instr_video",
                c => new
                    {
                        instr_id = c.Int(nullable: false),
                        video_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.instr_id, t.video_id })
                .ForeignKey("dbo.tb_instruments", t => t.instr_id, cascadeDelete: true)
                .ForeignKey("dbo.tb_videos", t => t.video_id, cascadeDelete: true)
                .Index(t => t.instr_id)
                .Index(t => t.video_id);
            
            CreateTable(
                "dbo.ref_clinic_instr",
                c => new
                    {
                        clinic_id = c.Int(nullable: false),
                        instr_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.clinic_id, t.instr_id })
                .ForeignKey("dbo.tb_clinics", t => t.clinic_id, cascadeDelete: true)
                .ForeignKey("dbo.tb_instruments", t => t.instr_id, cascadeDelete: true)
                .Index(t => t.clinic_id)
                .Index(t => t.instr_id);
            
            CreateTable(
                "dbo.ref_dctab_pic",
                c => new
                    {
                        dise_case_tab_id = c.Int(nullable: false),
                        pic_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.dise_case_tab_id, t.pic_id })
                .ForeignKey("dbo.tb_dise_case_tab", t => t.dise_case_tab_id, cascadeDelete: true)
                .ForeignKey("dbo.tb_pics", t => t.pic_id, cascadeDelete: true)
                .Index(t => t.dise_case_tab_id)
                .Index(t => t.pic_id);
            
            CreateTable(
                "dbo.ref_dctab_text",
                c => new
                    {
                        dise_case_tab_id = c.Int(nullable: false),
                        text_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.dise_case_tab_id, t.text_id })
                .ForeignKey("dbo.tb_dise_case_tab", t => t.dise_case_tab_id, cascadeDelete: true)
                .ForeignKey("dbo.tb_texts", t => t.text_id, cascadeDelete: true)
                .Index(t => t.dise_case_tab_id)
                .Index(t => t.text_id);
            
            CreateTable(
                "dbo.ref_dctab_video",
                c => new
                    {
                        dise_case_tab_id = c.Int(nullable: false),
                        video_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.dise_case_tab_id, t.video_id })
                .ForeignKey("dbo.tb_dise_case_tab", t => t.dise_case_tab_id, cascadeDelete: true)
                .ForeignKey("dbo.tb_videos", t => t.video_id, cascadeDelete: true)
                .Index(t => t.dise_case_tab_id)
                .Index(t => t.video_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ref_dctab_video", "video_id", "dbo.tb_videos");
            DropForeignKey("dbo.ref_dctab_video", "dise_case_tab_id", "dbo.tb_dise_case_tab");
            DropForeignKey("dbo.ref_dctab_text", "text_id", "dbo.tb_texts");
            DropForeignKey("dbo.ref_dctab_text", "dise_case_tab_id", "dbo.tb_dise_case_tab");
            DropForeignKey("dbo.ref_dctab_pic", "pic_id", "dbo.tb_pics");
            DropForeignKey("dbo.ref_dctab_pic", "dise_case_tab_id", "dbo.tb_dise_case_tab");
            DropForeignKey("dbo.tb_videos", "clinic_id", "dbo.tb_clinics");
            DropForeignKey("dbo.tb_texts", "clinic_id", "dbo.tb_clinics");
            DropForeignKey("dbo.tb_pics", "clinic_id", "dbo.tb_clinics");
            DropForeignKey("dbo.ref_clinic_instr", "instr_id", "dbo.tb_instruments");
            DropForeignKey("dbo.ref_clinic_instr", "clinic_id", "dbo.tb_clinics");
            DropForeignKey("dbo.ref_instr_video", "video_id", "dbo.tb_videos");
            DropForeignKey("dbo.ref_instr_video", "instr_id", "dbo.tb_instruments");
            DropForeignKey("dbo.ref_rprec_video", "video_id", "dbo.tb_videos");
            DropForeignKey("dbo.ref_rprec_video", new[] { "role_id", "clinic_id" }, "dbo.tb_role_play_records");
            DropForeignKey("dbo.tb_role_play_records", "role_id", "dbo.tb_roles");
            DropForeignKey("dbo.ref_role_clinic", "clinic_id", "dbo.tb_clinics");
            DropForeignKey("dbo.ref_role_clinic", "role_id", "dbo.tb_roles");
            DropForeignKey("dbo.ref_rprec_pic", "pic_id", "dbo.tb_pics");
            DropForeignKey("dbo.ref_rprec_pic", new[] { "role_id", "clinic_id" }, "dbo.tb_role_play_records");
            DropForeignKey("dbo.tb_role_play_records", "clinic_id", "dbo.tb_clinics");
            DropForeignKey("dbo.ref_instr_text", "text_id", "dbo.tb_texts");
            DropForeignKey("dbo.ref_instr_text", "instr_id", "dbo.tb_instruments");
            DropForeignKey("dbo.ref_instr_pic", "pic_id", "dbo.tb_pics");
            DropForeignKey("dbo.ref_instr_pic", "instr_id", "dbo.tb_instruments");
            DropForeignKey("dbo.ref_dctab_drug", "drug_id", "dbo.tb_drugs");
            DropForeignKey("dbo.ref_dctab_drug", "dise_case_tab_id", "dbo.tb_dise_case_tab");
            DropForeignKey("dbo.tb_diseases", "dise_type_id", "dbo.tb_dise_type");
            DropForeignKey("dbo.ref_dise_dc", "dise_case_id", "dbo.tb_dise_case");
            DropForeignKey("dbo.ref_dise_dc", "dise_id", "dbo.tb_diseases");
            DropForeignKey("dbo.tb_dise_case_tab", "dise_case_id", "dbo.tb_dise_case");
            DropForeignKey("dbo.tb_charges", "id", "dbo.tb_dise_case");
            DropForeignKey("dbo.ref_dctab_analysis", "analysis_id", "dbo.tb_analyses");
            DropForeignKey("dbo.ref_dctab_analysis", "dise_case_tab_id", "dbo.tb_dise_case_tab");
            DropIndex("dbo.ref_dctab_video", new[] { "video_id" });
            DropIndex("dbo.ref_dctab_video", new[] { "dise_case_tab_id" });
            DropIndex("dbo.ref_dctab_text", new[] { "text_id" });
            DropIndex("dbo.ref_dctab_text", new[] { "dise_case_tab_id" });
            DropIndex("dbo.ref_dctab_pic", new[] { "pic_id" });
            DropIndex("dbo.ref_dctab_pic", new[] { "dise_case_tab_id" });
            DropIndex("dbo.ref_clinic_instr", new[] { "instr_id" });
            DropIndex("dbo.ref_clinic_instr", new[] { "clinic_id" });
            DropIndex("dbo.ref_instr_video", new[] { "video_id" });
            DropIndex("dbo.ref_instr_video", new[] { "instr_id" });
            DropIndex("dbo.ref_rprec_video", new[] { "video_id" });
            DropIndex("dbo.ref_rprec_video", new[] { "role_id", "clinic_id" });
            DropIndex("dbo.ref_role_clinic", new[] { "clinic_id" });
            DropIndex("dbo.ref_role_clinic", new[] { "role_id" });
            DropIndex("dbo.ref_rprec_pic", new[] { "pic_id" });
            DropIndex("dbo.ref_rprec_pic", new[] { "role_id", "clinic_id" });
            DropIndex("dbo.ref_instr_text", new[] { "text_id" });
            DropIndex("dbo.ref_instr_text", new[] { "instr_id" });
            DropIndex("dbo.ref_instr_pic", new[] { "pic_id" });
            DropIndex("dbo.ref_instr_pic", new[] { "instr_id" });
            DropIndex("dbo.ref_dctab_drug", new[] { "drug_id" });
            DropIndex("dbo.ref_dctab_drug", new[] { "dise_case_tab_id" });
            DropIndex("dbo.ref_dise_dc", new[] { "dise_case_id" });
            DropIndex("dbo.ref_dise_dc", new[] { "dise_id" });
            DropIndex("dbo.ref_dctab_analysis", new[] { "analysis_id" });
            DropIndex("dbo.ref_dctab_analysis", new[] { "dise_case_tab_id" });
            DropIndex("dbo.tb_role_play_records", new[] { "clinic_id" });
            DropIndex("dbo.tb_role_play_records", new[] { "role_id" });
            DropIndex("dbo.tb_videos", new[] { "clinic_id" });
            DropIndex("dbo.tb_texts", new[] { "clinic_id" });
            DropIndex("dbo.tb_pics", new[] { "clinic_id" });
            DropIndex("dbo.tb_diseases", new[] { "dise_type_id" });
            DropIndex("dbo.tb_charges", new[] { "id" });
            DropIndex("dbo.tb_dise_case_tab", new[] { "dise_case_id" });
            DropTable("dbo.ref_dctab_video");
            DropTable("dbo.ref_dctab_text");
            DropTable("dbo.ref_dctab_pic");
            DropTable("dbo.ref_clinic_instr");
            DropTable("dbo.ref_instr_video");
            DropTable("dbo.ref_rprec_video");
            DropTable("dbo.ref_role_clinic");
            DropTable("dbo.ref_rprec_pic");
            DropTable("dbo.ref_instr_text");
            DropTable("dbo.ref_instr_pic");
            DropTable("dbo.ref_dctab_drug");
            DropTable("dbo.ref_dise_dc");
            DropTable("dbo.ref_dctab_analysis");
            DropTable("dbo.tb_users");
            DropTable("dbo.tb_roles");
            DropTable("dbo.tb_role_play_records");
            DropTable("dbo.tb_videos");
            DropTable("dbo.tb_texts");
            DropTable("dbo.tb_instruments");
            DropTable("dbo.tb_clinics");
            DropTable("dbo.tb_pics");
            DropTable("dbo.tb_drugs");
            DropTable("dbo.tb_dise_type");
            DropTable("dbo.tb_diseases");
            DropTable("dbo.tb_charges");
            DropTable("dbo.tb_dise_case");
            DropTable("dbo.tb_dise_case_tab");
            DropTable("dbo.tb_analyses");
        }
    }
}
