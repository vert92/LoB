namespace LeagueOfBalkan.Migrations
{
    using LeagueOfBalkan.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LeagueOfBalkan.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LeagueOfBalkan.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.News.AddOrUpdate(
                n => n.Title,
                new News
                {
                    Title = "Prva vijest lorem ipsum test",
                    Text = "Lorem impsum lorem ipsum lorem ipsum lorem",
                    ImagePath = "~/uploads/Prvavijest_271014_lol.png",
                    ThumbPath = "~/uploads/thumb_Prvavijest_271014_lol.png"
                },
                new News
                {
                    Title = "Druga vijest lorem ipsum test",
                    Text = "Lorem impsum lorem ipsum lorem ipsum lorem",
                    ImagePath = "~/uploads/Prvavijest_271014_lol.png",
                    ThumbPath = "~/uploads/thumb_Prvavijest_271014_lol.png"
                },
                new News
                {
                    Title = "Treca vijest lorem ipsum test",
                    Text = "Lorem impsum lorem ipsum lorem ipsum lorem",
                    ImagePath = "~/uploads/Prvavijest_271014_lol.png",
                    ThumbPath = "~/uploads/thumb_Prvavijest_271014_lol.png"
                },
                new News
                {
                    Title = "Cetvrta vijest lorem ipsum test",
                    Text = "Lorem impsum lorem ipsum lorem ipsum lorem",
                    ImagePath = "~/uploads/Prvavijest_271014_lol.png",
                    ThumbPath = "~/uploads/thumb_Prvavijest_271014_lol.png"
                },
                new News
                {
                    Title = "Peta vijest lorem ipsum test",
                    Text = "Lorem impsum lorem ipsum lorem ipsum lorem",
                    ImagePath = "~/uploads/Prvavijest_271014_lol.png",
                    ThumbPath = "~/uploads/thumb_Prvavijest_271014_lol.png"
                },
                new News
                {
                    Title = "Sesta vijest lorem ipsum test",
                    Text = "Lorem impsum lorem ipsum lorem ipsum lorem",
                    ImagePath = "~/uploads/Prvavijest_271014_lol.png",
                    ThumbPath = "~/uploads/thumb_Prvavijest_271014_lol.png"
                },
                new News
                {
                    Title = "Sedma vijest lorem ipsum test",
                    Text = "Lorem impsum lorem ipsum lorem ipsum lorem",
                    ImagePath = "~/uploads/Prvavijest_271014_lol.png",
                    ThumbPath = "~/uploads/thumb_Prvavijest_271014_lol.png"
                },
                new News
                {
                    Title = "Osma vijest lorem ipsum test",
                    Text = "Lorem impsum lorem ipsum lorem ipsum lorem",
                    ImagePath = "~/uploads/Prvavijest_271014_lol.png",
                    ThumbPath = "~/uploads/thumb_Prvavijest_271014_lol.png"
                }
                );

            //context.TwitchData.AddOrUpdate(
            //    t => t.ID,
            //    new TwitchData { ID = 0, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 1, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 2, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 3, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 4, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 5, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 6, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 7, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 8, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 9, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 10, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 11, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 12, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 13, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 14, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 15, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 16, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 17, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 18, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 19, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 20, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 21, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 22, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 23, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" },
            //    new TwitchData { ID = 24, viewers = 0, medium = "test", display_name = "test", logo = "test", status = "test", url = "test" }
            //    );

        }
    }
}
