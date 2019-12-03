using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify.DAL.Entities
{
    public class SongAlbum
    {
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public int TrackNo { get; set; }
    }
}
