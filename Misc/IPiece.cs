namespace Universum.Misc;

public interface IPiece
{
    string Name { get; set; }
    string Authors { get; }

    Piece.PieceType Type { get; }
    int Year { get; }
    string Description { get; set; }
    string ImageUrl { get; set; }
}
/* ValueKind = Object : "{
        "title": "Start Something That Matters",
        "authors": [
          "Blake Mycoskie"
        ],
        "publisher": "Random House",
        "publishedDate": "2012-02-02",
        "description": "In 2006, while travelling in Argentina, young entrepreneur Blake Mycoskie encountered children too poor to afford shoes, who developed injuries on their feet that often led to serious health problems. Blake knew he wanted to help, but rather than start a charity, he went against conventional wisdom and created a for profit business to help the children who he met. With the help of a local shoemaker, Blake struck out to merge activism and fashion in the form of a local canvas shoe worn by farmers and gauchos alike, called the alpargata. Blake called his creation TOMS Shoes (which stands for \"Tomorrow's Shoes\") and promised to give a pair of new shoes to a child in need for every pair that he sold. Starting with only two hundred pairs of handmade shoes, optimism, and entrepreneurial charisma, Blake successfully launched TOMS into the high fashion world. They can now be seen adorning the feet of celebrities such as Keira Knightley, Scarlett Johansson, and Tobey Maguire. Blake's mission is to prove that you can achieve financial success and make the world a better place at the same time. In this book, he shares the six counterintuitive principles that have guided the growth of TOMS for the past three years: Make business personal Be resourceful without resources Reverse retirement Keep it simple Stay humble Give more, advertise less The result is an inspiring account of a young man whose entrepreneurial spirit was able to affect change in the world, and a call to others to be inspired to do the same. As part of the One for One initiative, Random House will provide a new book to a child in need with every copy of Start Something That Matters purchased.",
        "industryIdentifiers": [
          {
            "type": "ISBN_13",
            "identifier": "9780753547403"
          },
          {
            "type": "ISBN_10",
            "identifier": "0753547406"
          }
        ],
        "readingModes": {
          "text": true,
          "image": false
        },
        "pageCount": 211,
        "printType": "BOOK",
        "categories": [
          "Business & Economics"
        ],
        "averageRating": 4,
        "ratingsCount": 24,
        "maturityRating": "NOT_MATURE",
        "allowAnonLogging": true,
        "contentVersion": "0.3.4.0.preview.2",
        "panelizationSummary": {
          "containsEpubBubbles": false,
          "containsImageBubbles": false
        },
        "imageLinks": {
          "smallThumbnail": "http://books.google.com/books/content?id=vDIz8TGG95EC&printsec=frontcover&img=1&zoom=5&edge=curl&source=gbs_api",
          "thumbnail": "http://books.google.com/books/content?id=vDIz8TGG95EC&printsec=frontcover&img=1&zoom=1&edge=curl&source=gbs_api"
        },
        "language": "en",
        "previewLink": "http://books.google.ru/books?id=vDIz8TGG95EC&printsec=frontcover&dq=Start+Something+That+Matters&hl=&cd=1&source=gbs_api",
        "infoLink": "https://play.google.com/store/books/details?id=vDIz8TGG95EC&source=gbs_api",
        "canonicalVolumeLink": "https://play.google.com/store/books/details?id=vDIz8TGG95EC"
      }
"ValueKind = Object : "{
"Title":"Star Trek: Discovery",
"Year":"2017–2024",
"Rated":"TV-14",
"Released":"24 Sep 2017",
"Runtime":"60 min",
"Genre":"Action, Adventure, Drama",
"Director":"N/A",
"Writer":"Bryan Fuller, Alex Kurtzman",
"Actors":"Sonequa Martin-Green, Doug Jones, Anthony Rapp",
"Plot":"Ten years before Kirk, Spock, and the Enterprise, the USS Discovery discovers new worlds and lifeforms as one Starfleet officer learns to understand all things alien.",
"Language":"English, Klingon",
"Country":"United States",
"Awards":"Won 2 Primetime Emmys. 21 wins & 82 nominations total",
"Poster":"https://m.media-amazon.com/images/M/MV5BNjg1NTc2MDktZTU5Ni00OTZiLWIyNjQtN2FhNGY4MzAxNmZkXkEyXkFqcGdeQXVyMTkxNjUyNQ@@._V1_SX300.jpg",
"Ratings":[
{"Source":"Internet Movie Database","Value":"7.0/10"}
],
"Metascore":"N/A",
"imdbRating":"7.0",
"imdbVotes":"126,261",
"imdbID":"tt5171438",
"Type":"series",
"totalSeasons":"5",
"Response":"True"
}"
 */