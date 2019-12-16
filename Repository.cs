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

        //part 3-------------Insert a new exercise into the database

        public void AddNewExercise(Exercises exercise)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Exercise (ExerciseName, ProgrammingLanguage) Values (@name, @language)";
                    cmd.Parameters.Add(new SqlParameter("@name", exercise.ExerciseName));
                    cmd.Parameters.Add(new SqlParameter("@language", exercise.ProgrammingLanguage));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //part 4--------------------get a list of all the instructors and their cohort

        public List<Instructors> GetInstructors()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT i.Id, i.FirstName, i.LastName, i.Specialty, i.SlackHandle i.CohortId, c.CohortName FROM Instructors i INNER JOIN Cohorts c ON c.id = i.CohortId";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Instructors> instructors = new List<Instructors>();
                    while (reader.Read())
                    {
                        
                        int idValue = reader.GetInt32(reader.GetOrdinal("Id"));
                        string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                        string specialty = reader.GetString(reader.GetOrdinal("Specialty"));
                        string slackhandle = reader.GetString(reader.GetOrdinal("SlackHandle"));
                        int cohortId = reader.GetInt32(reader.GetOrdinal("CohortId"));
                        string cohortName = reader.GetString(reader.GetOrdinal("CohortName"));

                        
                        Instructors instructor = new Instructors
                        {
                            Id = idValue,
                            FirstName = firstName,
                            LastName = lastName,
                            Specialty = specialty,
                            CohortId = cohortId,
                            CohortName = cohortName,
                            SlackHandle = slackhandle
                           
                        };
                        instructors.Add(instructor);
                    }
                    reader.Close();
                    return instructors;
                }
            }
        }

        //part 5--------------------insert a new instructor into the database. Assign the instructor to an existing cohort

        public void AddNewInstructor(Instructors instructor)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Instructor (FirstName, LastName, SlackHandle, Specialty, CohortId) Values (@firstname, @lastname, @slackhandle. @specialty, @cohortid)";
                    cmd.Parameters.Add(new SqlParameter("@firstname", instructor.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastname", instructor.LastName));
                    cmd.Parameters.Add(new SqlParameter("@slackhandle", instructor.SlackHandle));
                    cmd.Parameters.Add(new SqlParameter("@specialty", instructor.Specialty));
                    cmd.Parameters.Add(new SqlParameter("@cohortid", instructor.CohortId));
                    cmd.ExecuteNonQuery();
                }
            }
        }

      

        public void AddNewStudent(Students student)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Students (FirstName, LastName, SlackHandle, CohortId) Values (@firstname, @lastname, @slackhandle, @cohortid)";
                    cmd.Parameters.Add(new SqlParameter("@firstname", student.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@lastname", student.LastName));
                    cmd.Parameters.Add(new SqlParameter("@slackhandle", student.SlackHandle));
                    cmd.Parameters.Add(new SqlParameter("@cohortid", student.CohortId));
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //part 6--------------------Assign an existing exercise to an existing student


        public void AddExercise(int studentId, int exerciseId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO StudentExercises (StudentId, ExerciseId) Values (@studentId, @exerciseId)";
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@exerciseId", exerciseId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }




}
