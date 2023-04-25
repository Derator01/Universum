namespace Universum.Misc;

class PieceButton : ImageButton, IView, IPiece
{
    public string Name { get; set; }
    public string Authors { get; }
    public Piece.PieceType Type { get; }

    public string StringSource { get; }
    public string Description { get; set; }

    public int Year { get; }

    public string ImageUrl { get; set; }

    public PieceButton(string name, string author, Piece.PieceType type, string source, string description = "")
    {
        Name = name;
        Authors = author;
        Type = type;
        StringSource = source;
        Source = source;
        Description = description;
    }
}
