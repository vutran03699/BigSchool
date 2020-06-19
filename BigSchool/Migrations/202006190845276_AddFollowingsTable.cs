namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FolloweId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                        Follower_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FolloweId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.Follower_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FolloweeId)
                .Index(t => t.Follower_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "Follower_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "Follower_Id" });
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropTable("dbo.Followings");
        }
    }
}
