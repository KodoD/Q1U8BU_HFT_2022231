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
        static void Main(string[] args)
        {
            string connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:|DataDirectory|\Diak.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Sales",conn);
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine(dr.Read());
           /* IRepository<Sales> sales = new SalesRepository(new HFTContext());
            var items = sales.ReadAll().ToArray();*/
           var ctx=new HFTContext();
            var SalesRepo = new SalesRepository(ctx); 
            var CustomerRepo = new CustomerRepository(ctx); 
            var SongRepo = new SongRepository(ctx);

            var SalesLogic = new SalesLogic(SalesRepo);
            var SongLogic = new SongLogic(SongRepo);
            var CustomerLogic = new CustomerLogic(CustomerRepo);


          /* var Salessubmenu=new ConsoleMenu(args,level:1).Add("Create",() => Create("Sales"));
           var Customersubmenu=new ConsoleMenu(args,level:1).Add("Create",() => Create("Sales"));
           var Songsubmenu=new ConsoleMenu(args,level:1).Add("Create",() => Create("Sales"));
           var menu=new ConsoleMenu(args,level:0).Add("Sales",()=>Salessubmenu.Show()).Add("Songs", () => Songsubmenu.Show()).Add("Customer", () => Customersubmenu.Show())
          */
        }
    }
}
