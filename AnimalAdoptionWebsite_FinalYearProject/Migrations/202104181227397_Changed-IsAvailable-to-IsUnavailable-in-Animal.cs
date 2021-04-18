namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedIsAvailabletoIsUnavailableinAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "IsUnavailable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Animals", "IsAvailable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Animals", "IsAvailable", c => c.Boolean(nullable: false));
            DropColumn("dbo.Animals", "IsUnavailable");
        }
    }
}
