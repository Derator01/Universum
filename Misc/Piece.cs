using System.Text.Json;

namespace Universum.Misc;

public class Piece : IPiece
{
    public string Name { get; set; }

    public int ISBN { get; }

    public string? Authors { get; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public JsonElement JsonRepresentation { get; set; }

    public PieceType Type { get; }
    public enum PieceType
    {
        Book,
        Movie
    }

    public Piece(string name)
    {

    }

    public Piece(string name, PieceType type)
    {
        Name = name;
        Type = type;

        WebVerification.
    }

    public Piece(string name, string author, PieceType type, string description = null)
    {
        Name = name;
        Authors = author;
        Type = type;
        Description = description;
    }

    public Piece(JsonElement representation)
    {
        Name = representation.GetProperty(nameof(Name)).ToString();

        representation.TryGetProperty(nameof(Authors), out JsonElement authorsJson);
        authorsJson.ToString();
        JsonRepresentation = representation;
    }
}
