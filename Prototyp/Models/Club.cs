using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Prototyp.Controllers;

namespace Prototyp.Models
{
    public class Club
    {
        public string name { get; set; }
        private List<Athlete> athletes;
        public int id { get; set; }
        public int managerId { get; set; }
        public User manager { get; set; } 

        public Club(int i)
        {
            getData(i);
            getAthleteList();
            getManager();
        }
        private void getManager()
        {
            for (int i = 0; i < 10; i++)
            {
                User mg = new User(i);
                if(mg.id == managerId)
                {
                    manager = mg;
                }
            }
        }
        private void getAthleteList()
        {
            List<Athlete> allAthletes;

            AthleteController athleteController = new AthleteController();
            athletes = new List<Athlete>();
            allAthletes = athleteController.getList();

            foreach(Athlete at in allAthletes)
            {
                if(at.clubId == id)
                {
                    athletes.Add(at);
                }
            }
        }
        public void getData(int i)
        {
            string sql = "SELECT id, name, FK_managerId FROM Clubs WHERE id = ";
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
                    if (!reader.IsDBNull(2))
                    {
                        managerId = reader.GetInt32(2);
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

        public void removeAthlete(string athleteName)
        {
            /*
            foreach(Athlete athlete in athletes)
            {
                if(athlete.firstName == athleteName)
                {
                    athletes.Remove(athlete);
                }
            }*/
        }
        public void addAthlete(Athlete at)
        {
            athletes.Add(at);
        }
        
    }
}
