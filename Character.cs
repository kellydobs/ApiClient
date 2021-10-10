using System;
using System.Text.Json.Serialization;

namespace ApiClient
{
    //     //public class Lyrics
    //     {
    //         [JsonPropertyName("lyrics")]
    //         public string SongLyrics { get; set; }
    //     }

    public class Character
    {
        [JsonPropertyName("character")]
        public string Character { get; set; }
    }


}