namespace Sistema_CetMar14_Numero3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeguncambiodeExpedienteID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Registroes", "expedientes_expedienteID", "dbo.Expedientes");
            DropIndex("dbo.Registroes", new[] { "expedientes_expedienteID" });
            RenameColumn(table: "dbo.Registroes", name: "expedientes_expedienteID", newName: "expedienteID");
            AlterColumn("dbo.Registroes", "expedienteID", c => c.Int(nullable: false));
            CreateIndex("dbo.Registroes", "expedienteID");
            AddForeignKey("dbo.Registroes", "expedienteID", "dbo.Expedientes", "expedienteID", cascadeDelete: true);
            DropColumn("dbo.Registroes", "expedianteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Registroes", "expedianteID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Registroes", "expedienteID", "dbo.Expedientes");
            DropIndex("dbo.Registroes", new[] { "expedienteID" });
            AlterColumn("dbo.Registroes", "expedienteID", c => c.Int());
            RenameColumn(table: "dbo.Registroes", name: "expedienteID", newName: "expedientes_expedienteID");
            CreateIndex("dbo.Registroes", "expedientes_expedienteID");
            AddForeignKey("dbo.Registroes", "expedientes_expedienteID", "dbo.Expedientes", "expedienteID");
        }
    }
}
