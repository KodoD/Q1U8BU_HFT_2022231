using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Q1U8BU_HFT_2022231.Models;
using Q1U8BU_HFT_2022231.Repository;
using System;
using System.Linq;

namespace Q1U8BU_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
          /*  string connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kodod\\source\\repos\\Q1U8BU_HFT_2022231\\Q1U8BU_HFT_2022231.Models\\Diak.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Sales",conn);
            SqlDataReader dr = cmd.ExecuteReader();*/
            IRepository<Sales> sales = new SalesRepository(new HFTContext());
            var items = sales.ReadAll().ToArray();

        }
    }
}
