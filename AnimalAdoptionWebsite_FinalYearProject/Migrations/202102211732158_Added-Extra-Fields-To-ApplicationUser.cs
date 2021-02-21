namespace AnimalAdoptionWebsite_FinalYearProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedExtraFieldsToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Animals", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Animals", "ApplicationUser_Id");
            CreateIndex("dbo.Animals", "ApplicationUser_Id1");
            AddForeignKey("dbo.Animals", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Animals", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Animals", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Animals", new[] { "ApplicationUser_Id1" });
            DropIndex("dbo.Animals", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropColumn("dbo.Animals", "ApplicationUser_Id1");
            DropColumn("dbo.Animals", "ApplicationUser_Id");
        }
    }
}
