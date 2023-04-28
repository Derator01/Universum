namespace Universum.Misc;

public static class Storage
{
    private const string FILE_EXTENSION = ".md";

    public static void AddPiece(IPiece piece)
    {
        string fileName = piece.Name.ToPascalCase();

        if (string.IsNullOrEmpty(fileName.Trim()))
            throw new Exception("Name of the piece must include not only white spaces");

        string path = Path.Combine(FileSystem.Current.AppDataDirectory, fileName + FILE_EXTENSION);

        if (!File.Exists(path))
            File.Create(path).Close();

        StreamWriter streamWriter = new(File.OpenWrite(path));

        streamWriter.Write(piece.JsonRepresentation.ToMarkdown());
        //streamWriter.Flush();
        streamWriter.Close();
    }

    public static IPiece? GetPiece(string pieceName)
    {
        string path = Path.Combine(FileSystem.Current.AppDataDirectory, pieceName.Trim().ToPascalCase() + FILE_EXTENSION);
        if (!File.Exists(path))
            return null;

        return new Piece(File.ReadAllText(path).ToJsonElement());
    }
}