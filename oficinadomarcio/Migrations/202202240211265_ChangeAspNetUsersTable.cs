namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAspNetUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Cpf", c => c.String(maxLength: 11));
            AddColumn("dbo.AspNetUsers", "Nome", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "Telefone", c => c.String(maxLength: 15));
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(nullable: false, maxLength: 256));
            CreateIndex("dbo.AspNetUsers", "Email");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", new[] { "Email" });
            AlterColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            DropColumn("dbo.AspNetUsers", "Telefone");
            DropColumn("dbo.AspNetUsers", "Nome");
            DropColumn("dbo.AspNetUsers", "Cpf");
        }
    }
}
