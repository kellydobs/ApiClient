using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;


namespace ApiClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Welcome to Lyric Finder!");
            Console.WriteLine("Welcome to the Game of Thrones Character finder!");

            var keepGoing = true;

            while (keepGoing)
            {
                //var artist = PromptInput("Name the artist for the song lyrics you are looking for?");

                var character = PromptInput("What character would you like to learn about?");

                //var song = PromptInput($"Name the song from {artist} to find the lyrics:");


                //await SearchLyrics(artist, song);

                await SearchCharacter(character);

                var input = PromptInput("Search for another ? Y/N").ToUpper();


                keepGoing = (input == "Y" ? true : false);
            }
        }

        static string PromptInput(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();

        }

        //static async Task SearchLyrics(string artist, string song)

        static async Task SearchCharacter(string character)
        {
            try
            {

                var client = new HttpClient();

                // var url = $"https://api.lyrics.ovh/vl/{artist}/{song}";

                var url = $"https://www.anapioficeandfire.com/api/{character}";

                var responseBodyAsStream = await client.GetStreamAsync(url);

                //var lyricsObject = await JsonSerializer.DeserializeAsync<Lyrics>(responseBodyAsStream);

                var characterObject = await JsonSerializer.DeserializeAsync<Character>(responseBodyAsStream);

                //Console.WriteLine(lyricsObject.SongLyrics);
                Console.WriteLine(characterObject);


            }
            catch (HttpRequestException)
            {
                Console.WriteLine("I could not find that item");

            }
        }
    }

}
