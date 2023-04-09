namespace Universum.Misc;

public class Piece : IPiece
{
    public string Name { get; set; }
    public string Author { get; }

    public PieceType Type { get; }

    public string Description { get; set; }

    public enum PieceType
    {
        Book,
        Movie
    }

    public Piece(string name, string author, PieceType type, string description = "")
    {
        Name = name;
        Author = author;
        Type = type;
        Description = description;
    }
}
