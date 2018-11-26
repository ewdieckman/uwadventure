using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using UWAdventure.Data;


namespace UWAdventure.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //setup configuration to mimic ASP.NET configuration
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json");
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddScoped<IDbUWAdventure, DbUWAdventure>(
                    provider => new DbUWAdventure(
                        config
                    ))

                //register DAO objects

                //register business services


                .BuildServiceProvider();

            Console.WriteLine("Hello World!");


            Console.WriteLine("Hit any key to close this windows...");
            Console.ReadKey();
        }
    }
}
