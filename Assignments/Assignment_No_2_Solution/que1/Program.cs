using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using que1;

namespace que1
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

    }
     class Program
    {
        static void Main(string[] args)
        {
        Student student = new Student();
        student.AcceptDetails();
        student.PrintDetails();
        }
    }

