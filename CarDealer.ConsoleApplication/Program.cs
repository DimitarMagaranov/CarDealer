
using CarDealer.Data;
using System;

namespace CarDealer.ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new CarDealerDbContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
