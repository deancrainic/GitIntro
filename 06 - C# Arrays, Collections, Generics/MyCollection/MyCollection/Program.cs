using MyCollection;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyArray collection

            MyArray<Student> array = new MyArray<Student>(10);

            array.SetItemAtGivenIndex(0, new Student { Name = "Calla Willoughby", Age = 20 , Grade = StudentGrades.Perfect });
            array.SetItemAtGivenIndex(1, new Student { Name = "Marie Darell", Age = 21 });
            array.SetItemAtGivenIndex(2, new Student { Name = "Harold Carson", Age= 22, Grade = StudentGrades.Insufficient });
            array.SetItemAtGivenIndex(3, new Student { Name = "Tom Oddinson" });

            array.SwapItemsByIndex(0, 3);

            Console.WriteLine(array.GetItemAtGivenIndex(3));

            MyArray<Student> array2 = new MyArray<Student>(10);

            array2.SetItemAtGivenIndex(0, new Student { Name = "Jim Thomas", Age = 19, Grade = StudentGrades.Sufficient });
            array2.SetItemAtGivenIndex(1, new Student { Name = "Francisc Carrey", Age = 21 });
            array2.SetItemAtGivenIndex(2, new Student { Name = "Hugh Mason", Age = 20, Grade = StudentGrades.VeryGood });
            array2.SetItemAtGivenIndex(3, new Student { Name = "Michael Robson", Grade = StudentGrades.Good });
            array2.SetItemAtGivenIndex(4, new Student { Name = "Harold Carson", Age = 22, Grade = StudentGrades.Perfect });

            //Dictionary

            Dictionary<string, MyArray<Student>> universities = new Dictionary<string, MyArray<Student>>();
            universities.Add("UPT", array);
            universities.Add("UVT", array2);

            Console.WriteLine(universities["UVT"].GetItemAtGivenIndex(1));

            //IEqualityComparer

            var studentEqComparer = new StudentEqualityComparer();

            Console.WriteLine(studentEqComparer.Equals(array.GetItemAtGivenIndex(2), array2.GetItemAtGivenIndex(4)));

            //IComparer

            var studentComparer = new StudentComparer();

            Console.WriteLine(studentComparer.Compare(array2.GetItemAtGivenIndex(1), array2.GetItemAtGivenIndex(4)));
        }
    }
}