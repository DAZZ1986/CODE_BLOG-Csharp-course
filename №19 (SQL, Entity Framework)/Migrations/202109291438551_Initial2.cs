namespace CODE_BLOG__19__SQL__Entity_Framework_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Groups", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "Type", c => c.String());
        }
    }
}
