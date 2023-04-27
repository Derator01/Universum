using System.Text.Json;

namespace Universum.Misc;

class PieceButton : ImageButton, IView, IPiece
{
    public string Name { get; set; }

    public string StringSource { get; }

    public string? ImageUrl { get; set; }

    public Piece.PieceType Type { get; }
    public JsonElement JsonRepresentation { get; set; }

    public PieceButton(string name, Piece.PieceType type, string source)
    {
        Name = name;
        Type = type;
        StringSource = source;
        Source = source;
    }

    public PieceButton(string source, Piece.PieceType type, JsonElement jsonRepresentation)
    {
        Name = jsonRepresentation.GetProperty(nameof(Name)).ToString();
        StringSource = source;
        Type = type;
        JsonRepresentation = jsonRepresentation;
    }
}
