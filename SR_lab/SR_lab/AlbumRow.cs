namespace SR_lab;

public class AlbumRow
{
    public string CleanName { get; set; } = "";
    public string Album { get; set; } = "";
    public string ReleaseYear { get; set; } = ""; // lasă-l string dacă nu e garantat numeric
    public string Genre { get; set; } = "";
}