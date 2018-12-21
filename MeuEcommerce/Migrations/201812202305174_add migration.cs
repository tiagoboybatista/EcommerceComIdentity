namespace MeuEcommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Compras", "UsuarioId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "DtNascimento", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "PrimeiroNome", c => c.String());
            AddColumn("dbo.AspNetUsers", "Sobrenome", c => c.String());
            CreateIndex("dbo.Compras", "UsuarioId");
            AddForeignKey("dbo.Compras", "UsuarioId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Compras", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.Compras", new[] { "UsuarioId" });
            DropColumn("dbo.AspNetUsers", "Sobrenome");
            DropColumn("dbo.AspNetUsers", "PrimeiroNome");
            DropColumn("dbo.AspNetUsers", "DtNascimento");
            DropColumn("dbo.Compras", "UsuarioId");
        }
    }
}
