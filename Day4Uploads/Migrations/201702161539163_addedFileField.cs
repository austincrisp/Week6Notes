namespace Day4Uploads.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedFileField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageUploads", "File", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImageUploads", "File");
        }
    }
}
