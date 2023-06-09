﻿using HtmlAgilityPack;

#if ANDROID
using Browser = Android.Provider.Browser;
#elif IOS
using Foundation;
#endif

namespace Universum;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();

    }

    #region Some Web Methods

    //    private void GetHistory()
    //    {
    //#if ANDROID
    //        var uri = Browser.BookmarksUri;
    //        var projection = new string[]
    //        {
    //            Browser.BookmarkColumns.Url,
    //            Browser.BookmarkColumns.Title,
    //            Browser.BookmarkColumns.Date
    //        };

    //        var cursor = Android.App.Application.Context.ContentResolver.Query(
    //            uri,
    //            projection,
    //            null,
    //            null,
    //            Browser.BookmarkColumns.Date + " DESC");

    //        if (cursor != null && cursor.MoveToFirst())
    //        {
    //            while (cursor.MoveToNext())
    //            {
    //                string url = cursor.GetString(cursor.GetColumnIndex(projection[0]));
    //                string title = cursor.GetString(cursor.GetColumnIndex(projection[1]));
    //                long timestamp = cursor.GetLong(cursor.GetColumnIndex(projection[2]));

    //                // Do something with the URL, title, and timestamp
    //            }
    //        }

    //        cursor?.Close();
    //#endif
    //#if IOS
    //        ///Doesn't work
    //*
    //var userActivity = new NSUserActivity("com.myapp.browsing-history");
    //        if (userActivity.WebpageUrl != null)
    //{
    //    var historyItems = userActivity.WebpageUrl.GetHistoryItems(out var currentHistoryItem);

    //    foreach (var item in historyItems)
    //    {
    //        string url = item.Url.ToString();
    //        string title = item.Title;
    //        var timestamp = item.Date;

    //        // Do something with the URL, title, and timestamp
    //    }
    //}*/
    //#endif
    //    }

    ///// <summary>
    ///// Doesn't work.
    ///// </summary>
    //[Obsolete]
    //private async void LogIntoAccount()
    //{
    //    HttpClient _httpClient = new();

    //    var email = "";
    //    var password = "";

    //    var url = "https://ranobehub.org/login";

    //    var loginData = new
    //    {
    //        email,
    //        password
    //    };

    //    var content = new StringContent(JsonSerializer.Serialize(loginData), Encoding.UTF8, "application/json");

    //    try
    //    {
    //        var response = await _httpClient.PostAsync(url, content);

    //        if (response.IsSuccessStatusCode)
    //        {

    //            if (response.Headers.TryGetValues("Set-Cookie", out var setCookieValues))
    //            {
    //                foreach (var setCookieValue in setCookieValues)
    //                {
    //                    if (setCookieValue.Contains("auth_cookie"))
    //                    {
    //                        DebugLbl.Text = "Login successful!";
    //                        await DisplayAlert("Success", "Logged in successfully!", "OK");
    //                    }
    //                }
    //            }

    //            // Navigate to another page or perform any other action upon successful login
    //        }
    //        else
    //        {
    //            await DisplayAlert("Error", "Invalid username or password!", "OK");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
    //    }
    //}

    //private static string ExtractCsrfTokenFromResponse(HttpResponseMessage response)
    //{
    //    string token = null;
    //    var content = response.Content.ReadAsStringAsync().Result;
    //    var doc = new HtmlDocument();
    //    doc.LoadHtml(content);
    //    var tokenInput = doc.DocumentNode.Descendants("input")
    //        .FirstOrDefault(i => i.Attributes["name"]?.Value == "csrf_token");
    //    if (tokenInput != null)
    //    {
    //        token = tokenInput.Attributes["value"]?.Value;
    //    }
    //    return token;
    //}

    /// <summary>
    /// Uses the link specified
    /// </summary>
    /// <returns>
    /// A title if there is one.
    /// If there is no title on the webpage returns "Error: Could not find book title."
    /// If <see cref="HttpClient"/> throws "Error: Failed to retrieve web page."
    /// </returns>
    private static async Task<string> GetTitleThroughUrlAsync(string url)
    {
        HttpResponseMessage response = await new HttpClient().GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            HtmlDocument htmlDoc = new();

            htmlDoc.LoadHtml(await response.Content.ReadAsStringAsync());

            // Might not work with every site
            HtmlNode titleNode = htmlDoc.DocumentNode.SelectSingleNode("//title");

            string bookTitle = titleNode?.InnerText;
            if (string.IsNullOrWhiteSpace(bookTitle))
            {
                return "Error: Could not find book title.";
            }
            else
            {
                return $"Book title: {bookTitle.Split('/')[0]}";
            }
        }
        else
        {
            return "Error: Failed to retrieve web page.";
        }
    }


    /// <summary>
    /// Checks the book existence through the Google books.
    /// </summary>

    #endregion
}

