namespace oficinadomarcio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedHorario : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Horarios (Hora) VALUES ('07:30')");
            Sql("INSERT INTO Horarios (Hora) VALUES ('08:30')");
            Sql("INSERT INTO Horarios (Hora) VALUES ('09:30')");
            Sql("INSERT INTO Horarios (Hora) VALUES ('10:30')");
            Sql("INSERT INTO Horarios (Hora) VALUES ('11:30')");
            Sql("INSERT INTO Horarios (Hora) VALUES ('13:30')");
            Sql("INSERT INTO Horarios (Hora) VALUES ('14:30')");
            Sql("INSERT INTO Horarios (Hora) VALUES ('15:30')");
            Sql("INSERT INTO Horarios (Hora) VALUES ('16:30')");
            Sql("INSERT INTO Horarios (Hora) VALUES ('17:30')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Horarios WHERE Id BETWEEN 1 AND 10");
        }
    }
}
