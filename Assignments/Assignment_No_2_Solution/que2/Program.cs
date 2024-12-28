using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace que2
{
    struct Student
    {
        private string name;
        private bool gender;
        private int age;
        private int std;
        private char div;
        private double marks;

        //public Student()
        //{
        //    name = "Unknown";
        //    gender = true;
        //    age = 0;
        //    std = 0;
        //    div = 'A';
        //    marks = 0.0;
        //}
        public Student(string name, int age, int std, char div, double marks, bool gender)
        {
            this.name = name;
            this.age = age;
            this.std = std;
            this.div = div;
            this.marks = marks;
            this.gender = gender;
        }
        public string _Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool _Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int _Age
        {
            get { return age; }
            set { age = value; }
        }

        public int _Std
        {
            get { return std; }
            set { std = value; }
        }

        public char _Div
        {
            get { return div; }
            set { div = value; }
        }

        public double _Marks
        {
            get { return marks; }
            set { marks = value; }
        }


        public void AcceptDetails()
        {
            Console.Write("Enter Name: ");
            name = Console.ReadLine();

            Console.Write("Enter Gender Male=true or Female=false ");
            gender = bool.Parse(Console.ReadLine());

            Console.Write("Enter Age: ");
            age = int.Parse(Console.ReadLine());

            Console.Write("Enter Standard: ");
            std = int.Parse(Console.ReadLine());

            Console.Write("Enter Division: ");
            div = char.Parse(Console.ReadLine());

            Console.Write("Enter Marks: ");
            marks = double.Parse(Console.ReadLine());
        }

        public void PrintDetails()
        {
            Console.WriteLine("Student Details:");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Gender: {(gender ? "Male" : "Female")}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Standard: {std}");
            Console.WriteLine($"Division: {div}");
            Console.WriteLine($"Marks: {marks}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Student[] student1 = new Student[10];
            Student[] students = CreateArray();

            AcceptInfo(students);
            PrintInfo(students);

        }
        static Student[] CreateArray()
        {
            Console.WriteLine("Enter the number of students");
            int studentSize=Convert.ToInt32(Console.ReadLine());
            return new Student[studentSize];
        }
        static void AcceptInfo(Student[] students)
        {
            for (int i = 0; i < students.Length; i++) {
                Console.WriteLine("Enter the name");
                students[i]._Name = Console.ReadLine();

                Console.WriteLine("Gender");
                string getGender= Console.ReadLine().ToLower();
                students[i]._Gender=getGender=="male"?true:false;

                Console.Write("Age: ");
                students[i]._Age = int.Parse(Console.ReadLine());

                Console.Write("Standard (e.g., 10): ");
                students[i]._Std = int.Parse(Console.ReadLine());

                Console.Write("Division (A/B/C): ");
                students[i]._Div = char.Parse(Console.ReadLine().ToUpper());

                Console.Write("Marks: ");
                students[i]._Marks = double.Parse(Console.ReadLine());



            }

        }
        static void PrintInfo(Student[] students)
        {
            Console.WriteLine("info");
            for (int i = 0; i < students.Length; i++)
            {
                students[i].PrintDetails();
                Console.WriteLine();
            }
        }

    }
}
