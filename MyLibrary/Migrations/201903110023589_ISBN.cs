namespace MyLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ISBN : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Books", new[] { "ISBN" });
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false, maxLength: 13));
            CreateIndex("dbo.Books", "ISBN", unique: true);
        }
    }
}
