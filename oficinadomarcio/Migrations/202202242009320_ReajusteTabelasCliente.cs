namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReajusteTabelasCliente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Veiculos", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Agendamentos", new[] { "PlacaVeiculo" });
            DropIndex("dbo.Veiculos", new[] { "ApplicationUserId" });
            RenameColumn(table: "dbo.Agendamentos", name: "ApplicationUserId", newName: "CpfCliente");
            RenameIndex(table: "dbo.Agendamentos", name: "IX_ApplicationUserId", newName: "IX_CpfCliente");
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Cpf = c.String(nullable: false, maxLength: 11),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Telefone = c.String(maxLength: 15),
                        Email = c.String(nullable: false, maxLength: 100),
                        Senha = c.String(nullable: false, maxLength: 255),
                        Endereco = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Cpf)
                .Index(t => t.Email);
            
            AddColumn("dbo.Veiculos", "CpfCliente", c => c.String(maxLength: 11));
            AlterColumn("dbo.Agendamentos", "PlacaVeiculo", c => c.String(maxLength: 11));
            CreateIndex("dbo.Agendamentos", "PlacaVeiculo");
            CreateIndex("dbo.Veiculos", "CpfCliente");
            AddForeignKey("dbo.Veiculos", "CpfCliente", "dbo.Clientes", "Cpf");
            DropColumn("dbo.Veiculos", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Veiculos", "ApplicationUserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Veiculos", "CpfCliente", "dbo.Clientes");
            DropIndex("dbo.Veiculos", new[] { "CpfCliente" });
            DropIndex("dbo.Clientes", new[] { "Email" });
            DropIndex("dbo.Agendamentos", new[] { "PlacaVeiculo" });
            AlterColumn("dbo.Agendamentos", "PlacaVeiculo", c => c.String(maxLength: 7));
            DropColumn("dbo.Veiculos", "CpfCliente");
            DropTable("dbo.Clientes");
            RenameIndex(table: "dbo.Agendamentos", name: "IX_CpfCliente", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.Agendamentos", name: "CpfCliente", newName: "ApplicationUserId");
            CreateIndex("dbo.Veiculos", "ApplicationUserId");
            CreateIndex("dbo.Agendamentos", "PlacaVeiculo");
            AddForeignKey("dbo.Veiculos", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
