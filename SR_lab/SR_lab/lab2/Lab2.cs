using System.Globalization;
using CsvHelper;
using Recombee.ApiClient;
using Recombee.ApiClient.ApiRequests;
using Recombee.ApiClient.Util;

namespace SR_lab.lab2;

public class Lab2
{
    public static async Task Run(RecombeeClient client)
    {
        using var reader = new StreamReader("lab2/customers-100.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        csv.Context.RegisterClassMap<CustomerRowMap>();
        var rows = csv.GetRecords<CustomerRow>().ToList();
        Console.WriteLine($"Loaded {rows.Count} customers");

        try
        {
            await client.SendAsync(new AddUserProperty("first_name", "string"));
            await client.SendAsync(new AddUserProperty("last_name", "string"));
            await client.SendAsync(new AddUserProperty("country", "string"));
            await client.SendAsync(new AddUserProperty("phone", "string"));
            await client.SendAsync(new AddUserProperty("email", "string"));
            Console.WriteLine("Properties created");
        }
        catch
        {
            Console.WriteLine("Properties already exist");
        }

        var batchSize = 100;
        for (int i = 0; i < rows.Count; i += batchSize)
        {
            var batch = rows.Skip(i).Take(batchSize).ToList();
            var requests = batch.Select(row =>
                new SetUserValues(
                    row.CustomerId,
                    new Dictionary<string, object>
                    {
                        { "first_name", row.FirstName },
                        { "last_name", row.LastName },
                        { "country", row.Country },
                        { "phone", row.Phone },
                        { "email", row.Email }
                    },
                    cascadeCreate: true
                )
            ).ToArray();
        
            await client.SendAsync(new Batch(requests));
            Console.WriteLine($"Added batch {i / batchSize + 1}");
        }
        
        Console.WriteLine("All users added to Recombee!");
    }
}