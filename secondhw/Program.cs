using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace secondhw
{
    class Program
    {
        static string connectionString = @"Data Source= USER\SQLEXPRESS;Initial Catalog=ShopDB;Integrated Security=True";
        static void Main(string[] args)
        {

        }
        static void GetTovar(int id)
        {
            string procName = "GetTovar";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(procName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter idparam = new SqlParameter()
                {
                    ParameterName = "idprod",
                    Value = id
                };
                cmd.Parameters.Add(idparam);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
                    while (reader.Read())
                    {
                        int idd = reader.GetInt32(0);
                        string desc = reader.GetString(1);
                        int price = reader.GetInt32(2);
                        int weight = reader.GetInt32(3);
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}", idd, desc, price, weight);
                    }
                }
            }
        }
    }
}
