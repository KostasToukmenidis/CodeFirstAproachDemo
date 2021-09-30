namespace CodeFirstAproachDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddintDataAnnotationsToWeapons : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Weapons", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Weapons", "Type", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Weapons", "Type", c => c.String());
            AlterColumn("dbo.Weapons", "Name", c => c.String());
        }
    }
}
