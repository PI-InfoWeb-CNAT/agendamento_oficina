namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimplifyUserTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.AspNetUsers", new[] { "Cpf" });
            AlterColumn("dbo.AspNetUsers", "Cpf", c => c.String(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.AspNetUsers", "Cpf", c => c.String(nullable: false, maxLength: 11));
            CreateIndex("dbo.AspNetUsers", "Cpf");
        }
    }
}
