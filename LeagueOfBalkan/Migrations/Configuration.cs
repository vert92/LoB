namespace LeagueOfBalkan.Migrations
{
    using LeagueOfBalkan.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LeagueOfBalkan.Models.LoBDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LeagueOfBalkan.Models.LoBDb context)
        {
            context.News.AddOrUpdate(n => n.ID,
                new News
                {
                    Title = "Prva vijest",
                    Text = "Text prve vijesti limit treba biti na oko 50 znakova",
                    ImagePath = "~/uploads\\lol.png"
                },
                new News
                {
                    Title = "Druga vijest",
                    Text = "Text druge vijesti limit treba biti na oko 50 znakova",
                    ImagePath = "~/uploads\\lol.png"
                },
                new News
                {
                    Title = "Treca vijest",
                    Text = "Text Trece vijesti limit treba biti na oko 50 znakova",
                    ImagePath = "~/uploads\\lol.png"
                },
                new News
                {
                    Title = "Cetvrta vijest",
                    Text = "Text Cetvrta vijesti limit treba biti na oko 50 znakova",
                    ImagePath = "~/uploads\\lol.png"
                },
                new News
                {
                    Title = "Peta vijest",
                    Text = "Text Peta vijesti limit treba biti na oko 50 znakova",
                    ImagePath = "~/uploads\\lol.png"
                },
                new News
                {
                    Title = "Sesta vijest",
                    Text = "Text Sesta vijesti limit treba biti na oko 50 znakova",
                    ImagePath = "~/uploads\\lol.png"
                },
                new News
                {
                    Title = "Sedma vijest",
                    Text = "Text Sedma vijesti limit treba biti na oko 50 znakova",
                    ImagePath = "~/uploads\\lol.png"
                },
                new News
                {
                    Title = "Osma vijest",
                    Text = "Text Osma vijesti limit treba biti na oko 50 znakova",
                    ImagePath = "~/uploads\\lol.png"
                });
        }
    }
}
