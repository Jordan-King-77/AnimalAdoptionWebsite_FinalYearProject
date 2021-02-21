namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAnimalUserIdFromIntToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "ApplicationUserId", c => c.String());
            DropColumn("dbo.Animals", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "UserId", c => c.String());
            DropColumn("dbo.Animals", "ApplicationUserId");
        }
    }
}
