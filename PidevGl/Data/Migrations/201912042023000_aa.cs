namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Absences", name: "emp_id", newName: "employeId");
            RenameIndex(table: "dbo.Absences", name: "IX_emp_id", newName: "IX_employeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Absences", name: "IX_employeId", newName: "IX_emp_id");
            RenameColumn(table: "dbo.Absences", name: "employeId", newName: "emp_id");
        }
    }
}
