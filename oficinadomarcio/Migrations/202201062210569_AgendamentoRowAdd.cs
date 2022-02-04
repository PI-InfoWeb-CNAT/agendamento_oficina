namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgendamentoRowAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agendamentos", "Titulo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agendamentos", "Titulo");
        }
    }
}
