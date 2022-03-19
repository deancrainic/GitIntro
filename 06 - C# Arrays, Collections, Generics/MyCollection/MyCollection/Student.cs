using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    internal class Student
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public StudentGrades? Grade { get; set; }

        public override string ToString()
        {
            return Name + ", " + Age + ": " + Grade;
        }
    }

    internal enum StudentGrades
    {
        Insufficient,
        Sufficient,
        Good,
        VeryGood,
        Perfect
    }
}
