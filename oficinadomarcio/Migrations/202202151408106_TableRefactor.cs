namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableRefactor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Servicos", "AgendamentoId", "dbo.Agendamentos");
            DropForeignKey("dbo.Servicos", "MecanicoId", "dbo.Mecanicos");
            DropForeignKey("dbo.Servicos", "VeiculoId", "dbo.Veiculos");
            DropIndex("dbo.Servicos", new[] { "AgendamentoId" });
            DropIndex("dbo.Servicos", new[] { "VeiculoId" });
            DropIndex("dbo.Servicos", new[] { "MecanicoId" });
            AddColumn("dbo.Agendamentos", "CpfCliente", c => c.String(maxLength: 11));
            AddColumn("dbo.Agendamentos", "PlacaVeiculo", c => c.String(maxLength: 7));
            AddColumn("dbo.Mecanicos", "Email", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Produtos", "Preco", c => c.Double(nullable: false));
            AddColumn("dbo.Servicos", "Categoria", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.Servicos", "Preco", c => c.Double(nullable: false));
            AddColumn("dbo.Veiculos", "Cpf", c => c.String(maxLength: 11));
            AlterColumn("dbo.Agendamentos", "Titulo", c => c.String());
            AlterColumn("dbo.Agendamentos", "Descricao", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Agendamentos", "Data_agendamento", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Mecanicos", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Produtos", "Descricao", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Servicos", "Descricao", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Agendamentos", "CpfCliente");
            CreateIndex("dbo.Agendamentos", "PlacaVeiculo");
            CreateIndex("dbo.Veiculos", "Cpf");
            CreateIndex("dbo.Mecanicos", "Email");
            AddForeignKey("dbo.Agendamentos", "CpfCliente", "dbo.Clientes", "Cpf");
            AddForeignKey("dbo.Veiculos", "Cpf", "dbo.Clientes", "Cpf");
            AddForeignKey("dbo.Agendamentos", "PlacaVeiculo", "dbo.Veiculos", "Placa");
            DropColumn("dbo.Agendamentos", "Data_servico");
            DropColumn("dbo.Clientes", "Data_cadastro");
            DropColumn("dbo.Mecanicos", "Admin");
            DropColumn("dbo.Mecanicos", "Data_cadastro");
            DropColumn("dbo.Servicos", "Resumo");
            DropColumn("dbo.Servicos", "Valor");
            DropColumn("dbo.Servicos", "AgendamentoId");
            DropColumn("dbo.Servicos", "VeiculoId");
            DropColumn("dbo.Servicos", "MecanicoId");
            DropColumn("dbo.Servicos", "Finalizado");
            DropColumn("dbo.Servicos", "Data_finalizacao");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servicos", "Data_finalizacao", c => c.DateTime(nullable: false));
            AddColumn("dbo.Servicos", "Finalizado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Servicos", "MecanicoId", c => c.String(maxLength: 11));
            AddColumn("dbo.Servicos", "VeiculoId", c => c.String(maxLength: 7));
            AddColumn("dbo.Servicos", "AgendamentoId", c => c.Int(nullable: false));
            AddColumn("dbo.Servicos", "Valor", c => c.Double(nullable: false));
            AddColumn("dbo.Servicos", "Resumo", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Mecanicos", "Data_cadastro", c => c.DateTime());
            AddColumn("dbo.Mecanicos", "Admin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Clientes", "Data_cadastro", c => c.DateTime());
            AddColumn("dbo.Agendamentos", "Data_servico", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Agendamentos", "PlacaVeiculo", "dbo.Veiculos");
            DropForeignKey("dbo.Veiculos", "Cpf", "dbo.Clientes");
            DropForeignKey("dbo.Agendamentos", "CpfCliente", "dbo.Clientes");
            DropIndex("dbo.Mecanicos", new[] { "Email" });
            DropIndex("dbo.Veiculos", new[] { "Cpf" });
            DropIndex("dbo.Agendamentos", new[] { "PlacaVeiculo" });
            DropIndex("dbo.Agendamentos", new[] { "CpfCliente" });
            AlterColumn("dbo.Servicos", "Descricao", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Produtos", "Descricao", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Mecanicos", "Nome", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Agendamentos", "Data_agendamento", c => c.DateTime());
            AlterColumn("dbo.Agendamentos", "Descricao", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Agendamentos", "Titulo", c => c.String(nullable: false));
            DropColumn("dbo.Veiculos", "Cpf");
            DropColumn("dbo.Servicos", "Preco");
            DropColumn("dbo.Servicos", "Categoria");
            DropColumn("dbo.Produtos", "Preco");
            DropColumn("dbo.Mecanicos", "Email");
            DropColumn("dbo.Agendamentos", "PlacaVeiculo");
            DropColumn("dbo.Agendamentos", "CpfCliente");
            CreateIndex("dbo.Servicos", "MecanicoId");
            CreateIndex("dbo.Servicos", "VeiculoId");
            CreateIndex("dbo.Servicos", "AgendamentoId");
            AddForeignKey("dbo.Servicos", "VeiculoId", "dbo.Veiculos", "Placa");
            AddForeignKey("dbo.Servicos", "MecanicoId", "dbo.Mecanicos", "Cpf");
            AddForeignKey("dbo.Servicos", "AgendamentoId", "dbo.Agendamentos", "Id", cascadeDelete: true);
        }
    }
}
