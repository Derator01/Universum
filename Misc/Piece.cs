namespace Universum.Misc;

public class Piece : IPiece
{
    public string Name { get; set; }
    public string Authors { get; }

    public PieceType Type { get; }

    public int Year { get; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public enum PieceType
    {
        Book,
        Movie
    }

    public Piece(string name, string author, PieceType type, int year, string description = "", string imageUrl = null)
    {
        Name = name;
        Authors = author;
        Type = type;
        Description = description;
        Year = year;
        ImageUrl = imageUrl;
    }
}
