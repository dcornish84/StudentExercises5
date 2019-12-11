using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises5.Models
{
    public class Instructors
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SlackHandle { get; set; }

        public string Specialty { get; set; }

        public int CohortId { get; set; }

        
    }
}
