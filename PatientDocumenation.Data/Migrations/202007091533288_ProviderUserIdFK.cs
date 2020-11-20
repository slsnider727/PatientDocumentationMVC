namespace PatientDocumenation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProviderUserIdFK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Provider", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Provider", "Id");
            AddForeignKey("dbo.Provider", "Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provider", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.Provider", new[] { "Id" });
            DropColumn("dbo.Provider", "Id");
        }
    }
}
