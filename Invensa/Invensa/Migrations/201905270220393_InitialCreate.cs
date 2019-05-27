namespace Invensa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        Author = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        Description = c.String(),
                        reservation_Id = c.Int(),
                        review_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.Title, t.Author })
                .ForeignKey("dbo.Reservation", t => t.reservation_Id)
                .ForeignKey("dbo.Review", t => t.review_Id)
                .Index(t => t.reservation_Id)
                .Index(t => t.review_Id);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        IsReturned = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                        Director = c.String(),
                        Description = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Title);
            
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        year = c.Int(nullable: false),
                        timeline = c.Int(nullable: false),
                        equity = c.Int(nullable: false),
                        assets = c.Int(nullable: false),
                        sales = c.Int(nullable: false),
                        profit = c.Double(nullable: false),
                        price = c.Double(nullable: false),
                        dividends = c.Int(nullable: false),
                        shares = c.Int(nullable: false),
                        ROA = c.Double(nullable: false),
                        ROE = c.Double(nullable: false),
                        NM = c.Double(nullable: false),
                        LEV = c.Double(nullable: false),
                        AT = c.Double(nullable: false),
                        PS = c.Double(nullable: false),
                        PB = c.Double(nullable: false),
                        PE = c.Double(nullable: false),
                        _Public = c.Boolean(nullable: false),
                        Company_Title = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Title)
                .Index(t => t.Company_Title);
            
            CreateTable(
                "dbo.Participant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Role = c.String(),
                        userId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        surname = c.String(),
                        email = c.String(nullable: false),
                        status = c.Int(nullable: false),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Solution",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                        Protocol_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Protocol", t => t.Protocol_Date)
                .Index(t => t.Protocol_Date);
            
            CreateTable(
                "dbo.Protocol",
                c => new
                    {
                        Date = c.DateTime(nullable: false),
                        Quorum = c.Boolean(nullable: false),
                        participant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Date)
                .ForeignKey("dbo.Participant", t => t.participant_Id)
                .Index(t => t.participant_Id);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Protocol_Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Protocol", t => t.Protocol_Date)
                .Index(t => t.Protocol_Date);
            
            CreateTable(
                "dbo.Questionnaire",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcademicGroup = c.String(),
                        Reason = c.String(),
                        Answers = c.String(),
                        Date = c.DateTime(nullable: false),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SolutionUser",
                c => new
                    {
                        Solution_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Solution_Id, t.User_Id })
                .ForeignKey("dbo.Solution", t => t.Solution_Id, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Solution_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Questionnaire", "user_Id", "dbo.User");
            DropForeignKey("dbo.Solution", "Protocol_Date", "dbo.Protocol");
            DropForeignKey("dbo.Question", "Protocol_Date", "dbo.Protocol");
            DropForeignKey("dbo.Protocol", "participant_Id", "dbo.Participant");
            DropForeignKey("dbo.Participant", "userId", "dbo.User");
            DropForeignKey("dbo.SolutionUser", "User_Id", "dbo.User");
            DropForeignKey("dbo.SolutionUser", "Solution_Id", "dbo.Solution");
            DropForeignKey("dbo.Review", "User_Id", "dbo.User");
            DropForeignKey("dbo.Reservation", "User_Id", "dbo.User");
            DropForeignKey("dbo.Report", "Company_Title", "dbo.Company");
            DropForeignKey("dbo.Book", "review_Id", "dbo.Review");
            DropForeignKey("dbo.Book", "reservation_Id", "dbo.Reservation");
            DropIndex("dbo.SolutionUser", new[] { "User_Id" });
            DropIndex("dbo.SolutionUser", new[] { "Solution_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Questionnaire", new[] { "user_Id" });
            DropIndex("dbo.Question", new[] { "Protocol_Date" });
            DropIndex("dbo.Protocol", new[] { "participant_Id" });
            DropIndex("dbo.Solution", new[] { "Protocol_Date" });
            DropIndex("dbo.Participant", new[] { "userId" });
            DropIndex("dbo.Report", new[] { "Company_Title" });
            DropIndex("dbo.Review", new[] { "User_Id" });
            DropIndex("dbo.Reservation", new[] { "User_Id" });
            DropIndex("dbo.Book", new[] { "review_Id" });
            DropIndex("dbo.Book", new[] { "reservation_Id" });
            DropTable("dbo.SolutionUser");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Questionnaire");
            DropTable("dbo.Question");
            DropTable("dbo.Protocol");
            DropTable("dbo.Solution");
            DropTable("dbo.User");
            DropTable("dbo.Participant");
            DropTable("dbo.Report");
            DropTable("dbo.Company");
            DropTable("dbo.Review");
            DropTable("dbo.Reservation");
            DropTable("dbo.Book");
        }
    }
}
