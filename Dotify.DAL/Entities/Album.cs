using System.Collections;
using System.Collections.Generic;

namespace Dotify.DAL.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual ICollection<SongAlbum> SongAlbums { get; set; }

        public Album()
        {
            SongAlbums = new List<SongAlbum>();
        }
    }
}