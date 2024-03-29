﻿using System;
using System.Collections.Generic;
using StudentExercises5.Models;

namespace StudentExercises5
{
    class Program
    {
        static void Main(string[] args)
        {

            //part 1---------query database for all exercises

            Repository repository = new Repository();

            List<Exercises> exercises = repository.GetExercises();
            Console.WriteLine("All Exercises");
            foreach (Exercises e in exercises)
            {
                Console.WriteLine($"{e.ExerciseName}: {e.ProgrammingLanguage}");
            }
            Console.ReadLine();

            //part 2-------------find all the exercises in the database where the language is JavaScript

            List<Exercises> javascriptExercises = repository.GetJavascriptExercises("Javascript");
            Console.WriteLine("Javascript Exercises");
            foreach (Exercises e in javascriptExercises)
            {
                Console.WriteLine($"{e.ExerciseName}: {e.ProgrammingLanguage}");
            }
            Console.ReadLine();

            //part 3------------ - insert new exercise into database

            Exercises AddNewExercise = new Exercises
            {
                ExerciseName = "Diggers and Fliers",
                ProgrammingLanguage = "C#"
            };

            List<Exercises> updatedExercises = repository.GetExercises();
            Console.WriteLine("Add a new exercise");
            foreach (Exercises e in updatedExercises)
            {
                Console.WriteLine($"{e.ExerciseName}: {e.ProgrammingLanguage}");
            }
            Console.ReadLine();



            // part 4-------------------- find all instructors in the database. Include each instructor's cohort

            List<Instructors> instructors = repository.GetInstructors();
            Console.WriteLine("All Instructors");
            foreach (Instructors i in instructors)
            {
                Console.WriteLine($"{i.CohortId}: {i.FirstName} {i.LastName}, {i.Specialty}");
            }
            Console.ReadLine();

            //part 5--------------------insert a new instructor into the database. Assign the instructor to an existing cohort

            Instructors AddNewInstructor = new Instructors
            {
                FirstName = "Paul",
                LastName = "Javaseesharp",
                SlackHandle = "HeyImPaul",
                Specialty = "Languages",
                CohortId = 3
            };

            List<Instructors> updatedInstructors = repository.GetInstructors();
            Console.WriteLine("Add a new Instructor");
            foreach (Instructors i in updatedInstructors)
            {
                Console.WriteLine($"{i.FirstName} {i.LastName} {i.SlackHandle} {i.Specialty} {i.CohortId}");
            }
            Console.ReadLine();


            //part 6--------------------Assign an existing exercise to an existing student



        }
    }
}
