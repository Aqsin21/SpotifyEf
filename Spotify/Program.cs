using Microsoft.EntityFrameworkCore;
using System.Transactions;
using System.Xml.Linq;

namespace Spotify
{
    internal class Program
    {
        static void Main(string[] args)
        {

           
        }

        static void Add() 
        {
            var DbContext = new AppDbContext();
            Console.Write("Enter Music Name");
            var name = Console.ReadLine();

            Console.Write("Enter the Artist Name ");

           

            
        }
    }
}
