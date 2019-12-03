namespace Dotify.DAL.Entities
{
    public class SongArtist
    {
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
