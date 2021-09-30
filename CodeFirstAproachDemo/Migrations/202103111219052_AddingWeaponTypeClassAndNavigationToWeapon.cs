namespace CodeFirstAproachDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingWeaponTypeClassAndNavigationToWeapon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WeaponTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Weapons", "WeaponTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Weapons", "WeaponTypeId");
            AddForeignKey("dbo.Weapons", "WeaponTypeId", "dbo.WeaponTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weapons", "WeaponTypeId", "dbo.WeaponTypes");
            DropIndex("dbo.Weapons", new[] { "WeaponTypeId" });
            DropColumn("dbo.Weapons", "WeaponTypeId");
            DropTable("dbo.WeaponTypes");
        }
    }
}
