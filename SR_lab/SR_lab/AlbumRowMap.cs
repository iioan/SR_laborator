using CsvHelper.Configuration;

namespace SR_lab;

public sealed class AlbumRowMap : ClassMap<AlbumRow>
{
    public AlbumRowMap()
    {
        Map(m => m.CleanName).Name("clean_name");
        Map(m => m.Album).Name("album");
        Map(m => m.ReleaseYear).Name("release_year");
        Map(m => m.Genre).Name("genre");
    }
}