using Microsoft.Extensions.Configuration;
using Recombee.ApiClient;
using Recombee.ApiClient.Util;
using SR_lab.lab1;
using SR_lab.lab2;

namespace SR_lab;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("=== SR Labs ===\n");

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var databaseId = config["Recombee:DatabaseId"]!;
        var secretToken = config["Recombee:SecretToken"]!;

        var client = new RecombeeClient(databaseId, secretToken, region: Region.EuWest);
        
        Console.WriteLine("1. Lab 1");
        Console.WriteLine("2. Lab 2");
        Console.WriteLine("3. Run All");
        Console.Write("\nChoose: ");
        
        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                await Lab1.Run(client);
                break;
            case "2":
                await Lab2.Run(client);
                break;
            case "3":
                await Lab1.Run(client);
                await Lab2.Run(client);
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }

        Console.WriteLine("\nDone!");
    }
}