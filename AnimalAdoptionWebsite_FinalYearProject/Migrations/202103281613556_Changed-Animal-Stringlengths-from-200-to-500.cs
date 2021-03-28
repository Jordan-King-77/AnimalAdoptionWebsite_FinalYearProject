namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAnimalStringlengthsfrom200to500 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "Description", c => c.String(maxLength: 500));
            AlterColumn("dbo.Animals", "MedicalHistory", c => c.String(maxLength: 500));
            AlterColumn("dbo.Animals", "DietaryNeeds", c => c.String(maxLength: 500));
            AlterColumn("dbo.Animals", "Behaviour", c => c.String(maxLength: 500));
            AlterColumn("dbo.Animals", "BackgroundInfo", c => c.String(maxLength: 500));
            AlterColumn("dbo.Animals", "HouseholdRequirements", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "HouseholdRequirements", c => c.String(maxLength: 200));
            AlterColumn("dbo.Animals", "BackgroundInfo", c => c.String(maxLength: 200));
            AlterColumn("dbo.Animals", "Behaviour", c => c.String(maxLength: 200));
            AlterColumn("dbo.Animals", "DietaryNeeds", c => c.String(maxLength: 200));
            AlterColumn("dbo.Animals", "MedicalHistory", c => c.String(maxLength: 200));
            AlterColumn("dbo.Animals", "Description", c => c.String(maxLength: 200));
        }
    }
}
