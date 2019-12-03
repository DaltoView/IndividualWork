using System.Collections.Generic;

namespace Dotify.DAL.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<SongAlbum> SongAlbums { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
        public virtual ICollection<SongGenre> SongGenres { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

        public Song()
        {
            SongAlbums = new List<SongAlbum>();
            SongArtists = new List<SongArtist>();
            SongGenres = new List<SongGenre>();
            Likes = new List<Like>();
        }
    }
}