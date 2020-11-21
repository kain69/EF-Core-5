using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbLOL
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Create
            /*using (ApplicationContext db = new ApplicationContext())
            {
                List<Role> roles = new List<Role>()
                {
                    new Role { Name = "Mage"},
                    new Role { Name = "Fighter"},
                    new Role { Name = "Assassin"},
                    new Role { Name = "Tank"},
                    new Role { Name = "Support"},
                    new Role { Name = "Marksman"}
                };
                db.Roles.AddRange(roles);

                List<Region> regions = new List<Region>()
                {
                    new Region { Name = "Bandle City"},
                    new Region { Name = "Bilgewater"},
                    new Region { Name = "Demacia"},
                    new Region { Name = "Ionia"},
                    new Region { Name = "Ixtal"},
                    new Region { Name = "Noxus"},
                    new Region { Name = "Piltover"},
                    new Region { Name = "Shadow Isles"},
                    new Region { Name = "Shurima"},
                    new Region { Name = "Targon"},
                    new Region { Name = "The Freljord"},
                    new Region { Name = "The Void"},
                    new Region { Name = "Zaun"}
                };
                db.Regions.AddRange(regions);

                List<Champion> champions = new List<Champion>()
                {
                    new Champion { Name = "Teemo",          Region = regions.Single(r => r.Name == "Bandle City"),  Role = roles.Single(r => r.Name == "Marksman")},
                    new Champion { Name = "Pyke",           Region = regions.Single(r => r.Name == "Bilgewater"),   Role = roles.Single(r => r.Name == "Support")},
                    new Champion { Name = "Fiora",          Region = regions.Single(r => r.Name == "Demacia"),      Role = roles.Single(r => r.Name == "Fighter")},
                    new Champion { Name = "Yasuo",          Region = regions.Single(r => r.Name == "Ionia"),        Role = roles.Single(r => r.Name == "Fighter")},
                    new Champion { Name = "Rengar",         Region = regions.Single(r => r.Name == "Ixtal"),        Role = roles.Single(r => r.Name == "Assassin")},
                    new Champion { Name = "Riven",          Region = regions.Single(r => r.Name == "Noxus"),        Role = roles.Single(r => r.Name == "Fighter")},
                    new Champion { Name = "Camille",        Region = regions.Single(r => r.Name == "Piltover"),     Role = roles.Single(r => r.Name == "Fighter")},
                    new Champion { Name = "Karthus",        Region = regions.Single(r => r.Name == "Shadow Isles"), Role = roles.Single(r => r.Name == "Mage")},
                    new Champion { Name = "Azir",           Region = regions.Single(r => r.Name == "Shurima"),      Role = roles.Single(r => r.Name == "Mage")},
                    new Champion { Name = "Aurelion Sol",   Region = regions.Single(r => r.Name == "Targon"),       Role = roles.Single(r => r.Name == "Mage")},
                    new Champion { Name = "Nunu & Willump", Region = regions.Single(r => r.Name == "The Freljord"), Role = roles.Single(r => r.Name == "Tank")},
                    new Champion { Name = "Kha`Zix",        Region = regions.Single(r => r.Name == "The Void"),     Role = roles.Single(r => r.Name == "Assassin")},
                    new Champion { Name = "Ekko",           Region = regions.Single(r => r.Name == "Zaun"),         Role = roles.Single(r => r.Name == "Assassin")}
                };
                db.Champions.AddRange(champions);
                db.SaveChanges();
            }*/
            #endregion

            #region Read
            using (ApplicationContext db = new ApplicationContext())
            {
                // получаем Регионы
                var regions = db.Regions
                    .Include(r => r.Champions)
                    .ThenInclude(ch => ch.Role)
                    .ToList();

                foreach (var region in regions)
                {
                    Console.WriteLine($"{region.Name}: ");
                    foreach (var champion in region.Champions)
                    {
                        Console.WriteLine($"Имя: {champion.Name, -15} Роль: {champion.Role.Name,-9}");
                    }
                    Console.WriteLine("--------------------------------------------");
                }
            }
            #endregion

            Console.ReadLine();
        }
    }
}
