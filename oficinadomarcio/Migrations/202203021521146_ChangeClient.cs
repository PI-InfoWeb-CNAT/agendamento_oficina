namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeClient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agendamentos", "CpfCliente", "dbo.Clientes");
            DropForeignKey("dbo.Veiculos", "CpfCliente", "dbo.Clientes");
            DropIndex("dbo.Agendamentos", new[] { "CpfCliente" });
            DropIndex("dbo.Veiculos", new[] { "CpfCliente" });
            DropPrimaryKey("dbo.Clientes");
            DropPrimaryKey("dbo.Mecanicos");
            AlterColumn("dbo.Agendamentos", "CpfCliente", c => c.String(maxLength: 128));
            AlterColumn("dbo.Clientes", "Cpf", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Veiculos", "CpfCliente", c => c.String(maxLength: 128));
            AlterColumn("dbo.Mecanicos", "Cpf", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Clientes", "Cpf");
            AddPrimaryKey("dbo.Mecanicos", "Cpf");
            CreateIndex("dbo.Agendamentos", "CpfCliente");
            CreateIndex("dbo.Veiculos", "CpfCliente");
            AddForeignKey("dbo.Agendamentos", "CpfCliente", "dbo.Clientes", "Cpf");
            AddForeignKey("dbo.Veiculos", "CpfCliente", "dbo.Clientes", "Cpf");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veiculos", "CpfCliente", "dbo.Clientes");
            DropForeignKey("dbo.Agendamentos", "CpfCliente", "dbo.Clientes");
            DropIndex("dbo.Veiculos", new[] { "CpfCliente" });
            DropIndex("dbo.Agendamentos", new[] { "CpfCliente" });
            DropPrimaryKey("dbo.Mecanicos");
            DropPrimaryKey("dbo.Clientes");
            AlterColumn("dbo.Mecanicos", "Cpf", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Veiculos", "CpfCliente", c => c.String(maxLength: 11));
            AlterColumn("dbo.Clientes", "Cpf", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Agendamentos", "CpfCliente", c => c.String(maxLength: 11));
            AddPrimaryKey("dbo.Mecanicos", "Cpf");
            AddPrimaryKey("dbo.Clientes", "Cpf");
            CreateIndex("dbo.Veiculos", "CpfCliente");
            CreateIndex("dbo.Agendamentos", "CpfCliente");
            AddForeignKey("dbo.Veiculos", "CpfCliente", "dbo.Clientes", "Cpf");
            AddForeignKey("dbo.Agendamentos", "CpfCliente", "dbo.Clientes", "Cpf");
        }
    }
}
