namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDietaryNeedstoAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "DietaryNeeds", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "DietaryNeeds");
        }
    }
}
