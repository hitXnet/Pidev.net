namespace Solution.Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TicketExtras",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        etat = c.String(maxLength: 255),
                        flextime = c.Int(nullable: false),
                        tache = c.String(maxLength: 255),
                        price = c.Int(nullable: false),
                        id_emp = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TicketExtras");
        }
    }
}
