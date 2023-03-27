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

        _recommendedStLayout = File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, "recommended.sav")) ? Load<HorizontalStackLayout>("recommended.sav") : new();
        _favoriteStLayout = File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, "favorite.sav")) ? Load<HorizontalStackLayout>("favorite.sav") : new();
        _currentStLayout = File.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, "current.sav")) ? Load<HorizontalStackLayout>("current.sav") : new();

        //int smth = _recommendedStLayout.Count;
        for (int i = 0; i < 11; i++)
        {
            var index = i;
            _recommendedStLayout.Add(new Image() { Source = $"p{index}.png", MaximumWidthRequest = 500, HeightRequest = 100 });
        }

        MainLayout.Add(new Label() { Text = "Recommendations", Margin = new(10) });

        ScrollView recommendedScroll = new() { Orientation = ScrollOrientation.Horizontal, Content = _recommendedStLayout };

        MainLayout.Add(recommendedScroll);
        MainLayout.Add(new Label() { Text = "Favorite", Margin = new(10) });

        ScrollView favoriteScroll = new() { Orientation = ScrollOrientation.Horizontal, Content = _favoriteStLayout };

        MainLayout.Add(favoriteScroll);
        MainLayout.Add(new Label() { Text = "Reading now", Margin = new(10) });

        ScrollView currentScroll = new() { Orientation = ScrollOrientation.Horizontal, Content = _currentStLayout };

        MainLayout.Add(currentScroll);

        SaveCollection("recommended.sav", _favoriteStLayout);

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