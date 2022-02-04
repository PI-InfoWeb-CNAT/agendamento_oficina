namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrecaoModelAgendamento : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Horarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Hora = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Agendamentos", "HorarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Agendamentos", "HorarioId");
            AddForeignKey("dbo.Agendamentos", "HorarioId", "dbo.Horarios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamentos", "HorarioId", "dbo.Horarios");
            DropIndex("dbo.Agendamentos", new[] { "HorarioId" });
            DropColumn("dbo.Agendamentos", "HorarioId");
            DropTable("dbo.Horarios");
        }
    }
}
