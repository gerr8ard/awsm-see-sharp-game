namespace awsmSeeSharpGame.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.awsm_Privilege",
                c => new
                    {
                        Privilege_id = c.Int(nullable: false, identity: true),
                        Privilege = c.String(),
                    })
                .PrimaryKey(t => t.Privilege_id);
            
            CreateTable(
                "dbo.awsm_Score",
                c => new
                    {
                        Score_id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        User_id = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Score_id)
                .ForeignKey("dbo.awsm_Users", t => t.User_id, cascadeDelete: true)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.awsm_Users",
                c => new
                    {
                        User_id = c.Int(nullable: false, identity: true),
                        Privilege_id = c.Int(nullable: false),
                        UserName = c.String(),
                        SureName = c.String(),
                        FirstName = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.User_id)
                .ForeignKey("dbo.awsm_Privilege", t => t.Privilege_id, cascadeDelete: true)
                .Index(t => t.Privilege_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.awsm_Score", "User_id", "dbo.awsm_Users");
            DropForeignKey("dbo.awsm_Users", "Privilege_id", "dbo.awsm_Privilege");
            DropIndex("dbo.awsm_Users", new[] { "Privilege_id" });
            DropIndex("dbo.awsm_Score", new[] { "User_id" });
            DropTable("dbo.awsm_Users");
            DropTable("dbo.awsm_Score");
            DropTable("dbo.awsm_Privilege");
        }
    }
}
