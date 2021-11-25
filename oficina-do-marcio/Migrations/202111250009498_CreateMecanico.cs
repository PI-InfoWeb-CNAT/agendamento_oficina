namespace oficina_do_marcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMecanico : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mecanicoes",
                c => new
                    {
                        Cpf = c.String(nullable: false, maxLength: 128),
                        Nome = c.String(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.Cpf);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mecanicoes");
        }
    }
}
