using System.Text.Json;

namespace Universum.Misc;

public class Piece : IPiece
{
    public string Name { get; set; }

    public JsonElement JsonRepresentation { get; set; }

    public PieceType Type { get; }
    public enum PieceType
    {
        Book,
        Movie
    }

    /// TODO: This documentation.
    public static async Task<Piece> GetPieceAsync(string name, PieceType type)
    {
        var bookInfo = await WebVerification.TryGetBookAsync(name);

        return new Piece(bookInfo.GetProperty(nameof(Name)).GetString(), type);
    }

    public Piece(string name, PieceType type)
    {
        Name = name;
        Type = type;
    }

    public Piece(JsonElement representation)
    {
        Name = representation.GetProperty(nameof(Name)).ToString();

        JsonRepresentation = representation;
    }
}
