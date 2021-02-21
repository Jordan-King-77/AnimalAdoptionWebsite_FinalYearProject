namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseGeneratedOptionNoneForAnimalId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Animals");

            DropColumn("dbo.Animals", "Id");
            AddColumn("dbo.Animals", "Id", c => c.Guid(nullable: false, identity: true));

            AddPrimaryKey("dbo.Animals", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Animals");

            DropColumn("dbo.Animals", "Id");
            AddColumn("dbo.Animals", "Id", c => c.Int(nullable: false, identity: true));

            AddPrimaryKey("dbo.Animals", "Id");
        }
    }
}
