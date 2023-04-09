namespace Universum.Misc;

internal interface IPiece
{
    string Name { get; set; }
    string Author { get; }

    Piece.PieceType Type { get; }
    string Description { get; set; }
}