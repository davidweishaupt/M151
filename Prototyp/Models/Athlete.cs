using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Prototyp.Models
{
    public class Athlete
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Address home { get; set; } 
        public bool gender { get; set; }
        public int clubId { get; set; }

        public DateTime birthDate { get; set; }

        public Athlete(int i)
        {
            getData(i);
        }

        public void getData(int i)
        {
            string sql = "Select id, firstName, lastName, birthDate, gender, street, streetNumber, plz, city, FK_clubId From Athletes WHERE id = ";
            sql += i.ToString();


            string streetName = "";
            int streetNumber = 0;
            int postalCode = 0;
            string city = "";


            DbManager.con.Open();
            using (SqlCommand command = new SqlCommand(sql, DbManager.con))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                try
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                    {
                        id = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        firstName = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        lastName = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        birthDate = reader.GetDateTime(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        gender = reader.GetBoolean(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        streetName = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        streetNumber = reader.GetInt32(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        postalCode = reader.GetInt32(7);
                    }
                    if (!reader.IsDBNull(8))
                    {
                        city = reader.GetString(8);
                    }
                    if (!reader.IsDBNull(9))
                    {
                        clubId = reader.GetInt32(9);
                    }

                    //Neue Adresse Erstellen
                    Address adress = new Address(streetName, streetNumber, city, postalCode);
                    home = adress;
                }
                catch (Exception e)
                {
                    DbManager.con.Close();
                    //throw;
                }
            }      
            DbManager.con.Close();
 
        }
    }

}
