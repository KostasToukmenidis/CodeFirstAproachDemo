namespace CodeFirstAproachDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TurningWeaponTypeIntoList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Weapons", "WeaponTypeId", "dbo.WeaponTypes");
            DropIndex("dbo.Weapons", new[] { "WeaponTypeId" });
            AddColumn("dbo.WeaponTypes", "Weapon_Id", c => c.Int());
            CreateIndex("dbo.WeaponTypes", "Weapon_Id");
            AddForeignKey("dbo.WeaponTypes", "Weapon_Id", "dbo.Weapons", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeaponTypes", "Weapon_Id", "dbo.Weapons");
            DropIndex("dbo.WeaponTypes", new[] { "Weapon_Id" });
            DropColumn("dbo.WeaponTypes", "Weapon_Id");
            CreateIndex("dbo.Weapons", "WeaponTypeId");
            AddForeignKey("dbo.Weapons", "WeaponTypeId", "dbo.WeaponTypes", "Id", cascadeDelete: true);
        }
    }
}
