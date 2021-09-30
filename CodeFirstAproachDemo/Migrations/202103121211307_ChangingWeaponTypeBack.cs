namespace CodeFirstAproachDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingWeaponTypeBack : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WeaponTypes", "Weapon_Id", "dbo.Weapons");
            DropIndex("dbo.WeaponTypes", new[] { "Weapon_Id" });
            CreateIndex("dbo.Weapons", "WeaponTypeId");
            AddForeignKey("dbo.Weapons", "WeaponTypeId", "dbo.WeaponTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.WeaponTypes", "Weapon_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WeaponTypes", "Weapon_Id", c => c.Int());
            DropForeignKey("dbo.Weapons", "WeaponTypeId", "dbo.WeaponTypes");
            DropIndex("dbo.Weapons", new[] { "WeaponTypeId" });
            CreateIndex("dbo.WeaponTypes", "Weapon_Id");
            AddForeignKey("dbo.WeaponTypes", "Weapon_Id", "dbo.Weapons", "Id");
        }
    }
}
