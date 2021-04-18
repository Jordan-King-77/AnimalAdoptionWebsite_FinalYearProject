namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsAvailablebooltoAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "IsAvailable", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "IsAvailable");
        }
    }
}
