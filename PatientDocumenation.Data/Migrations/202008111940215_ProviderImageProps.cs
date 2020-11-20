namespace PatientDocumenation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProviderImageProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Provider", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Provider", "ImagePath");
        }
    }
}
