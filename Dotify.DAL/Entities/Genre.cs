using System.Collections.Generic;

namespace Dotify.DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SongGenre> SongGenres { get; set; }

        public Genre()
        {
            SongGenres = new List<SongGenre>();
        }
    }
}