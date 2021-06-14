using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Prototyp.Models
{
    public class NumberSet
    {
        public string name { get; set; }

        public int id { get; set; }
        public List<NumberClass> numbers { get; set; }

        private int numberCount = 1000;

        public NumberSet(int counter, List<NumberClass> numbers)
        {
            getData(counter);
            getNumbers(numbers);

        }
        public void getNumbers(List<NumberClass> sets)
        {
            numbers = new List<NumberClass>();
            foreach (NumberClass s in sets)
            {
                if (s.FK_numberSet == id)
                {
                    numbers.Add(s);
                }
            }
        }
        public void getData(int i)
        {
            string sql = "SELECT id, name FROM NumberSets WHERE id = ";
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
                        name = reader.GetString(1);
                    }
                }
                catch (Exception e)
                {

                    //throw;
                }
            }
            DbManager.con.Close();

        }









        public class NumberClass
        {
            public int number { get; set; }
            public Athlete athlete { get; set; }
            public Club club { get; set; }
            public int FK_numberSet { get; set; }
            public int FK_athleteID { get; set; }
            public NumberClass(int counter)
            {
                getData(counter);
            }
            
            public void getData(int i)
            {
                
                string sql = "SELECT id, number, FK_numberSet FROM StartNumbers WHERE id = 1";
                sql += i.ToString();

                DbManager.con.Open();
                using (SqlCommand command = new SqlCommand(sql, DbManager.con))
                using (
                    
                    SqlDataReader reader = command.ExecuteReader())
                {
                    try
                    {
                        reader.Read();

                        if (!reader.IsDBNull(1))
                        {
                            number = reader.GetInt32(1);
                        }
                        if (!reader.IsDBNull(2))
                        {
                             FK_numberSet = reader.GetInt32(2);
                        }
                        if (!reader.IsDBNull(3))
                        {
                            FK_athleteID = reader.GetInt32(3);
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

    }

}
