﻿namespace Repozytorium.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startowa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoria",
                c => new
                    {
                        KategoriaId = c.Int(nullable: false, identity: true),
                        NazwaKategorii = c.String(nullable: false, maxLength: 100),
                        OpisKategorii = c.String(nullable: false),
                        NazwaPlikuIkony = c.String(),
                    })
                .PrimaryKey(t => t.KategoriaId);
            
            CreateTable(
                "dbo.Produkt",
                c => new
                    {
                        ProduktId = c.Int(nullable: false, identity: true),
                        KategoriaId = c.Int(nullable: false),
                        Nazwa_produktu = c.String(nullable: false),
                        Cena = c.Int(nullable: false),
                        Producent = c.String(),
                        DataDodania = c.DateTime(nullable: false),
                        NazwaPlikuObrazka = c.String(maxLength: 100),
                        OpisProduktu = c.String(),
                        Bestseller = c.Boolean(nullable: false),
                        Ukryty = c.Boolean(nullable: false),
                        OpisSkrocony = c.String(),
                        Skrot = c.String(),
                    })
                .PrimaryKey(t => t.ProduktId)
                .ForeignKey("dbo.Kategoria", t => t.KategoriaId)
                .Index(t => t.KategoriaId);
            
            CreateTable(
                "dbo.PozycjaZamowienia",
                c => new
                    {
                        PozycjaZamowieniaId = c.Int(nullable: false, identity: true),
                        ZamowienieID = c.Int(nullable: false),
                        ProduktId = c.Int(nullable: false),
                        Ilosc = c.Int(nullable: false),
                        CenaZakupu = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PozycjaZamowieniaId)
                .ForeignKey("dbo.Produkt", t => t.ProduktId)
                .ForeignKey("dbo.Zamowienie", t => t.ZamowienieID)
                .Index(t => t.ZamowienieID)
                .Index(t => t.ProduktId);
            
            CreateTable(
                "dbo.Zamowienie",
                c => new
                    {
                        ZamowienieID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Imie = c.String(nullable: false, maxLength: 50),
                        Nazwisko = c.String(nullable: false, maxLength: 50),
                        Adres = c.String(nullable: false, maxLength: 100),
                        Miasto = c.String(nullable: false, maxLength: 100),
                        KodPocztowy = c.String(nullable: false, maxLength: 6),
                        Telefon = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        Komentarz = c.String(),
                        DataDodania = c.DateTime(nullable: false),
                        StanZamowienia = c.Int(nullable: false),
                        WartoscZamowienia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ZamowienieID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DaneUzytkownika_login = c.String(),
                        DaneUzytkownika_haslo = c.String(),
                        DaneUzytkownika_email = c.String(),
                        DaneUzytkownika_imie = c.String(),
                        DaneUzytkownika_nazwisko = c.String(),
                        DaneUzytkownika_adres = c.String(),
                        DaneUzytkownika_miasto = c.String(),
                        DaneUzytkownika_kod_pocztowy = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Uzytkownik",
                c => new
                    {
                        UzytkownikID = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        Haslo = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.UzytkownikID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Zamowienie", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PozycjaZamowienia", "ZamowienieID", "dbo.Zamowienie");
            DropForeignKey("dbo.PozycjaZamowienia", "ProduktId", "dbo.Produkt");
            DropForeignKey("dbo.Produkt", "KategoriaId", "dbo.Kategoria");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Zamowienie", new[] { "UserId" });
            DropIndex("dbo.PozycjaZamowienia", new[] { "ProduktId" });
            DropIndex("dbo.PozycjaZamowienia", new[] { "ZamowienieID" });
            DropIndex("dbo.Produkt", new[] { "KategoriaId" });
            DropTable("dbo.Uzytkownik");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Zamowienie");
            DropTable("dbo.PozycjaZamowienia");
            DropTable("dbo.Produkt");
            DropTable("dbo.Kategoria");
        }
    }
}
