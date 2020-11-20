namespace PatientDocumenation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameProviderUserIdFK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Provider", name: "Id", newName: "UserId");
            RenameIndex(table: "dbo.Provider", name: "IX_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Provider", name: "IX_UserId", newName: "IX_Id");
            RenameColumn(table: "dbo.Provider", name: "UserId", newName: "Id");
        }
    }
}
