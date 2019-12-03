using System;
using System.Collections.Generic;

namespace Dotify.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

        public User()
        {
            Likes = new List<Like>();
        }
    }
}