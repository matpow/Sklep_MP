namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uzytkownik", "email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uzytkownik", "email");
        }
    }
}
