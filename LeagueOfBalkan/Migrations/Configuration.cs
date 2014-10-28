namespace LeagueOfBalkan.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LeagueOfBalkan.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LeagueOfBalkan.Models.LoBDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LeagueOfBalkan.Models.LoBDb context)
        {

            context.News.AddOrUpdate(
                n => n.Title,
                new News { Title = "Prva vijest",
                           Text = "Text vijesti treba biti ogranicen na 50 znakova na pocetnoj.",
                           ImagePath = "~/uploads\\Prvavijest_271014_lol.png",
                           ThumbPath = "~/uploads\\thumb_Prvavijest_271014_lol.png"},

                new News { Title = "Druga vijest",
                           Text = "Text vijesti treba biti ogranicen na 50 znakova na pocetnoj.",
                           ImagePath = "~/uploads\\Prvavijest_271014_lol.png",
                           ThumbPath = "~/uploads\\thumb_Prvavijest_271014_lol.png"},

                new News { Title = "Treca vijest",
                           Text = "Text vijesti treba biti ogranicen na 50 znakova na pocetnoj.",
                           ImagePath = "~/uploads\\Prvavijest_271014_lol.png",
                           ThumbPath = "~/uploads\\thumb_Prvavijest_271014_lol.png"},

                new News { Title = "Cetvrta vijest",
                           Text = "Text vijesti treba biti ogranicen na 50 znakova na pocetnoj.",
                           ImagePath = "~/uploads\\Prvavijest_271014_lol.png",
                           ThumbPath = "~/uploads\\thumb_Prvavijest_271014_lol.png"},

                new News { Title = "Peta vijest",
                           Text = "Text vijesti treba biti ogranicen na 50 znakova na pocetnoj.",
                           ImagePath = "~/uploads\\Prvavijest_271014_lol.png",
                           ThumbPath = "~/uploads\\thumb_Prvavijest_271014_lol.png"},
                
                new News { Title = "Sesta vijest",
                           Text = "Text vijesti treba biti ogranicen na 50 znakova na pocetnoj.",
                           ImagePath = "~/uploads\\Prvavijest_271014_lol.png",
                           ThumbPath = "~/uploads\\thumb_Prvavijest_271014_lol.png"},

                new News { Title = "Sedma vijest",
                           Text = "Text vijesti treba biti ogranicen na 50 znakova na pocetnoj.",
                           ImagePath = "~/uploads\\Prvavijest_271014_lol.png",
                           ThumbPath = "~/uploads\\thumb_Prvavijest_271014_lol.png"},

                new News { Title = "Osma vijest",
                           Text = "Text vijesti treba biti ogranicen na 50 znakova na pocetnoj.",
                           ImagePath = "~/uploads\\Prvavijest_271014_lol.png",
                           ThumbPath = "~/uploads\\thumb_Prvavijest_271014_lol.png"}
                );
        }
    }
}
