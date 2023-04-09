using Universum.Misc;

namespace Universum;

[SavePath("Pieces.klin")]
public partial class NewPiecePage : ContentPage
{
    private string _name;
    private string _author;
    private Piece.PieceType _type = Piece.PieceType.Book;
    private string _description;

    public NewPiecePage()
    {
        InitializeComponent();
    }

    private void NameEtr_Completed(object sender, EventArgs e)
    {
        _name = NameEtr.Text;
        DescriptionEtr.Focus();
    }

    private void PieceTypeBtn_Clicked(object sender, EventArgs e)
    {
        if (_type is Piece.PieceType.Book)
        {
            _type = Piece.PieceType.Movie;
            PieceTypeBtn.Text = nameof(Piece.PieceType.Movie);
        }
        else
        {
            _type = Piece.PieceType.Book;
            PieceTypeBtn.Text = nameof(Piece.PieceType.Book);
        }
    }

    private void DescriptionEtr_Completed(object sender, EventArgs e)
    {
        _name = DescriptionEtr.Text;
    }

    private void EnterBtn_Clicked(object sender, EventArgs e)
    {
        Storage.AddPiece(new Piece(_name, _author, _type, _description));
    }
}