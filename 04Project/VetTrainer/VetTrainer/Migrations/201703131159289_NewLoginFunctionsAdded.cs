namespace VetTrainer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class NewLoginFunctionsAdded : DbMigration
    {
        public override void Up()
        {
            //RenameColumn(table: "dbo.tb_users", name: "UserId", newName: "user_id");
            AddColumn("dbo.tb_users", "is_to_remember", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.tb_users", "is_to_remember");
            //RenameColumn(table: "dbo.tb_users", name: "user_id", newName: "UserId");
        }
    }
}
