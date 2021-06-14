using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Prototyp.Models
{
    public class Event
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public Address location { get; set; }
        //public List<Club> clubs { get; set; }
        //public List<Discipline> disciplines { get; set; }
        public NumberSet numberSet { get; set; }
        public int FK_categoryId { get; set; }
        public int FK_numberSet { get; set; }

        public Event(int i)
        {
            getData(i);
            // initialisiert die Liste
            

        }

        public void getData(int i)
        {
            string sql = "SELECT id, date, street, streetNumber, plz, city, FK_categoryId, FK_numberSet FROM Events Where id = ";
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
                        date = reader.GetDateTime(1); ;
                    }
                    if (!reader.IsDBNull(2))
                    {
                        streetName = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        streetNumber = reader.GetInt32(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        postalCode = reader.GetInt32(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        city = reader.GetString(5);
                    }
                    if (!reader.IsDBNull(6))
                    {
                        FK_categoryId = reader.GetInt32(6);
                    }
                    if (!reader.IsDBNull(7))
                    {
                        FK_numberSet = reader.GetInt32(7);
                    }

                    //Neue Adresse Erstellen
                    Address adress = new Address(streetName, streetNumber, city, postalCode);
                    location = adress;
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
