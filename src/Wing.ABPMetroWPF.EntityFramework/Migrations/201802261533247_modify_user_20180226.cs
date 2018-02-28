namespace Wing.ABPMetroWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modify_user_20180226 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AbpRoles", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AbpRoles", "Description");
        }
    }
}
