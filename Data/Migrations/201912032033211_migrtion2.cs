namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrtion2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Factures",
                c => new
                    {
                        idfacture = c.Int(nullable: false, identity: true),
                        imagefacture = c.String(unicode: false),
                        descriptionfacture = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.idfacture);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Factures");
        }
    }
}
