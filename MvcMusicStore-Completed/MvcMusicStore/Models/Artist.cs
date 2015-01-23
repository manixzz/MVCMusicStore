using System.Collections.Generic;
namespace MvcMusicStore.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public List<Album> Albums { get; set; }
        public int NumberOfAlbums { get; set; }
        public List<Genre> ListOfGenres { get; set; }
    }
}