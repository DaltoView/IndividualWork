using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify.DAL.Entities
{
    public class Like
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
    }
}
