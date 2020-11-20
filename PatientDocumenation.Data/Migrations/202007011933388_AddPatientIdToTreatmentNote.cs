namespace PatientDocumenation.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientIdToTreatmentNote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TreatmentNote", "PatientId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TreatmentNote", "PatientId");
        }
    }
}
