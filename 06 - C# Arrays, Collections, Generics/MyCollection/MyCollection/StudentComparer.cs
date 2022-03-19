using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    internal class StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (Equals(x, y))
                return 0;

            if (x.Age < y.Age)
                return -1;
            else
                return 1;
        }
    }
}
