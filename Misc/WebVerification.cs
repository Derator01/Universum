using System.Text.Json;

namespace Universum.Misc;

public static class WebVerification
{
    private const string OMDB_API_KEY = "417135a4";

    /// <param name="name">Title of the book</param>
    /// <returns>Complete match of the <paramref name="name"/> and the response title.</returns>
    /// <exception cref="Exception">Throws in case there is no book with remotely similar <paramref name="name"/>.</exception>
    /// <exception cref="HttpRequestException">Throws if there is no Internet access or something along those lines.</exception>
    private static async Task<bool> CheckBookExistenceAsync(string name)
    {
        name = name.Trim();

        HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={name}");

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            JsonDocument data = JsonDocument.Parse(responseBody);

            int totalItems = data.RootElement.GetProperty("totalItems").GetInt32();

            if (totalItems > 0)
            {
                JsonElement bookInfo = data.RootElement.GetProperty("items")[0].GetProperty("volumeInfo");
                string webTitle = bookInfo.GetProperty("title").GetString();

                return name.ToLower() == webTitle.Trim().ToLower();
            }
            else
            {
                throw new Exception("There is no even remotely similar book in the database");
            }
        }
        else
        {
            throw new HttpRequestException("Something went wrong during web request.", null, response.StatusCode);
        }
    }

    /// <summary>
    /// Checks the movie existence through the OMDB.
    /// </summary>
    /// <param name="title">Title of the movie</param>
    /// <returns>Complete match of the <paramref name="title"/> and the response title.</returns>
    /// <exception cref="HttpRequestException">Throws if there is no Internet access or something along those lines.</exception>
    private static async Task<bool> CheckMovieExistenceAsync(string title)
    {
        title = title.Trim();

        HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync($"http://www.omdbapi.com/?apikey={OMDB_API_KEY}&t={title}");

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            JsonDocument data = JsonDocument.Parse(responseBody);

            if (data.RootElement.GetProperty("Response").GetString() == "True")
            {
                return title.ToLower() == data.RootElement.GetProperty("Title").GetString().Trim().ToLower();
            }
            else
            {
                return false;
            }
        }
        else
        {
            throw new HttpRequestException("Something went wrong during web request.", null, response.StatusCode);
        }
    }

    /// <summary>
    /// Try to get book from Google Books. "Try" because method can return completely irrelevant book.
    /// </summary>
    /// <returns>Book information.</returns>
    /// <exception cref="Exception">You will likely not see this exception ever.</exception>
    /// <exception cref="HttpRequestException">If there is no Internet connection.</exception>
    private static async Task<JsonElement> TryGetBookAsync(string name)
    {
        name = name.Trim();

        HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={name}");

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            JsonDocument data = JsonDocument.Parse(responseBody);

            int totalItems = data.RootElement.GetProperty("totalItems").GetInt32();

            if (totalItems > 0)
            {
                JsonElement bookInfo = data.RootElement.GetProperty("items")[0].GetProperty("volumeInfo");

                return bookInfo;
            }
            else
            {
                throw new Exception("There is no even remotely similar book in the database");
            }
        }
        else
        {
            throw new HttpRequestException("Something went wrong during web request.", null, response.StatusCode);
        }
    }

    /// <summary>
    /// Try to get movie from OMDB. "Try" because method can return completely irrelevant movie.
    /// </summary>
    /// <returns>Movie information.</returns>
    /// <exception cref="Exception">You will likely not see this exception ever.</exception>
    /// <exception cref="HttpRequestException">If there is no Internet connection.</exception>
    private static async Task<JsonElement> TryGetMovieAsync(string title)
    {
        title = title.Trim();

        HttpClient client = new();
        HttpResponseMessage response = await client.GetAsync($"http://www.omdbapi.com/?apikey={OMDB_API_KEY}&t={title}");

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            JsonDocument titleDocument = JsonDocument.Parse(responseBody);

            if (titleDocument.RootElement.GetProperty("Response").GetString() == "True")
            {
                return titleDocument.RootElement;
            }
            else
            {
                throw new Exception("There is no even remotely similar movie in the database");
            }
        }
        else
        {
            throw new HttpRequestException("Something went wrong during web request.", null, response.StatusCode);
        }
    }
}
