using System;
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

            List<Exercises> javascriptExercises = repository.GetJavascriptExercises("JavaScript");
            Console.WriteLine("JavaScript Exercises");
            foreach (Exercises e in javascriptExercises)
            {
                Console.WriteLine($"{e.ExerciseName}: {e.ProgrammingLanguage}");
            }
            Console.ReadLine();




        }
    }
}
