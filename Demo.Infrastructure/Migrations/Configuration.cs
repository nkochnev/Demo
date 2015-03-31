using System.Collections.Generic;

namespace Demo.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Demo.Infrastructure.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Demo.Infrastructure.DataContext context)
        {
            //var spartak = new Team { Title = "Спартак", City = Cities.Moscow };
            //var zenit = new Team { Title = "Зенит", City = Cities.StPeterburg };
            //var ural = new Team { Title = "Урал", City = Cities.Ekb };

            //var smolov = new Player { Name = "Смолов" };
            //var hulk = new Player { Name = "Халк", Team = zenit };
            //var rebrov = new Player { Name = "Ребров", Team = spartak };

            //var players = new List<Player> { smolov };
            //ural.Players = players;

            //context.Teams.Add(spartak);
            //context.Teams.Add(zenit);
            //context.Teams.Add(ural);

            //context.Players.Add(smolov);
            //context.Players.Add(hulk);
            //context.Players.Add(rebrov);

            //context.SaveChanges();
        }
    }
}
