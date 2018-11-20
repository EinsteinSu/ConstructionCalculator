namespace ConstructionCalculator.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class filefirstversion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        BusinessValueId = c.Int(nullable: false),
                        GdQi = c.Double(nullable: false),
                        YdQm = c.Double(nullable: false),
                        Hzmyyzi = c.Double(nullable: false),
                        Hdyza = c.Double(nullable: false),
                        Ylyzd = c.Double(nullable: false),
                        Sssjxzzp = c.Double(nullable: false),
                        Ssrs = c.Double(nullable: false),
                        Jzyz = c.Double(nullable: false),
                        Rkmdqz = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessValues", t => t.BusinessValueId, cascadeDelete: true)
                .Index(t => t.BusinessValueId);
            
            CreateTable(
                "dbo.BusinessValues",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Constructions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Jzmc = c.String(),
                        Dtbh = c.String(),
                        ConstructionValueId = c.Int(nullable: false),
                        BusinessFeatureId = c.Int(nullable: false),
                        Jzmj = c.String(),
                        Dydcjzmj = c.Double(nullable: false),
                        Cs = c.Int(nullable: false),
                        Gd = c.Double(nullable: false),
                        Aqcksl = c.Int(nullable: false),
                        Aqckkd = c.Double(nullable: false),
                        Zcksl = c.Int(nullable: false),
                        Zckkd = c.String(),
                        Sy = c.Int(nullable: false),
                        Mhq = c.Int(nullable: false),
                        Sns = c.Int(nullable: false),
                        Zdbj = c.Int(nullable: false),
                        Pl = c.Int(nullable: false),
                        Kljm = c.Int(nullable: false),
                        Ywsl = c.Int(nullable: false),
                        Ywwbjl = c.Int(nullable: false),
                        Ywsws = c.Int(nullable: false),
                        Swsyws = c.Int(nullable: false),
                        Swsjl = c.String(),
                        Xfdjl = c.Double(nullable: false),
                        Ds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessFeatures", t => t.BusinessFeatureId, cascadeDelete: true)
                .ForeignKey("dbo.ConstructionValues", t => t.ConstructionValueId, cascadeDelete: true)
                .Index(t => t.ConstructionValueId)
                .Index(t => t.BusinessFeatureId);
            
            CreateTable(
                "dbo.ConstructionValues",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 100),
                        DesignRequirement = c.Int(nullable: false),
                        Jgkhsj = c.Double(nullable: false),
                        Wqkhsj = c.Double(nullable: false),
                        Wdkhsj = c.Double(nullable: false),
                        Nqkhsj = c.Double(nullable: false),
                        Pjkhnl = c.Double(nullable: false),
                        Jgkhyz = c.Double(nullable: false),
                        Jzkhyz = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CellMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileId = c.Int(),
                        ColumnNumber = c.Int(nullable: false),
                        ColumnExcelNumber = c.String(maxLength: 10),
                        ColumnName = c.String(maxLength: 100),
                        Group = c.Int(nullable: false),
                        Formula = c.String(maxLength: 500),
                        Digital = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Files", t => t.FileId)
                .Index(t => t.FileId);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 20),
                        Type = c.Int(nullable: false),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RiskLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinValue = c.Double(nullable: false),
                        MaxValue = c.Double(nullable: false),
                        Color = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CellMappings", "FileId", "dbo.Files");
            DropForeignKey("dbo.Constructions", "ConstructionValueId", "dbo.ConstructionValues");
            DropForeignKey("dbo.Constructions", "BusinessFeatureId", "dbo.BusinessFeatures");
            DropForeignKey("dbo.BusinessFeatures", "BusinessValueId", "dbo.BusinessValues");
            DropIndex("dbo.CellMappings", new[] { "FileId" });
            DropIndex("dbo.Constructions", new[] { "BusinessFeatureId" });
            DropIndex("dbo.Constructions", new[] { "ConstructionValueId" });
            DropIndex("dbo.BusinessFeatures", new[] { "BusinessValueId" });
            DropTable("dbo.RiskLevels");
            DropTable("dbo.Files");
            DropTable("dbo.CellMappings");
            DropTable("dbo.ConstructionValues");
            DropTable("dbo.Constructions");
            DropTable("dbo.BusinessValues");
            DropTable("dbo.BusinessFeatures");
        }
    }
}
