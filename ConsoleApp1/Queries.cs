using Dotify.DAL.EFContext;
using Dotify.DAL.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleTest
{
    public class Queries
    {
        public void MusicLovers()
        {
            using (var db = new DotifyContext())
            {
                var likes = db.Likes
                    .GroupBy(s => s.SongId)
                    .Select(g => new
                    {
                        g.Key,
                        Count = g.Count()
                    })
                    .Where(p => p.Count > 1);

                var users = db.Likes
                    .Where(p => likes.Any(s => s.Key == p.SongId));

                var musicLovers = db.Likes
                    .Where(p => !users.Any(s => s.UserId == p.UserId))
                    .Select(p => p.User);

                foreach (var user in musicLovers)
                {
                    Console.WriteLine($"{user.Id} {user.FirstName} {user.LastName}");
                }
            }
        }

        public void NewYorkGenre()
        {
            using(var db = new DotifyContext())
            {
                var gernre = db.Songs.Join(
                    db.Likes, 
                    p=> p.Id, 
                    s => s.SongId,
                    (x, y) => new
                    {
                        x.Id,
                        y.Score,
                        y.User.City.Name
                    }).Join(
                    db.SongGenres,
                    p => p.Id,
                    s => s.SongId,
                    (x, y)=> new
                    {
                        x.Id,
                        x.Score,
                        CityName = x.Name,
                        GenreName = y.Genre.Name
                    })
                    .Where(p => p.CityName == "New York")
                    .GroupBy(p => p.GenreName)
                    .Select(p => new
                    {
                        GenreName = p.Key,
                        Sum = p.Sum(s => s.Score)
                    })
                    .OrderByDescending(p => p.GenreName)
                    .First();
                
                Console.WriteLine($"{gernre.GenreName} {gernre.Sum}");
            }
        }

        public void TheBeatles()
        {
            using (var db = new DotifyContext())
            {
                var users = db.Users.Where(p => p.City.Country.Name == "USA");

                var likes = db.Likes.Join(
                    db.SongArtists,
                    p => p.SongId,
                    t => t.SongId,
                    (x, y) => new
                    {
                        x.UserId,
                        y.Artist
                    })
                    .Where(p => p.Artist.Name == "The Beatles" && users.Any(s => s.Id == p.UserId)).Count();

                Console.WriteLine(likes);
            }
        }

        public void TheMostPopularRockNRoll()
        {
            using (var db = new DotifyContext())
            {
                var songs = db.Songs.Join(
                    db.Likes,
                    s => s.Id,
                    l => l.SongId,
                    (x, y) => new
                    {
                        x.Id,
                        x.Title,
                        y.Score,
                        y.Date,
                    })
                    .Join(
                    db.SongGenres,
                    s => s.Id,
                    g => g.SongId,
                    (x, y) => new
                    {
                        x.Id,
                        x.Score,
                        x.Title,
                        x.Date,
                        y.Genre.Name
                    })
                    .Where(p => p.Date.Year == 2012 && p.Name == "Rock-n-Roll")
                    .GroupBy(p => new { p.Id, p.Title })
                    .Select(p => new
                    {
                        p.Key.Id,
                        p.Key.Title,
                        TotalScore = p.Sum(p => p.Score)
                    })
                    .OrderByDescending(p => p.TotalScore);

                foreach (var song in songs)
                {
                    Console.WriteLine($"Id:{song.Id} Title:{song.Title} Total:{song.TotalScore}");
                }
            }
        }

        public void RecomendationToJohn()
        {
            using (var db = new DotifyContext())
            {
                var likes = db.Likes
                    .Join(
                    db.Users,
                    l => l.UserId,
                    u => u.Id,
                    (x, y) => new
                    {
                        x.SongId,
                        y.Email
                    })
                    .Where(p => p.Email == "john@mail.com");

                var songs = db.SongGenres
                    .Where(p => p.Genre.Name == "Heavy Metal")
                    .Where(p => !likes.Any(s => s.SongId == p.SongId))
                    .OrderByDescending(p => p.Song.Likes.Sum(p => p.Score))
                    .Select(p => p.Song)
                    .Join(db.SongArtists, s => s.Id, a => a.SongId, (x, y) => new { x.Title, y.Artist.Name})
                    .Take(3);

                foreach (var song in songs)
                {
                    Console.WriteLine($"{song.Title} {song.Name}");
                }
            }
        }

        public void DeleteLikeWithSmallScore()
        {
            using (var db = new DotifyContext())
            {
                foreach (var like in db.Likes)
                {
                    Console.WriteLine($"{like.SongId} {like.UserId} {like.Score}");
                }

                Console.WriteLine(new string('-', 10));

                var likes = db.Likes.Where(p => p.Score < 3);
                db.Likes.RemoveRange(likes);
                db.SaveChanges();

                foreach (var like in db.Likes)
                {
                    Console.WriteLine($"{like.SongId} {like.UserId} {like.Score}");
                }
            }
        }

        public void DeleteGenre()
        {
            using (var db = new DotifyContext())
            {
                try
                {
                    var genre = db.Genres.Where(p => p.Name == "Heavy Metal").First();
                    db.Remove(genre);
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }

            }
        }

        public void UpdateUsers()
        {
            using (var db = new DotifyContext())
            {
                foreach (var user in db.Users)
                {
                    Console.WriteLine($"{user.FirstName} {user.LastName}");
                }

                var users = db.Users;

                foreach (var user in users)
                {
                    user.FirstName = user.FirstName.First().ToString();
                    user.LastName = user.LastName.First().ToString();
                }

                db.SaveChanges();

                foreach (var user in db.Users)
                {
                    Console.WriteLine($"{user.FirstName} {user.LastName}");
                }
            }
        }

        public void CheckConstraint()
        {

            using (var db = new DotifyContext())
            {
                try
                {
                    db.Likes.First().Score = 10;
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
            }
        }

        public void IndexUniqueCheck()
        {

            using (var db = new DotifyContext())
            {
                try
                {
                    db.Users.Find(2).Email = "john@mail.com";
                    db.SaveChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }

            }
        }
    }
}
