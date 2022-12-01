using ConsoleTools;
using Newtonsoft.Json.Serialization;
using Q1U8BU_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Q1U8BU_HFT_2022231.Client
{
    internal class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Song")
            {
                Console.WriteLine("Enter Song Name: ");
                string name=Console.ReadLine();
                rest.Post(new Song() { Name = name }, "song");
            }
            if (entity == "Author")
            {
                Console.WriteLine("Enter Author Name: ");
                string name = Console.ReadLine();
                rest.Post(new Song() { Name = name }, "author");
            }
            if (entity == "Sales")
            {
                Console.WriteLine("Enter Sales Name: ");
                string name = Console.ReadLine();
                rest.Post(new Song() { Name = name }, "sales");
            }
            if (entity == "Customer")
            {
                Console.WriteLine("Enter Customer Name: ");
                string name = Console.ReadLine();
                rest.Post(new Song() { Name = name }, "customer");
            }
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Song")
            {
                List<Song> songs = rest.Get<Song>("song");
                foreach (var item in songs)
                {
                    Console.WriteLine(item.SongID + ":" + item.Name);
                }
            }
            if (entity == "Author")
            {
                List<Author> author = rest.Get<Author>("author");
                foreach (var item in author)
                {
                    Console.WriteLine(item.AutherId + "\t" + item.AName);
                }
            }
            if (entity == "Sales")
            {
                List<Sales> sales = rest.Get<Sales>("sales");
                foreach (var item in sales)
                {
                    Console.WriteLine(item.SalesID + "\t" + item.Price);
                }
            }
            if (entity == "Customer")
            {
                List<Customer> customers = rest.Get<Customer>("customer");
                foreach (var item in customers)
                {
                    Console.WriteLine(item.CustomerID + "\t" + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void NonCrud(string entity) 
        {
            if (entity == "WhatBought")
            {
                int id = int.Parse(Console.ReadLine());
                //  var results = rest.Get<Song>(id, "Stat/WhatBought");
                Console.WriteLine("LINQ cant translate");
            }
            if (entity == "WhoBoughtIt")
            {
                int id = int.Parse(Console.ReadLine());
              //  var results = rest.Get<Customer>(id, "Stat/WhoBoughtIt");
                Console.WriteLine("LINQ cant translate");

            }
            if (entity == "MostWanted")
            {
                var results = rest.Get<MostWanted>("Stat/MostWanted");
                Console.WriteLine(results[0].Name+" "+ results[0].Id+" "+ results[0].Count);

            }
            if (entity == "LeastWanted")
            {
                var results = rest.Get<MostWanted>("Stat/LeastWanted");
                Console.WriteLine(results[0].Name + " " + results[0].Id + " " + results[0].Count);
            }
            if (entity == "Regular")
            {
                var results = rest.Get<RegularGuest>("Stat/RegularGuests");
                foreach (var item in results)
                {
                    Console.WriteLine(item.Name+" "+item.ID+" "+item.SpentM);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Song")
            {
                Console.Write("Enter Song's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Song one = rest.Get<Song>(id, "song");
                Console.WriteLine($"New name[old:{one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "song");
            }
            if (entity == "Author")
            {
                Console.Write("Enter Author's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Author one = rest.Get<Author>(id, "author");
                Console.WriteLine($"New name[old:{one.AName}]: ");
                string name = Console.ReadLine();
                one.AName = name;
                rest.Put(one, "author");
            }
            if (entity == "Sales")
            {
                Console.Write("Enter Sales's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Sales one = rest.Get<Sales>(id, "sales");
                Console.WriteLine($"New name[old:{one.SaleName}]: ");
                string name = Console.ReadLine();
                one.SaleName = name;
                rest.Put(one, "sales");
            }
            if (entity == "Customer")
            {
                Console.Write("Enter Customer's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Customer one = rest.Get<Customer>(id, "customer");
                Console.WriteLine($"New name[old:{one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "customer");
            }
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            if (entity == "Song")
            {
                Console.WriteLine("Enter Song's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "song");
            }
            if (entity == "Author")
            {
                Console.WriteLine("Enter Author's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "author");
            }
            if (entity == "Sales")
            {
                Console.WriteLine("Enter Sales's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "sales");
            }
            if (entity == "Customer")
            {
                Console.WriteLine("Enter Customer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "customer");
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {


            rest = new RestService("http://localhost:58670/", "song");

            #region Menu
            var SalesSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Sales"))
                .Add("Create", () => Create("Sales"))
                .Add("Delete", () => Delete("Sales"))
                .Add("Update", () => Update("Sales"))
                .Add("Exit", ConsoleMenu.Close);
            var StatMenu = new ConsoleMenu(args, level: 1)
                .Add("WhatBought", () => NonCrud("WhatBought"))
                .Add("WhoBoughtIt", () => NonCrud("WhoBoughtIt"))
                .Add("MostWanted", () => NonCrud("MostWanted"))
                .Add("LeastWanted", () => NonCrud("LeastWanted"))
                .Add("RegularCustomer", () => NonCrud("Regular"))
                .Add("Exit", ConsoleMenu.Close);
            var CustomerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Customer"))
                .Add("Create", () => Create("Customer"))
                .Add("Delete", () => Delete("Customer"))
                .Add("Update", () => Update("Customer"))
                .Add("Exit", ConsoleMenu.Close);

            var SongSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Song"))
                .Add("Create", () => Create("Song"))
                .Add("Delete", () => Delete("Song"))
                .Add("Update", () => Update("Song"))
                .Add("Exit", ConsoleMenu.Close);


            var AuthorSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Author"))
                .Add("Create", () => Create("Author"))
                .Add("Delete", () => Delete("Author"))
                .Add("Update", () => Update("Author"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Sales", () => SalesSubMenu.Show())
                .Add("Customers", () => CustomerSubMenu.Show())
                .Add("Songs", () => SongSubMenu.Show())
                .Add("Author", () => AuthorSubMenu.Show())
                .Add("Stat", () => StatMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
            #endregion
        }




    }
}
