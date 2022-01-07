namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgendamentoRowCorrection : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agendamentos", "Data_servico", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agendamentos", "Data_servico", c => c.DateTime());
        }
    }
}
