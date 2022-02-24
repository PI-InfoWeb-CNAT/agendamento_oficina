namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewCliente : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clientes", "Senha");
            DropColumn("dbo.Clientes", "Endereco");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clientes", "Endereco", c => c.String(maxLength: 255));
            AddColumn("dbo.Clientes", "Senha", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
