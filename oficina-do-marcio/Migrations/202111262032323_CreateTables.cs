namespace oficina_do_marcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 1000),
                        Data_agendamento = c.DateTime(nullable: false),
                        Data_servico = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Cpf);
            
            CreateTable(
                "dbo.Mecanicos",
                c => new
                    {
                        Cpf = c.String(nullable: false, maxLength: 11),
                        Senha = c.String(nullable: false, maxLength: 255),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Telefone = c.String(maxLength: 15),
                        Data_cadastro = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Cpf);
            
            CreateTable(
                "dbo.Orcamentos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Double(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 1000),
                        Data_orcamento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Marca = c.String(nullable: false, maxLength: 50),
                        Descricao = c.String(nullable: false, maxLength: 1000),
                        Categoria = c.String(nullable: false, maxLength: 30),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Servicos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Resumo = c.String(nullable: false, maxLength: 255),
                        Descricao = c.String(nullable: false, maxLength: 255),
                        Valor = c.Double(nullable: false),
                        AgendamentoId = c.Int(nullable: false),
                        VeiculoId = c.String(maxLength: 7),
                        MecanicoId = c.String(maxLength: 11),
                        Finalizado = c.Boolean(nullable: false),
                        Data_finalizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agendamentos", t => t.AgendamentoId, cascadeDelete: true)
                .ForeignKey("dbo.Mecanicos", t => t.MecanicoId)
                .ForeignKey("dbo.Veiculos", t => t.VeiculoId)
                .Index(t => t.AgendamentoId)
                .Index(t => t.VeiculoId)
                .Index(t => t.MecanicoId);
            
            CreateTable(
                "dbo.Veiculos",
                c => new
                    {
                        Placa = c.String(nullable: false, maxLength: 7),
                        Marca = c.String(nullable: false, maxLength: 20),
                        Modelo = c.String(nullable: false, maxLength: 100),
                        Ano = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Placa);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servicos", "VeiculoId", "dbo.Veiculos");
            DropForeignKey("dbo.Servicos", "MecanicoId", "dbo.Mecanicos");
            DropForeignKey("dbo.Servicos", "AgendamentoId", "dbo.Agendamentos");
            DropIndex("dbo.Servicos", new[] { "MecanicoId" });
            DropIndex("dbo.Servicos", new[] { "VeiculoId" });
            DropIndex("dbo.Servicos", new[] { "AgendamentoId" });
            DropTable("dbo.Veiculos");
            DropTable("dbo.Servicos");
            DropTable("dbo.Produtos");
            DropTable("dbo.Orcamentos");
            DropTable("dbo.Mecanicos");
            DropTable("dbo.Clientes");
            DropTable("dbo.Agendamentos");
        }
    }
}
