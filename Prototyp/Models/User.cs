using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Prototyp.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        [DisplayName("User Name")]
        [Required(ErrorMessage = "This field is mandatory")]
       
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is mandatory")]
        public string role { get; set; }
        public List<Event> events { get; set; }
        public List<User> usernames { get; set; }
        public string loginErrorMessage { get; set; }

        public User(int i)
        {
            //events = new List<Event>();
            getData(i);
        }
        public void getData(int i)
        {
            string sql = "SELECT id, username, firstName, lastName, password, role FROM Users WHERE id = ";
            sql += i.ToString();

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
                        username = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        firstName = reader.GetString(2);
                    }
                    if (!reader.IsDBNull(3))
                    {
                        lastName = reader.GetString(3);
                    }
                    if (!reader.IsDBNull(4))
                    {
                        password = reader.GetString(4);
                    }
                    if (!reader.IsDBNull(5))
                    {
                        role = reader.GetString(5);
                    }
                    
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
