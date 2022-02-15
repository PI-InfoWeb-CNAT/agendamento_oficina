namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherTableChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agendamentos", "Titulo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Agendamentos", "Titulo", c => c.String());
        }
    }
}
