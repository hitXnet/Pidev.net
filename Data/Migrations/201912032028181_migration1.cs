namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "pidev.employe",
                c => new
                    {
                        emp_id = c.Int(nullable: false, identity: true),
                        bio = c.String(maxLength: 255, unicode: false),
                        cv = c.String(maxLength: 255, unicode: false),
                        photo = c.String(maxLength: 255, unicode: false),
                        Nom = c.String(maxLength: 255, unicode: false),
                        prenom = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.emp_id);
            
            CreateTable(
                "pidev.frais",
                c => new
                    {
                        idFrais = c.Int(nullable: false, identity: true),
                        terminer = c.Boolean(nullable: false, storeType: "bit"),
                        employe_emp_id = c.Int(),
                        mission_idMission = c.Int(),
                    })
                .PrimaryKey(t => t.idFrais)
                .ForeignKey("pidev.mission", t => t.mission_idMission)
                .ForeignKey("pidev.employe", t => t.employe_emp_id)
                .Index(t => t.mission_idMission)
                .Index(t => t.employe_emp_id);
            
            CreateTable(
                "pidev.mission",
                c => new
                    {
                        idMission = c.Int(nullable: false, identity: true),
                        DatedepartMission = c.DateTime(precision: 0),
                        DateretourMission = c.DateTime(precision: 0),
                        LieuMission = c.String(maxLength: 255, unicode: false),
                        NomMission = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.idMission);
            
            CreateTable(
                "pidev.fraisprevu",
                c => new
                    {
                        idFraisprev = c.Int(nullable: false, identity: true),
                        montantprev = c.Single(nullable: false),
                        natureprev = c.Int(),
                        mission_idMission = c.Int(),
                    })
                .PrimaryKey(t => t.idFraisprev)
                .ForeignKey("pidev.mission", t => t.mission_idMission)
                .Index(t => t.mission_idMission);
            
            CreateTable(
                "pidev.notefrais",
                c => new
                    {
                        idfrais = c.Int(nullable: false, identity: true),
                        description = c.String(maxLength: 255, unicode: false),
                        etat = c.Int(),
                        facture = c.String(maxLength: 255, unicode: false),
                        montantfrais = c.Single(nullable: false),
                        naturefrais = c.Int(),
                        frais_idFrais = c.Int(),
                    })
                .PrimaryKey(t => t.idfrais)
                .ForeignKey("pidev.frais", t => t.frais_idFrais)
                .Index(t => t.frais_idFrais);
            
            CreateTable(
                "pidev.notefraisemploye",
                c => new
                    {
                        idfraisem = c.Int(nullable: false, identity: true),
                        descriptionem = c.String(maxLength: 255, unicode: false),
                        montantfraisem = c.Single(nullable: false),
                        naturefraisem = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.idfraisem);
            
            CreateTable(
                "pidev.employe_mission",
                c => new
                    {
                        employe_emp_id = c.Int(nullable: false),
                        mission_idMission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.employe_emp_id, t.mission_idMission })
                .ForeignKey("pidev.employe", t => t.employe_emp_id, cascadeDelete: true)
                .ForeignKey("pidev.mission", t => t.mission_idMission, cascadeDelete: true)
                .Index(t => t.employe_emp_id)
                .Index(t => t.mission_idMission);
            
        }
        
        public override void Down()
        {
            DropForeignKey("pidev.employe_mission", "mission_idMission", "pidev.mission");
            DropForeignKey("pidev.employe_mission", "employe_emp_id", "pidev.employe");
            DropForeignKey("pidev.frais", "employe_emp_id", "pidev.employe");
            DropForeignKey("pidev.notefrais", "frais_idFrais", "pidev.frais");
            DropForeignKey("pidev.fraisprevu", "mission_idMission", "pidev.mission");
            DropForeignKey("pidev.frais", "mission_idMission", "pidev.mission");
            DropIndex("pidev.employe_mission", new[] { "mission_idMission" });
            DropIndex("pidev.employe_mission", new[] { "employe_emp_id" });
            DropIndex("pidev.frais", new[] { "employe_emp_id" });
            DropIndex("pidev.notefrais", new[] { "frais_idFrais" });
            DropIndex("pidev.fraisprevu", new[] { "mission_idMission" });
            DropIndex("pidev.frais", new[] { "mission_idMission" });
            DropTable("pidev.employe_mission");
            DropTable("pidev.notefraisemploye");
            DropTable("pidev.notefrais");
            DropTable("pidev.fraisprevu");
            DropTable("pidev.mission");
            DropTable("pidev.frais");
            DropTable("pidev.employe");
        }
    }
}
