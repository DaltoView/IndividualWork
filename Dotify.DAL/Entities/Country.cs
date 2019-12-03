using System.Collections;
using System.Collections.Generic;

namespace Dotify.DAL.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
        public virtual ICollection<City> Cities { get; set; }

        public Country()
        {
            Artists = new List<Artist>();
            Cities = new List<City>();
        }
    }
}