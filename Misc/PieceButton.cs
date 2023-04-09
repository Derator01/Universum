namespace Universum.Misc;

class PieceButton : ImageButton, IView, IPiece
{
    public string Name { get; set; }
    public string Author { get; }
    public Piece.PieceType Type { get; }

    public string StringSource { get; }
    public string Description { get; set; }

    public PieceButton(string name, string author, Piece.PieceType type, string source, string description = "")
    {
        Name = name;
        Author = author;
        Type = type;
        StringSource = source;
        Source = source;
        Description = description;
    }
}
