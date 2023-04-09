namespace Universum.Misc;

class PieceButton : ImageButton, IView, IPiece
{
    public string Name { get; set; }
    public string Author { get; }
    public Piece.PieceType Type { get; }

    public string StringSource { get; }

    public PieceButton(string name, string author, Piece.PieceType type, string source)
    {
        Name = name;
        Author = author;
        Type = type;
        StringSource = source;
        Source = source;
    }
}
