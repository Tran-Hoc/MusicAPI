using System.ComponentModel;

public class GenreVM
{   
    public int IdGenre { get; set; }
    [DisplayName("Thể loại")]
    public string? NameGenre { get; set; }
}