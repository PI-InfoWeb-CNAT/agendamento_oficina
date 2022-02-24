namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactorUserTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Cpf", c => c.String(nullable: false, maxLength: 11));
            CreateIndex("dbo.AspNetUsers", "Cpf");
            DropColumn("dbo.AspNetUsers", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Role", c => c.String(nullable: false));
            DropIndex("dbo.AspNetUsers", new[] { "Cpf" });
            AlterColumn("dbo.AspNetUsers", "Cpf", c => c.String(maxLength: 11));
        }
    }
}
