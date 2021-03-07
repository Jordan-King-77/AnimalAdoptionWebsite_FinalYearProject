namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedtagstoAnimal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagAnimals", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagAnimals", "Animal_Id", "dbo.Animals");
            DropIndex("dbo.TagAnimals", new[] { "Tag_Id" });
            DropIndex("dbo.TagAnimals", new[] { "Animal_Id" });
            AddColumn("dbo.Animals", "Tag1", c => c.String());
            AddColumn("dbo.Animals", "Tag2", c => c.String());
            AddColumn("dbo.Animals", "Tag3", c => c.String());
            AddColumn("dbo.Animals", "Tag4", c => c.String());
            AddColumn("dbo.Animals", "Tag5", c => c.String());
            DropTable("dbo.Tags");
            DropTable("dbo.TagAnimals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TagAnimals",
                c => new
                    {
                        Tag_Id = c.String(nullable: false, maxLength: 128),
                        Animal_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Animal_Id });
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Item = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Animals", "Tag5");
            DropColumn("dbo.Animals", "Tag4");
            DropColumn("dbo.Animals", "Tag3");
            DropColumn("dbo.Animals", "Tag2");
            DropColumn("dbo.Animals", "Tag1");
            CreateIndex("dbo.TagAnimals", "Animal_Id");
            CreateIndex("dbo.TagAnimals", "Tag_Id");
            AddForeignKey("dbo.TagAnimals", "Animal_Id", "dbo.Animals", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TagAnimals", "Tag_Id", "dbo.Tags", "Id", cascadeDelete: true);
        }
    }
}
