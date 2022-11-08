using ConsoleTools;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Q1U8BU_HFT_2022231.Models;
using Q1U8BU_HFT_2022231.Repository;
using Q1U8BU_HFT_2022231.Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Q1U8BU_HFT_2022231.Client
{
    internal class Program
    {

        static SalesLogic salesLogic;
        static CustomerLogic customerLogic;
        static SongLogic songLogic;
        static AuthorLogic authorlogic;

        static void Main(string[] args)
        {
          
          
            var ctx=new HFTContext();
            #region repo+logic
            var SalesRepo = new SalesRepository(ctx); 
            var CustomerRepo = new CustomerRepository(ctx); 
            var SongRepo = new SongRepository(ctx);
            var AuthorRepo = new AuthorRepository(ctx);

            var SalesLogic = new SalesLogic(SalesRepo);
            var SongLogic = new SongLogic(SongRepo);
            var CustomerLogic = new CustomerLogic(CustomerRepo);
            var AuthorLogic = new AuthorLogic(AuthorRepo);
            #endregion

            #region Menu
            var SalesSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Sales"))
                .Add("Create", () => Create("Sales"))
                .Add("Delete", () => Delete("Sales"))
                .Add("Update", () => Update("Sales"))
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
                .Add("Author", () =>AuthorSubMenu.Show())

                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
            #endregion
        }


        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Song")
            {
                var items = songLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.SongID + "\t" + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }

    }
}
