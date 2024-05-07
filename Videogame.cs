using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public string Name { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string SoftwareHouse { get; set; }


        public Videogame (string name, string overview, DateTime release, DateTime created, DateTime updated, string software)
        {
            Name = name;    
            Overview = overview;
            ReleaseDate = release;
            CreatedAt = created;
            UpdateAt = updated;
            SoftwareHouse = software;

        }

    }

    public static class VideogameManager
    {
        static string connectionString = "Data Source=localhost;Initial Catalog=db-database1;Integrated Security=True";
            public static void InserisciVideogame(string name, string overview, DateTime release, DateTime created, DateTime updated, string software )
        {
            Videogame newVideogame = new Videogame(name, overview, release, created, updated, software);

            string insertQuery = "INSERT INTO videogames (name, overview, release, created, updated, software) VALUES (@name, @overview, @release, @created, @updated, @software)";
            SqlConnection connessione = new SqlConnection(connectionString);
            try
            {
                connessione.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, connessione);
                cmd.Parameters.Add(new SqlParameter("@name", name));
                cmd.Parameters.Add(new SqlParameter("@overview", overview));
                cmd.Parameters.Add(new SqlParameter("@release", release));
                cmd.Parameters.Add(new SqlParameter("@created", created));
                cmd.Parameters.Add(new SqlParameter("@updated", updated));
                cmd.Parameters.Add(new SqlParameter("@software", software));

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connessione.Close();
            }


        }

        public static void GetVideogame(int id)
        {

            using SqlConnection connessione = new SqlConnection(connectionString);
            try
            {
                connessione.Open();
                string getVideogameQuery = "SELECT name, overview FROM videogames WHERE id = @id;";
                SqlCommand cmd = new SqlCommand(getVideogameQuery, connessione);
                
                cmd.Parameters.Add(new SqlParameter("@id", id));
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int videogameIndexName = reader.GetOrdinal("name");
                    int videogameOverview = reader.GetOrdinal("overview");
                    Console.WriteLine($"Videogame {reader.GetString(videogameIndexName)} : {reader.GetString(videogameOverview)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        public static void SearchVideogame(string name1)
        {
            SqlConnection connessione = new SqlConnection(connectionString);
                
            //NON RIESCO AD ENTRARE IN QUESTA FUNZIONE E NON HO IDEA DEL PERCHé

            try
            {
                connessione.Open();
                string getVideogamesQuery = "SELECT name, overview FROM videogames WHERE name LIKE '% @name1'; ";
                SqlCommand cmd = new SqlCommand(getVideogamesQuery, connessione);
                cmd.Parameters.Add(new SqlParameter("@name1", name1));

                SqlDataReader reader2 = cmd.ExecuteReader();

                while (reader2.Read())
                {
                    
                    int videogameIndexName = reader2.GetOrdinal("name");
                    int videogameOverview = reader2.GetOrdinal("overview");
                    Console.WriteLine($"Videogame {reader2.GetString(videogameIndexName)} : {reader2.GetString(videogameOverview)}");
                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connessione.Close();
            }
            

        }

        public static void DeleteVideogame()
        {

        }




    }
}
