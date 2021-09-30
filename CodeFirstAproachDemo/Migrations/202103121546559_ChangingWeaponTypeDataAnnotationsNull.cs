namespace CodeFirstAproachDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingWeaponTypeDataAnnotationsNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WeaponTypes", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WeaponTypes", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
