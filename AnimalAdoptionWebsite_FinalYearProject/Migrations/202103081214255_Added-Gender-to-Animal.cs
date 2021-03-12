namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGendertoAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "Gender");
        }
    }
}
