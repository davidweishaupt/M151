using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Prototyp.Models;

namespace Prototyp
{
    public static class DbManager
    {
        public static SqlConnection con { get; set; }

        public static void connectDatabase()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source = WSDW\MSSQLSERVER2019;
                Initial Catalog = RLP2021_INA3a_Gruppe2;
                Integrated Security = True"; 
        }
        
        public static void sendSql(string sql)
        {
            /* SQL Beispiel ------------------------------------------------------------------------------------------------
              string sql = "UPDATE Products " + "SET ProductName='HelpMe' " + "WHERE ProductName='whoops'";
              --------------------------------------------------------------------------------------------------------------*/

            /* SQL Beispiel ------------------------------------------------------------------------------------------------
              string sql = "INSERT INTO Athletes(firstName, LastName) " + "VALUES('manuel', 'k' )";
              --------------------------------------------------------------------------------------------------------------*/

            /* SQL Beispiel ------------------------------------------------------------------------------------------------
              string sql = " DELETE FROM Products " + "WHERE ProductName='TEST'";
              --------------------------------------------------------------------------------------------------------------*/
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                if (cmd.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine("Update Sucessful");
                }
                else
                {
                    Console.WriteLine("Update Error");
                }
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
