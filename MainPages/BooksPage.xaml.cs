using Universum.Misc;
#if ANDROID
using Browser = Android.Provider.Browser;
#endif

#if IOS
using Foundation;
#endif


using System.Text.Json;

namespace Universum;

public partial class BooksPage : ContentPage
{
    public const string SavePath = "file.sav";

    private readonly HorizontalStackLayout _recommendedStLayout;
    private readonly HorizontalStackLayout _favoriteStLayout;
    private readonly HorizontalStackLayout _currentStLayout;

    public BooksPage()
    {
        InitializeComponent();

        _recommendedStLayout = new();
        _favoriteStLayout = new();
        _currentStLayout = new();

        if (File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, "recommended.sav")))
            foreach (var source in Load<IEnumerable<string>>("recommended.sav"))
                _recommendedStLayout.Add(new PieceButton("smth", "Me", source) { MaximumWidthRequest = 500, HeightRequest = 100 });
        if (File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, "favorite.sav")))
            foreach (var source in Load<IEnumerable<string>>("recommended.sav"))
                _favoriteStLayout.Add(new PieceButton("smth", "Me", source) { MaximumWidthRequest = 500, HeightRequest = 100 });
        if (File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, "current.sav")))
            foreach (var source in Load<IEnumerable<string>>("current.sav"))
                _currentStLayout.Add(new PieceButton("smth", "Me", source) { MaximumWidthRequest = 500, HeightRequest = 100 });

        for (int i = 0; i < 11; i++)
        {
            _recommendedStLayout.Add(new PieceButton("smth", "Me", $"p{i}.png") { MaximumWidthRequest = 500, HeightRequest = 100 });
        }

        #region Main part
        MainLayout.Add(new Label() { Text = "Recommendations", Margin = new(10) });

        ScrollView recommendedScroll = new() { Orientation = ScrollOrientation.Horizontal, Content = _recommendedStLayout };

        MainLayout.Add(recommendedScroll);
        MainLayout.Add(new Label() { Text = "Favorite", Margin = new(10) });

        ScrollView favoriteScroll = new() { Orientation = ScrollOrientation.Horizontal, Content = _favoriteStLayout };

        MainLayout.Add(favoriteScroll);
        MainLayout.Add(new Label() { Text = "Reading now", Margin = new(10) });

        ScrollView currentScroll = new() { Orientation = ScrollOrientation.Horizontal, Content = _currentStLayout };

        MainLayout.Add(currentScroll);
        #endregion

        SaveCollection("recommended.sav", _recommendedStLayout.Children.Select(x => ((PieceButton)x).StringSource));

        //Unfocused += (s, e) => SaveCollection("recommended.sav", _recommendedStLayout);
    }

    private void SaveCollection<T>(string fileName, T collection)
    {
        var filePath = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);

        if (!File.Exists(filePath))
            File.Create(filePath).Close();

        string contents = JsonSerializer.Serialize(collection);
        File.WriteAllText(filePath, contents);
    }

    private T Load<T>(string fileName)
    {
        var filePath = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);

        return JsonSerializer.Deserialize<T>(File.ReadAllText(filePath));
    }

    //private static string Decode(string text) => Encoding.UTF8.GetString(Encoding.ASCII.GetBytes(text));

    //private static string Encode(string text) => Encoding.ASCII.GetString(Encoding.UTF8.GetBytes(text));
}