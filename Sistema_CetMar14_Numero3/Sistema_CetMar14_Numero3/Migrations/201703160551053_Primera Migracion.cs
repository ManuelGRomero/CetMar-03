namespace Sistema_CetMar14_Numero3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnoes",
                c => new
                    {
                        alumnoID = c.Int(nullable: false, identity: true),
                        noMatricula = c.Int(nullable: false),
                        alumnoNombre = c.String(nullable: false),
                        alumnoApellidoPaterno = c.String(nullable: false),
                        alumnoApellidoMaterno = c.String(nullable: false),
                        fechaNacimiento = c.DateTime(nullable: false),
                        telefono = c.String(nullable: false),
                        domicilio = c.String(nullable: false),
                        grupo = c.String(),
                        pregunta1 = c.String(),
                        pregunta2 = c.String(),
                        pregunta3 = c.String(),
                        pregunta4 = c.String(),
                        pregunta5 = c.String(),
                        pregunta6 = c.String(),
                        pregunta7 = c.String(),
                        pregunta8 = c.String(),
                        pregunta9 = c.String(),
                    })
                .PrimaryKey(t => t.alumnoID);
            
            CreateTable(
                "dbo.Expedientes",
                c => new
                    {
                        expedienteID = c.Int(nullable: false, identity: true),
                        noExpediente = c.String(),
                        alumnoID = c.Int(nullable: false),
                        especialistaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.expedienteID)
                .ForeignKey("dbo.Alumnoes", t => t.alumnoID, cascadeDelete: true)
                .ForeignKey("dbo.Especialistas", t => t.especialistaID, cascadeDelete: true)
                .Index(t => t.alumnoID)
                .Index(t => t.especialistaID);
            
            CreateTable(
                "dbo.Especialistas",
                c => new
                    {
                        especialistaID = c.Int(nullable: false, identity: true),
                        especialistaRFC = c.String(nullable: false),
                        especialistaNombre = c.String(nullable: false),
                        especialistaApellido = c.String(nullable: false),
                        especialidad = c.String(nullable: false),
                        especialistaTelefono = c.String(nullable: false),
                        especialistaDomicilio = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.especialistaID);
            
            CreateTable(
                "dbo.Registroes",
                c => new
                    {
                        registroHistorialID = c.Int(nullable: false, identity: true),
                        registroHistorialnota = c.String(nullable: false),
                        registroHistorialFecha = c.DateTime(nullable: false),
                        registroHistorialCanalizacion = c.String(nullable: false),
                        expedianteID = c.Int(nullable: false),
                        expedientes_expedienteID = c.Int(),
                    })
                .PrimaryKey(t => t.registroHistorialID)
                .ForeignKey("dbo.Expedientes", t => t.expedientes_expedienteID)
                .Index(t => t.expedientes_expedienteID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Registroes", "expedientes_expedienteID", "dbo.Expedientes");
            DropForeignKey("dbo.Expedientes", "especialistaID", "dbo.Especialistas");
            DropForeignKey("dbo.Expedientes", "alumnoID", "dbo.Alumnoes");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Registroes", new[] { "expedientes_expedienteID" });
            DropIndex("dbo.Expedientes", new[] { "especialistaID" });
            DropIndex("dbo.Expedientes", new[] { "alumnoID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Registroes");
            DropTable("dbo.Especialistas");
            DropTable("dbo.Expedientes");
            DropTable("dbo.Alumnoes");
        }
    }
}
