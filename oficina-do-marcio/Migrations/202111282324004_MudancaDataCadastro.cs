namespace oficina_do_marcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MudancaDataCadastro : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Data_cadastro", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clientes", "Data_cadastro", c => c.DateTime());
        }
    }
}
