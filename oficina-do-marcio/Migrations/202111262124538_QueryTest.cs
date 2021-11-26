namespace oficina_do_marcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QueryTest : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Clientes (Cpf, Nome, Telefone, Email, Senha, Endereco) VALUES ('09781964499', 'Gabriel Guilherme', '84999110101', 'gabrielguilherme13@hotmail.com', 'teste', 'Av. 4, 818, Alecrim')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Clientes WHERE Cpf = '09781964499'");
        }
    }
}
