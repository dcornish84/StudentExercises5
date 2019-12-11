using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using StudentExercises5.Models;

namespace StudentExercises5
{
    public class Repository
    {

        public SqlConnection Connection
        {
            get
            {

                string _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StudentExercises;Integrated Security=True";
                return new SqlConnection(_connectionString);
            }
        }
        //part 1---------query database for all exercises
        public List<Exercises> GetExercises()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, ExerciseName, ProgrammingLanguage FROM Exercise";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Exercises> exercises = new List<Exercises>();
                    while (reader.Read())
                    {

                        int idValue = reader.GetInt32(reader.GetOrdinal("Id"));
                        string exerciseNameValue = reader.GetString(reader.GetOrdinal("ExerciseName"));
                        string exerciseLanguageValue = reader.GetString(reader.GetOrdinal("ProgrammingLanguage"));

                        Exercises exercise = new Exercises
                        {
                            Id = idValue,
                            ExerciseName = exerciseNameValue,
                            ProgrammingLanguage = exerciseLanguageValue
                        };
                        exercises.Add(exercise);
                    }
                    reader.Close();
                    return exercises;
                }
            }
        }
        //part 2-------------find all the exercises in the database where the language is JavaScript

        public List<Exercises> GetJavascriptExercises(string language)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Id, ExerciseName, ProgrammingLanguage FROM Exercise WHERE ProgrammingLanguage = @language";
                    cmd.Parameters.Add(new SqlParameter("@language", language));


                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Exercises> exercises = new List<Exercises>();
                    while (reader.Read())
                    {
                        
                        int idValue = reader.GetInt32(reader.GetOrdinal("Id"));
                        string exerciseNameValue = reader.GetString(reader.GetOrdinal("ExerciseName"));
                        string exerciseLanguageValue = reader.GetString(reader.GetOrdinal("ProgrammingLanguage"));

                        
                        Exercises exercise = new Exercises
                        {
                            Id = idValue,
                            ExerciseName = exerciseNameValue,
                            ProgrammingLanguage = exerciseLanguageValue
                        };
                        exercises.Add(exercise);
                    }
                    reader.Close();
                    return exercises;
                }
            }
        }
    }

   
        
    
}
