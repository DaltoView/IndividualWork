using System.Collections;
using System.Collections.Generic;

namespace Dotify.DAL.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<SongArtist> SongArtists { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

        public Artist()
        {
            SongArtists = new List<SongArtist>();
            Albums = new List<Album>();
        }
    }
}