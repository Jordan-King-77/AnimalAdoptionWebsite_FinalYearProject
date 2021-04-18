namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInterestedUserstoAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "InterestedUsers", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "InterestedUsers");
        }
    }
}
