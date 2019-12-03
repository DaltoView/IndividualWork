using Dotify.DAL.EFContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleTest
{
    public class Transactions
    {
        public void ReadUncommited()
        {
            using (var db = new DotifyContext())
            {
                Task.Run(() => DirtyRead());
                using (var transaction = db.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    Thread.Sleep(500);
                    var city = db.Cities.First();
                    Console.WriteLine(city.Name);
                    Thread.Sleep(2000);
                    db.Entry(city).Reload();
                    Console.WriteLine(city.Name);
                    transaction.Rollback();
                }
            }
        }

        private void DirtyRead()
        {
            using (var db = new DotifyContext())
            {
                using (var transaction = db.Database.BeginTransaction(IsolationLevel.ReadUncommitted))
                {
                    db.Cities.First().Name = "LALA";
                    db.SaveChanges();
                    Thread.Sleep(1000);
                    transaction.Rollback();
                }
            }
        }

        public void ReadCommited()
        {
            using (var db = new DotifyContext())
            {
                Task.Run(() => NonRepeatableRead());
                using (var transaction = db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    var city = db.Cities.First();
                    Console.WriteLine(city.Name);
                    Thread.Sleep(2000);
                    db.Entry(city).Reload();
                    Console.WriteLine(city.Name);
                    transaction.Commit();
                }
            }
        }

        private void NonRepeatableRead()
        {
            using (var db = new DotifyContext())
            {
                using (var transaction = db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    Thread.Sleep(1000);
                    db.Cities.First().Name = "LALA";
                    db.SaveChanges();
                    transaction.Commit();
                }
            }
        }

        public void RepeatableRead()
        {
            using (var db = new DotifyContext())
            {
                Task.Run(() => PhantomRead());
                using (var transaction = db.Database.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    var country = db.Countries.Where(p => p.Name == "MyCountry").FirstOrDefault();

                    if(country == null)
                        Console.WriteLine($"Not Found Count:{db.Countries.Count()}");
                    else
                        Console.WriteLine(country.Name);

                    Thread.Sleep(2000);
                    country = db.Countries.Where(p => p.Name == "MyCountry").FirstOrDefault();
                    Console.WriteLine($"{country.Name} Count:{db.Countries.Count()}");
                    transaction.Commit();
                }
            }
        }

        private void PhantomRead()
        {
            using (var db = new DotifyContext())
            {
                using (var transaction = db.Database.BeginTransaction(IsolationLevel.RepeatableRead))
                {
                    Thread.Sleep(1000);
                    db.Countries.Add(new Dotify.DAL.Entities.Country() 
                    {
                        Name = "MyCountry"
                    });
                    db.SaveChanges();
                    transaction.Commit();
                }
            }
        }

        public void Serealizable()
        {
            using (var db = new DotifyContext())
            {
                Task.Run(() => PhantomRead());
                using (var transaction = db.Database.BeginTransaction(IsolationLevel.Serializable))
                {
                    var country = db.Countries.Where(p => p.Name == "MyCountry").FirstOrDefault();

                    if (country == null)
                        Console.WriteLine($"Not Found Count:{db.Countries.Count()}");
                    else
                        Console.WriteLine($"{country.Name} Count:{db.Countries.Count()}");

                    Thread.Sleep(2000);
                    country = db.Countries.Where(p => p.Name == "MyCountry").FirstOrDefault();

                    if (country == null)
                        Console.WriteLine($"Not Found Count:{db.Countries.Count()}");
                    else
                        Console.WriteLine($"{country.Name} Count:{db.Countries.Count()}");

                    transaction.Commit();
                }
            }
        }
    }
}
