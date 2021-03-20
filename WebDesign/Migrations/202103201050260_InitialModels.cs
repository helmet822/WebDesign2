namespace WebDesign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mains",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Genre = c.String(),
                        Person = c.String(),
                        Memo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mains");
        }
    }
}
