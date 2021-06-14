using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Prototyp.Models
{
    public class Discipline
    {
        public int id { get; set; }
        public string name { get; set; }
        public Category category { get; set; }
        List<Category> categories = new List<Category>();

        public Discipline(int input)
        {
            // Init categories list
            for (int i = 1; i <= 7; i++)
            {
                getCategorie(i);
            }

            getDisciplines(input);
        }
        private void getCategorie(int id)
        {
            //Select* From Categories
            string sql = "Select id, name From Categories Where id = ";
            sql += id.ToString();

            DbManager.con.Open();
            using (SqlCommand command = new SqlCommand(sql, DbManager.con))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                reader.Read();
                try
                {
                    if (!reader.IsDBNull(0))
                    {
                        this.id = reader.GetInt32(0);
                    }
                    if (!reader.IsDBNull(1))
                    {
                        name = reader.GetString(1);
                    }
                    categories.Add(new Category(id, name));
                }
                catch (Exception e)
                {
                    DbManager.con.Close();
                    //throw;
                }
            }
            DbManager.con.Close();
        }
        private void getDisciplines(int id)
        {
            int catId = 0;
            //Select* From Categories
                string sql = "Select id, name, FK_categoryID From Disciplines Where id =  ";
            sql += id.ToString();

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
                        name = reader.GetString(1);
                    }
                    if (!reader.IsDBNull(2))
                    {
                        foreach (Category cat in categories)
                        {
                            if (cat.id == reader.GetInt32(2))
                            {
                                category = cat;
                            }
                        }  
                    }
                }
                catch (Exception e)
                {

                    //throw;
                }
            }
            DbManager.con.Close();
        }
    }
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public Category(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
