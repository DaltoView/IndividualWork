using Dotify.DAL.EFContext;
using Dotify.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var queries = new Queries();
            new DotifyContext().ResetDatabase();
            queries.MusicLovers();

            new DotifyContext().ResetDatabase();
            queries.NewYorkGenre();

            new DotifyContext().ResetDatabase();
            queries.TheBeatles();

            new DotifyContext().ResetDatabase();
            queries.TheMostPopularRockNRoll();

            new DotifyContext().ResetDatabase();
            queries.RecomendationToJohn();

            new DotifyContext().ResetDatabase();
            queries.DeleteLikeWithSmallScore();

            new DotifyContext().ResetDatabase();
            queries.DeleteGenre();

            new DotifyContext().ResetDatabase();
            queries.UpdateUsers();

            new DotifyContext().ResetDatabase();
            queries.CheckConstraint();

            new DotifyContext().ResetDatabase();
            queries.IndexUniqueCheck();

            var transcation = new Transactions();

            new DotifyContext().ResetDatabase();
            transcation.ReadUncommited();

            new DotifyContext().ResetDatabase();
            transcation.ReadCommited();

            new DotifyContext().ResetDatabase();
            transcation.RepeatableRead();

            new DotifyContext().ResetDatabase();
            transcation.Serealizable();
        }
    }
}
