namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesTotalRefactor : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Veiculos", name: "Cpf", newName: "CpfCliente");
            RenameIndex(table: "dbo.Veiculos", name: "IX_Cpf", newName: "IX_CpfCliente");
            AlterColumn("dbo.Agendamentos", "Titulo", c => c.String(nullable: false));
            AlterColumn("dbo.Agendamentos", "Descricao", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agendamentos", "Descricao", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Agendamentos", "Titulo", c => c.String());
            RenameIndex(table: "dbo.Veiculos", name: "IX_CpfCliente", newName: "IX_Cpf");
            RenameColumn(table: "dbo.Veiculos", name: "CpfCliente", newName: "Cpf");
        }
    }
}
