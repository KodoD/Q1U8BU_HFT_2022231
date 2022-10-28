using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query;
using Q1U8BU_HFT_2022231.Models;
using System;

namespace Q1U8BU_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connStr = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kodod\\source\\repos\\Q1U8BU_HFT_2022231\\Q1U8BU_HFT_2022231.Models\\Diak.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Sales",conn);
            SqlDataReader dr = cmd.ExecuteReader();
            for (int i = 0; i < dr.FieldCount; i++)
            {
                Console.Write(dr.GetName(i)+"\t");
            }
            Console.WriteLine();
            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.Write(dr.GetValue(i) + "\t");
                }
                Console.WriteLine();

            }
            dr.Close();
            Sales a = new Sales("3#valaki#1#4#344");
            Console.WriteLine(a);
        }
    }
}
