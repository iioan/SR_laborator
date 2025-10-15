using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Recombee.ApiClient;
using Recombee.ApiClient.ApiRequests;
using Recombee.ApiClient.Util;
using SR_lab;

class Program
{
    static async Task Main()
    {
        var client = new RecombeeClient(
            "ioanteo-dev",
            "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
            region: Region.EuWest);

        using var reader = new StreamReader("rolling_stone.csv");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var rows = csv.GetRecords<dynamic>()
            .Select(r => new AlbumRow
            {
                CleanName = (string)r.clean_name,
                Album = (string)r.album,
                ReleaseYear = $"{r.release_year}",
                Genre = (string)r.genre
            })
            .ToList();
        Console.WriteLine($"Loaded {rows.Count} albums from CSV");

        try
        {
            await client.SendAsync(new AddItemProperty("clean_name", "string"));
            await client.SendAsync(new AddItemProperty("album", "string"));
            await client.SendAsync(new AddItemProperty("release_year", "string"));
            await client.SendAsync(new AddItemProperty("genre", "string"));
            Console.WriteLine("Item properties created");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Properties may already exist: {ex.Message}");
        }

        var batchSize = 100;
        for (int i = 0; i < rows.Count; i += batchSize)
        {
            var batch = rows.Skip(i).Take(batchSize).ToList();
            var requests = batch.Select((row, index) =>
                new SetItemValues(
                    $"album-{i + index}", 
                    new Dictionary<string, object>
                    {
                        { "clean_name", row.CleanName },
                        { "album", row.Album },
                        { "release_year", row.ReleaseYear },
                        { "genre", row.Genre }
                    },
                    cascadeCreate: true
                )
            ).ToArray();

            try
            {
                await client.SendAsync(new Batch(requests));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding batch: {ex.Message}");
            }
        }
        
        Console.WriteLine("All albums added to Recombee!");
    }
}