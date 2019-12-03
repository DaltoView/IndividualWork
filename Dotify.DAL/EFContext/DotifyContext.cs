using Dotify.DAL.Entities;
using Dotify.DAL.EntitiesConfigurations;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dotify.DAL.EFContext
{
    public class DotifyContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongAlbum> SongAlbums { get; set; }
        public DbSet<SongArtist> SongArtists { get; set; }
        public DbSet<SongGenre> SongGenres { get; set; }
        public DbSet<User> Users { get; set; }

        public DotifyContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DotifyContext(DbContextOptions<DotifyContext> options) 
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Dotify;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new LikeConfiguraion());
            modelBuilder.ApplyConfiguration(new SongAlbumConfiguration());
            modelBuilder.ApplyConfiguration(new SongArtistConfiguration());
            modelBuilder.ApplyConfiguration(new SongGenreConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<Country>().HasData(
                new Country[]
                {
                    new Country {Id = 1, Name = "Germany"},
                    new Country {Id = 2, Name = "Great Britain"},
                    new Country {Id = 3, Name = "USA"},
                    new Country {Id = 4, Name = "Russia"},
                    new Country {Id = 5, Name = "Canada"},
                    new Country {Id = 6, Name = "Finland"},
                    new Country {Id = 7, Name = "Sweden"},
                    new Country {Id = 8, Name = "Japan"},
                    new Country {Id = 9, Name = "Korea"},
                    new Country {Id = 10, Name = "Ukraine"},
                    new Country {Id = 11, Name = "Switzerland"},
                    new Country {Id = 12, Name = "France"},
                    new Country {Id = 13, Name = "Italy"},
                    new Country {Id = 14, Name = "Poland"},
                    new Country {Id = 15, Name = "Greece"},
                    new Country {Id = 16, Name = "Turkey"},
                    new Country {Id = 17, Name = "Estonia"},
                    new Country {Id = 18, Name = "Latvia"},
                    new Country {Id = 19, Name = "Romania"},
                    new Country {Id = 20, Name = "Brazil"}
                });

            modelBuilder.Entity<Song>().HasData(
                new Song[]
                {
                    new Song{Id = 1, Title = "Drifting Sun"},
                    new Song{Id = 2, Title = "Fly to the Rainbow"},
                    new Song{Id = 3, Title = "Dark Lay"},
                    new Song{Id = 4, Title = "In Trance"},
                    new Song{Id = 5, Title = "Life is Like A River"},
                    new Song{Id = 6, Title = "I Saw Her Standing There"},
                    new Song{Id = 7, Title = "Misery"},
                    new Song{Id = 8, Title = "Anna (Go to Him)"},
                    new Song{Id = 9, Title = "Chanis"},
                    new Song{Id = 10, Title = "Boys"},
                    new Song{Id = 11, Title = "Good Times, Bad Times"},
                    new Song{Id = 12, Title = "Babe Im Gonna Leave You"},
                    new Song{Id = 13, Title = "You Shook Me"},
                    new Song{Id = 14, Title = "Dazed And Confused"},
                    new Song{Id = 15, Title = "Your Time Is Gonna Come"},
                    new Song{Id = 16, Title = "Keep Yourself Alive"},
                    new Song{Id = 17, Title = "Doing Alright"},
                    new Song{Id = 18, Title = "Great King Rat"},
                    new Song{Id = 19, Title = "My Fairy King"},
                    new Song{Id = 20, Title = "Liar"}
                });

            modelBuilder.Entity<Genre>().HasData(
                new Genre[]
                {
                    new Genre{Id = 1, Name = "Heavy Metal"},
                    new Genre{Id = 2, Name = "Hard Rock"},
                    new Genre{Id = 3, Name = "Rock-n-Roll"},
                    new Genre{Id = 4, Name = "Blues Rock"},
                    new Genre{Id = 5, Name = "Blues"},
                    new Genre{Id = 6, Name = "Rock"},
                    new Genre{Id = 7, Name = "Punk"},
                    new Genre{Id = 8, Name = "Punk Rock"},
                    new Genre{Id = 9, Name = "Metal"},
                    new Genre{Id = 10, Name = "Progressive Metal"},
                    new Genre{Id = 11, Name = "Pop"},
                    new Genre{Id = 12, Name = "Classical"},
                    new Genre{Id = 13, Name = "Symphonic Metal"},
                    new Genre{Id = 14, Name = "Drum-n-Bass"},
                    new Genre{Id = 15, Name = "Club"},
                    new Genre{Id = 16, Name = "Electro"},
                    new Genre{Id = 17, Name = "Folk"},
                    new Genre{Id = 18, Name = "Folk Metal"},
                    new Genre{Id = 19, Name = "Folk Rock"},
                    new Genre{Id = 20, Name = "Pop Punk"}
                });

            modelBuilder.Entity<Artist>().HasData(
                new Artist[]
                {
                    new Artist{ Id = 1, Name = "The Scorpions", CountryId = 1},
                    new Artist{ Id = 2, Name = "The Beatles", CountryId = 2},
                    new Artist{ Id = 3, Name = "Led Zeppelin", CountryId = 2},
                    new Artist{ Id = 4, Name = "Queen", CountryId = 2},
                    new Artist{ Id = 5, Name = "Black Sabbath", CountryId = 2},
                    new Artist{ Id = 6, Name = "3 Doors Down", CountryId = 3},
                    new Artist{ Id = 7, Name = "The Offspring", CountryId = 3},
                    new Artist{ Id = 9, Name = "Madonna", CountryId = 3},
                    new Artist{ Id = 10, Name = "The Animals", CountryId = 2},
                    new Artist{ Id = 11, Name = "Pink Floyd", CountryId = 2},
                    new Artist{ Id = 12, Name = "Deep Purple", CountryId = 2},
                    new Artist{ Id = 13, Name = "Jimi Hendrix", CountryId = 3},
                    new Artist{ Id = 14, Name = "The Who", CountryId = 2},
                    new Artist{ Id = 15, Name = "Aerosmith", CountryId = 3},
                    new Artist{ Id = 16, Name = "The Police", CountryId = 2},
                    new Artist{ Id = 18, Name = "Eagles", CountryId = 3},
                    new Artist{ Id = 19, Name = "System of A down", CountryId = 3},
                    new Artist{ Id = 22, Name = "The Misfits", CountryId = 3},
                    new Artist{ Id = 23, Name = "Elvis Presley", CountryId = 3},
                });

            modelBuilder.Entity<City>().HasData(
                new City[]
                {
                    new City{ Id = 1, CountryId = 1, Name = "Berlin"},
                    new City{ Id = 2, CountryId = 2, Name = "London"},
                    new City{ Id = 3, CountryId = 3, Name = "New York"},
                    new City{ Id = 4, CountryId = 3, Name = "Washington"},
                    new City{ Id = 5, CountryId = 3, Name = "San-Francisco"},
                    new City{ Id = 6, CountryId = 4, Name = "St-Peterburg"},
                    new City{ Id = 7, CountryId = 10, Name = "Kharkiv"},
                    new City{ Id = 8, CountryId = 5, Name = "Vancouver"},
                    new City{ Id = 9, CountryId = 6, Name = "Helsinki"},
                    new City{ Id = 10, CountryId = 7, Name = "Stockholm"},
                    new City{ Id = 11, CountryId = 8, Name = "Tokio"},
                    new City{ Id = 12, CountryId = 9, Name = "Seoul"},
                    new City{ Id = 13, CountryId = 10, Name = "Kyiv"},
                    new City{ Id = 15, CountryId = 11, Name = "Bern"},
                    new City{ Id = 16, CountryId = 12, Name = "Paris"},
                    new City{ Id = 17, CountryId = 13, Name = "Rome"},
                    new City{ Id = 18, CountryId = 14, Name = "Warsaw"},
                    new City{ Id = 19, CountryId = 15, Name = "Athens"},
                    new City{ Id = 20, CountryId = 16, Name = "Ankara"}
                });

            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User{
                        Id = 1, 
                        FirstName = "John", 
                        LastName = "Smith", 
                        Sex = true, 
                        BirthDate = DateTime.Parse("1982-03-24"),
                        CityId = 5,
                        Email = "john@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 2,
                        FirstName = "Mike",
                        LastName = "Johnson",
                        Sex = true,
                        BirthDate = DateTime.Parse("1982-04-14"),
                        CityId = 4,
                        Email = "mike@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 3,
                        FirstName = "Alice",
                        LastName = "Robertson",
                        Sex = false,
                        BirthDate = DateTime.Parse("1985-03-17"),
                        CityId = 4,
                        Email = "alice@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 4,
                        FirstName = "Mary",
                        LastName = "Richards",
                        Sex = false,
                        BirthDate = DateTime.Parse("1983-08-21"),
                        CityId = 5,
                        Email = "mary@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 5,
                        FirstName = "Jack",
                        LastName = "Darre",
                        Sex = true,
                        BirthDate = DateTime.Parse("1981-08-16"),
                        CityId = 3,
                        Email = "jack@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 7,
                        FirstName = "Tommy",
                        LastName = "Anderson",
                        Sex = true,
                        BirthDate = DateTime.Parse("1989-07-11"),
                        CityId = 3,
                        Email = "tommy@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 9,
                        FirstName = "Janet",
                        LastName = "Thomson",
                        Sex = false,
                        BirthDate = DateTime.Parse("1992-09-30"),
                        CityId = 4,
                        Email = "janet@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 10,
                        FirstName = "Rick",
                        LastName = "Jachson",
                        Sex = true,
                        BirthDate = DateTime.Parse("1982-09-19"),
                        CityId = 3,
                        Email = "rick@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 12,
                        FirstName = "Joanna",
                        LastName = "Rosenberg",
                        Sex = false,
                        BirthDate = DateTime.Parse("1993-05-13"),
                        CityId = 5,
                        Email = "joanna@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 14,
                        FirstName = "Jill",
                        LastName = "Jordan",
                        Sex = false,
                        BirthDate = DateTime.Parse("1995-04-10"),
                        CityId = 4,
                        Email = "jill@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 15,
                        FirstName = "Ivan",
                        LastName = "Petrov",
                        Sex = true,
                        BirthDate = DateTime.Parse("1987-03-22"),
                        CityId = 6,
                        Email = "ivan@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 16,
                        FirstName = "Sergey",
                        LastName = "Ivanov",
                        Sex = true,
                        BirthDate = DateTime.Parse("1988-05-25"),
                        CityId = 7,
                        Email = "sergey@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 18,
                        FirstName = "Petr",
                        LastName = "Sidorov",
                        Sex = true,
                        BirthDate = DateTime.Parse("1988-03-25"),
                        CityId = 6,
                        Email = "petr@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id =19,
                        FirstName = "Anna",
                        LastName = "Ivanova",
                        Sex = false,
                        BirthDate = DateTime.Parse("1987-04-21"),
                        CityId = 7,
                        Email = "anna@mail.com",
                        PasswordHash = ""
                    },
                    new User{
                        Id = 20,
                        FirstName = "Katerina",
                        LastName = "Petrova",
                        Sex = false,
                        BirthDate = DateTime.Parse("1981-09-12"),
                        CityId = 7,
                        Email = "katerina@mail.com",
                        PasswordHash = ""
                    }
                });

            modelBuilder.Entity<Like>().HasData(
                new Like[]
                {
                    new Like{ UserId = 1, SongId = 1, Score = 4, Date = DateTime.Parse("2010-06-24")},
                    new Like{ UserId = 1, SongId = 4, Score = 5, Date = DateTime.Parse("2010-07-02")},
                    new Like{ UserId = 1, SongId = 7, Score = 5, Date = DateTime.Parse("2010-07-13")},
                    new Like{ UserId = 1, SongId = 14, Score = 3, Date = DateTime.Parse("2010-08-15")},
                    new Like{ UserId = 2, SongId = 3, Score = 3, Date = DateTime.Parse("2010-09-07")},
                    new Like{ UserId = 2, SongId = 6, Score = 1, Date = DateTime.Parse("2010-10-10")},
                    new Like{ UserId = 2, SongId = 18, Score = 4, Date = DateTime.Parse("2010-11-14")},
                    new Like{ UserId = 3, SongId = 4, Score = 4, Date = DateTime.Parse("2010-12-01")},
                    new Like{ UserId = 3, SongId = 11, Score = 5, Date = DateTime.Parse("2010-12-10")},
                    new Like{ UserId = 3, SongId = 12, Score = 5, Date = DateTime.Parse("2010-01-14")},
                    new Like{ UserId = 3, SongId = 18, Score = 5, Date = DateTime.Parse("2011-03-24")},
                    new Like{ UserId = 3, SongId = 19, Score = 5, Date = DateTime.Parse("2011-04-06")},
                    new Like{ UserId = 4, SongId = 5, Score = 4, Date = DateTime.Parse("2011-05-11")},
                    new Like{ UserId = 4, SongId = 7, Score = 1, Date = DateTime.Parse("2011-06-17")},
                    new Like{ UserId = 4, SongId = 13, Score = 5, Date = DateTime.Parse("2011-09-08")},
                    new Like{ UserId = 4, SongId = 16, Score = 4, Date = DateTime.Parse("2011-10-14")},
                    new Like{ UserId = 5, SongId = 3, Score = 5, Date = DateTime.Parse("2012-03-05")},
                    new Like{ UserId = 5, SongId = 8, Score = 5, Date = DateTime.Parse("2012-05-14")},
                    new Like{ UserId = 5, SongId = 14, Score = 3, Date = DateTime.Parse("2012-06-24")},
                    new Like{ UserId = 7, SongId = 10, Score = 5, Date = DateTime.Parse("2012-06-25")}
                });

            modelBuilder.Entity<SongGenre>().HasData(
                new SongGenre[]
                {
                    new SongGenre{ SongId = 1, GenreId = 1},
                    new SongGenre{ SongId = 1, GenreId = 2},
                    new SongGenre{ SongId = 2, GenreId = 1},
                    new SongGenre{ SongId = 2, GenreId = 2},
                    new SongGenre{ SongId = 3, GenreId = 1},
                    new SongGenre{ SongId = 3, GenreId = 2},
                    new SongGenre{ SongId = 4, GenreId = 1},
                    new SongGenre{ SongId = 4, GenreId = 2},
                    new SongGenre{ SongId = 5, GenreId = 1},
                    new SongGenre{ SongId = 5, GenreId = 2},
                    new SongGenre{ SongId = 6, GenreId = 3},
                    new SongGenre{ SongId = 7, GenreId = 3},
                    new SongGenre{ SongId = 8, GenreId = 3},
                    new SongGenre{ SongId = 9, GenreId = 3},
                    new SongGenre{ SongId = 10, GenreId = 3},
                    new SongGenre{ SongId = 11, GenreId = 2},
                    new SongGenre{ SongId = 11, GenreId = 4},
                    new SongGenre{ SongId = 12, GenreId = 2},
                    new SongGenre{ SongId = 12, GenreId = 4},
                    new SongGenre{ SongId = 13, GenreId = 2},
                    new SongGenre{ SongId = 13, GenreId = 4},
                    new SongGenre{ SongId = 14, GenreId = 2},
                    new SongGenre{ SongId = 14, GenreId = 4},
                    new SongGenre{ SongId = 15, GenreId = 2},
                    new SongGenre{ SongId = 15, GenreId = 4},
                    new SongGenre{ SongId = 16, GenreId = 1},
                    new SongGenre{ SongId = 16, GenreId = 2},
                    new SongGenre{ SongId = 17, GenreId = 1},
                    new SongGenre{ SongId = 17, GenreId = 2},
                    new SongGenre{ SongId = 18, GenreId = 1},
                    new SongGenre{ SongId = 18, GenreId = 2},
                    new SongGenre{ SongId = 19, GenreId = 1},
                    new SongGenre{ SongId = 19, GenreId = 2},
                    new SongGenre{ SongId = 20, GenreId = 1},
                    new SongGenre{ SongId = 20, GenreId = 2}
                });

            modelBuilder.Entity<SongArtist>().HasData(
                new SongArtist[]
                {
                    new SongArtist{SongId = 1, ArtistId = 1},
                    new SongArtist{SongId = 2, ArtistId = 1},
                    new SongArtist{SongId = 3, ArtistId = 1},
                    new SongArtist{SongId = 4, ArtistId = 1},
                    new SongArtist{SongId = 5, ArtistId = 1},
                    new SongArtist{SongId = 6, ArtistId = 2},
                    new SongArtist{SongId = 7, ArtistId = 2},
                    new SongArtist{SongId = 8, ArtistId = 2},
                    new SongArtist{SongId = 9, ArtistId = 2},
                    new SongArtist{SongId = 10, ArtistId = 2},
                    new SongArtist{SongId = 11, ArtistId = 3},
                    new SongArtist{SongId = 12, ArtistId = 3},
                    new SongArtist{SongId = 13, ArtistId = 3},
                    new SongArtist{SongId = 14, ArtistId = 3},
                    new SongArtist{SongId = 15, ArtistId = 3},
                    new SongArtist{SongId = 16, ArtistId = 4},
                    new SongArtist{SongId = 17, ArtistId = 4},
                    new SongArtist{SongId = 18, ArtistId = 4},
                    new SongArtist{SongId = 19, ArtistId = 4},
                    new SongArtist{SongId = 20, ArtistId = 4}
                });

            modelBuilder.Entity<Album>().HasData(
                new Album[]
                {
                    new Album
                    {
                        Id = 1,
                        Title = "Lonesome Crow",
                        Year = 1972,
                        ArtistId = 1
                    },
                    new Album
                    {
                        Id = 2,
                        Title = "Fly to the Rainbow",
                        Year = 1974,
                        ArtistId = 1
                    },
                    new Album
                    {
                        Id = 3,
                        Title = "In Trance",
                        Year = 1975,
                        ArtistId = 1
                    },
                    new Album
                    {
                        Id = 4,
                        Title = "Virgin Killer",
                        Year = 1976,
                        ArtistId = 1
                    },
                    new Album
                    {
                        Id = 6,
                        Title = "Taken by Force",
                        Year = 1977,
                        ArtistId = 1
                    },
                    new Album
                    {
                        Id = 7,
                        Title = "Loverdrive",
                        Year = 1979,
                        ArtistId = 1
                    },
                    new Album
                    {
                        Id = 8,
                        Title = "Animal Magnetism",
                        Year = 1980,
                        ArtistId = 1
                    },
                    new Album
                    {
                        Id = 9,
                        Title = "Blackout",
                        Year = 1982,
                        ArtistId = 1
                    },
                    new Album
                    {
                        Id = 10,
                        Title = "Love at First Sting",
                        Year = 1984,
                        ArtistId = 1
                    },
                    new Album
                    {
                        Id = 11,
                        Title = "Savage Amusement",
                        Year = 1988,
                        ArtistId = 1
                    },
                    new Album
                    {
                        Id = 12,
                        Title = "Please Please Me",
                        Year = 1963,
                        ArtistId = 2
                    },
                    new Album
                    {
                        Id = 13,
                        Title = "With The Beatles",
                        Year = 1963,
                        ArtistId = 2
                    },
                    new Album
                    {
                        Id = 14,
                        Title = "A Hard Days Night",
                        Year = 1964,
                        ArtistId = 2
                    },
                    new Album
                    {
                        Id = 15,
                        Title = "Beatles For Sale",
                        Year = 1964,
                        ArtistId = 2
                    },
                    new Album
                    {
                        Id = 16,
                        Title = "Help!",
                        Year = 1966,
                        ArtistId = 2
                    },
                    new Album
                    {
                        Id = 17,
                        Title = "Rubber Soul",
                        Year = 1965,
                        ArtistId = 2
                    },
                    new Album
                    {
                        Id = 18,
                        Title = "Revolver",
                        Year = 1966,
                        ArtistId = 2
                    },
                    new Album
                    {
                        Id = 19,
                        Title = "Led Zeppelin",
                        Year = 1969,
                        ArtistId = 3
                    },
                    new Album
                    {
                        Id = 20,
                        Title = "Led Zeppelin II",
                        Year = 1969,
                        ArtistId = 3
                    },
                    new Album
                    {
                        Id = 21,
                        Title = "Led Zeppelin III",
                        Year = 1970,
                        ArtistId = 3
                    },
                    new Album
                    {
                        Id = 24,
                        Title = "Queen",
                        Year = 1973,
                        ArtistId = 4
                    },
                    new Album
                    {
                        Id = 25,
                        Title = "Quenn II",
                        Year = 1974,
                        ArtistId = 4
                    },
                    new Album
                    {
                        Id = 26,
                        Title = "Black Sabbath",
                        Year = 1970,
                        ArtistId = 5
                    },
                    new Album
                    {
                        Id = 27,
                        Title = "Paranoid",
                        Year = 1970,
                        ArtistId = 5
                    },
                    new Album
                    {
                        Id = 28,
                        Title = "The Better Life",
                        Year = 2000,
                        ArtistId = 6
                    },
                    new Album
                    {
                        Id = 29,
                        Title = "Away from the Sun",
                        Year = 2002,
                        ArtistId = 6
                    },
                    new Album
                    {
                        Id = 30,
                        Title = "Seventeen Days",
                        Year = 2005,
                        ArtistId = 6
                    },
                    new Album
                    {
                        Id = 31,
                        Title = "The Offspring",
                        Year = 1989,
                        ArtistId = 7
                    },
                    new Album
                    {
                        Id = 32,
                        Title = "Ignition",
                        Year = 1982,
                        ArtistId = 7
                    },
                    new Album
                    {
                        Id = 34,
                        Title = "Madonna",
                        Year = 1983,
                        ArtistId = 9
                    },
                    new Album
                    {
                        Id = 35,
                        Title = "The Animals",
                        Year = 1964,
                        ArtistId = 10
                    }
                });

            modelBuilder.Entity<SongAlbum>().HasData(
                new SongAlbum[]
                {
                    new SongAlbum{SongId = 1, AlbumId = 2, TrackNo = 3},
                    new SongAlbum{SongId = 2, AlbumId = 2, TrackNo = 7},
                    new SongAlbum{SongId = 3, AlbumId = 3, TrackNo = 1},
                    new SongAlbum{SongId = 4, AlbumId = 3, TrackNo = 2},
                    new SongAlbum{SongId = 5, AlbumId = 3, TrackNo = 3},
                    new SongAlbum{SongId = 6, AlbumId = 12, TrackNo = 1},
                    new SongAlbum{SongId = 7, AlbumId = 12, TrackNo = 2},
                    new SongAlbum{SongId = 8, AlbumId = 12, TrackNo = 3},
                    new SongAlbum{SongId = 9, AlbumId = 12, TrackNo = 4},
                    new SongAlbum{SongId = 10, AlbumId = 12, TrackNo = 5},
                    new SongAlbum{SongId = 11, AlbumId = 19, TrackNo = 1},
                    new SongAlbum{SongId = 12, AlbumId = 19, TrackNo = 2},
                    new SongAlbum{SongId = 13, AlbumId = 19, TrackNo = 3},
                    new SongAlbum{SongId = 14, AlbumId = 19, TrackNo = 4},
                    new SongAlbum{SongId = 15, AlbumId = 19, TrackNo = 5},
                    new SongAlbum{SongId = 16, AlbumId = 24, TrackNo = 1},
                    new SongAlbum{SongId = 17, AlbumId = 24, TrackNo = 2},
                    new SongAlbum{SongId = 18, AlbumId = 24, TrackNo = 3},
                    new SongAlbum{SongId = 19, AlbumId = 24, TrackNo = 4},
                    new SongAlbum{SongId = 20, AlbumId = 24, TrackNo = 5},
                });

            base.OnModelCreating(modelBuilder);
        }

        public void ResetDatabase()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}