using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Infrastructure;

namespace Demo.CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            RepositoryStyle();
            
            Console.WriteLine("End");
        }

        private static void OldSchool()
        {
            Console.WriteLine("OldSchool");

            using (var context = new DataContext())
            {
                var teams = context.Teams.ToList();

                foreach (var team in teams)
                {
                    Console.WriteLine(team.Title);
                    foreach (var player in team.Players)
                    {
                        Console.WriteLine("-" + player.Name);
                    }
                }

                var t = new Team();
                t.Title = "KrSovetov";
                t.City = Cities.Ekb;
                context.Teams.Add(t);
                context.SaveChanges();
            }
        }

        private static void RepositoryStyle()
        {
            Console.WriteLine("RepositoryStyle");

            using (var context = new DataContext())
            {
                var repository = new EfRepository<Team>(context);
                var teams = repository.Table.ToList();

                foreach (var team in teams)
                {
                    Console.WriteLine(team.Title);
                    foreach (var player in team.Players)
                    {
                        Console.WriteLine("-" + player.Name);
                    }
                }

                //var dinamo = new Team() {Title = "Dinamo", City = Cities.Moscow};
                //repository.Insert(dinamo);
            }
        }
    }
}