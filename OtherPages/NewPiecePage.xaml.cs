using Universum.Misc;

namespace Universum;

[SavePath("Pieces.klin")]
public partial class NewPiecePage : ContentPage
{
    private string _name;
    private string _author;
    private Piece.PieceType _type = Piece.PieceType.Book;
    private int _year = 0;
    private string _description;
    private string _imageUrl;

    public NewPiecePage()
    {
        InitializeComponent();
    }

    private void NameEtr_Completed(object sender, EventArgs e)
    {
        _name = NameEtr.Text;
        AuthorsEtr.Focus();
    }

    private void AuthorsEtr_Completed(object sender, EventArgs e)
    {
        _author = AuthorsEtr.Text;
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
        _description = DescriptionEtr.Text;
        ImageEtr.Focus();
    }

    private void ImageEtr_Completed(object sender, EventArgs e)
    {
        _imageUrl = ImageEtr.Text;
    }

    private void EnterBtn_Clicked(object sender, EventArgs e)
    {
        _name = NameEtr.Text;
        _author = AuthorsEtr.Text;
        _description = DescriptionEtr.Text;
        _imageUrl = ImageEtr.Text;

        Storage.AddPiece(new Piece(_name, _type));
    }
}