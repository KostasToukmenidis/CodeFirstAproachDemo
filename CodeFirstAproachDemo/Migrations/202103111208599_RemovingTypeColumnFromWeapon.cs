namespace CodeFirstAproachDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingTypeColumnFromWeapon : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Weapons", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Weapons", "Type", c => c.String(maxLength: 50));
        }
    }
}
