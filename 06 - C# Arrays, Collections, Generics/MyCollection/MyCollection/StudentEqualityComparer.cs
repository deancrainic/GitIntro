using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    internal class StudentEqualityComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Student obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
