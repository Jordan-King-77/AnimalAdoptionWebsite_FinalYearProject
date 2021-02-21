namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTypeToAnimal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "Type", c => c.String(maxLength: 20));
            AlterColumn("dbo.Animals", "Name", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "Name", c => c.String(maxLength: 10));
            DropColumn("dbo.Animals", "Type");
        }
    }
}
