namespace Universum.Misc;

class PieceButton : ImageButton, IView
{
    public string Name { get; set; }
    public string Author { get; }

    public string StringSource { get; }

    public PieceButton(string name, string author, string source)
    {
        Name = name;
        Author = author;
        StringSource = source;
        Source = source;
    }
}
