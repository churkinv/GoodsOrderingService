namespace Data.Migrations
{
    using Gos.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gos.Data.GosDbContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Gos.Data.GosDbContex context)
        {
            context.Customers.AddOrUpdate(f => f.FirstName,
                new Customer
                {
                    FirstName = "Lesia",
                    LastName = "Ukrainka",
                    City = "Kyiv",
                    Region = "Kyiv",
                    Street = "Urlovskaya",
                    Phone = "+38050000909",
                    Zip = "101203",
                    Email = "lesya@email.com"
                },
                new Customer
                {
                    FirstName = "Petro",
                    LastName = "Doroshenko",
                    City = "Zaporizhzhia",
                    Region = "Zaporizhzhian",
                    Street = "Soborniy",
                    Phone = "+38050000910",
                    Zip = "69300",
                    Email = "petro@email.com"
                },
                new Customer
                {
                    FirstName = "Mihailo",
                    LastName = "Grushevskiy",
                    City = "Kyiv",
                    Region = "Kyiv",
                    Street = "Lesi Ukrainki",
                    Phone = "+38050000111",
                    Zip = "101203",
                    Email = "mihailo@email.com"
                },
                new Customer
                {
                    FirstName = "Stepan",
                    LastName = "Bandera",
                    City = "Lviv",
                    Region = "Lviv",
                    Street = "Banderi",
                    Phone = "+38050000789",
                    Zip = "101243",
                    Email = "stepan@email.com"
                });

            context.Products.AddOrUpdate(n => n.Name,
                new Product { Name = "Kartoplya", Description = "Very tasty high quality", Type = "Vegatables" },
                new Product { Name = "Pomidor", Description = "Tasty and high quality", Type = "Vegatables" },
                new Product { Name = "Ogirok", Description = "Very tasty high quality", Type = "Vegatables" },
                new Product { Name = "Cibulya", Description = "Very tasty high quality", Type = "Vegatables" },
                new Product { Name = "Hlib", Description = "Very tasty high quality", Type = "Bakery" },
                new Product { Name = "Bulochka", Description = "Very tasty high quality", Type = "Bakery" },
                new Product { Name = "Moloko", Description = "Very tasty high quality", Type = "Diary" },
                new Product { Name = "Sir", Description = "Very tasty high quality", Type = "Diary" },
                new Product { Name = "Kovbasa", Description = "Very tasty high quality", Type = "Meat" },
                new Product { Name = "Skovorodka", Description = "High quality", Type = "Cookware" },
                new Product { Name = "Kastrylya", Description = "High quality", Type = "Cookware" },
                new Product { Name = "Televizor", Description = "High quality", Type = "CE" },
                new Product { Name = "Akustichna Sistema", Description = "High quality", Type = "CE" },
                new Product { Name = "Pizza", Description = "Very tasty high quality", Type = "Pizzas" },
                new Product { Name = "Oliv`e", Description = "Very tasty high quality", Type = "Salads" },
                new Product { Name = "Pizza Paperoni", Description = "Very tasty high quality", Type = "Pizzas" },
                new Product { Name = "Cesar", Description = "Very tasty high quality", Type = "Salads" },
                new Product { Name = "Jabluka", Description = "Very tasty high quality", Type = "Fruits" },
                new Product { Name = "Sliva", Description = "Very tasty high quality", Type = "Fruits" }
                );

        }
    }
}
