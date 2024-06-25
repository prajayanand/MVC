namespace ApplicationCore.Entities;

public class Trailer
{
    public int Id { get; set; }
    public string TrailerUrl { get; set; }
    public string Name { get; set; }
    
    //fk
    public int MovieId { get; set; }
    
    //navigation prop
    public Movie Movie { get; set; }
    
}