namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIdToAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "UserId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "UserId");
        }
    }
}
