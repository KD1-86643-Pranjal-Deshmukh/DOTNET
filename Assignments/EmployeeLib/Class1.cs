using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EmployeeLib
{
    public enum DepartmentType { 
        Sales,
        Developer,
        HR
    }

    public class WageEmp : Employee
    {
        public int hours { get; set; }
        public int rate { get; set; }
        public WageEmp() { }
        public WageEmp(int rate, int sub, double salary, DepartmentType dept, string name, bool gender, string address, int d, int m, int y) : base(salary, "Wage", dept, name, gender, address, d, m, y)
        {
            hours = sub;
            this.rate = rate;
        }
        public override void Accept()
        {
            ((Person)this).Accept();
            Console.Write("Enter Hours: ");
            hours = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Rate: ");
            rate = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Salary: ");
            salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Designation: ");
            desig = "Wage";
            dep = setDepartment();
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Hours: " + hours);
            Console.WriteLine("Rate: " + rate);
        }
        public override string ToString()
        {
            return base.ToString() + " Hours: " + hours + " Rate: " + rate;
        }
    }


    public class Supervisor : Employee
    {
        public int subbordinates { get; set; }
        public Supervisor() { }
        public Supervisor(int sub, double salary, DepartmentType dept, string name, bool gender, string address, int d, int m, int y) : base(salary, "Supervisor", dept, name, gender, address, d, m, y)
        {
            subbordinates = sub;
        }
        public override void Accept()
        {
            ((Person)this).Accept();
            Console.Write("Enter Subbordinates: ");
            subbordinates = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Salary: ");
            salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Designation: ");
            desig = "Supervisor";
            dep = setDepartment();
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Subbordinates: " + subbordinates);
        }
        public override string ToString()
        {
            return base.ToString() + " Subbordinates: " + subbordinates;
        }
    }


    public class Manager : Employee {
        public double bounus { get; set; }
        public Manager() { }
        public Manager(double bonus, double salary, DepartmentType dept, string name, bool gender, string address, int d, int m, int y) : base(salary, "Manager", dept, name, gender, address, d, m, y) {
            this.bounus = bonus;
        }

        public override void Accept() {
            ((Person)this).Accept();
            Console.Write("Enter Bonus: ");
            bounus = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Salary: ");
            salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Designation: ");
            desig = "Manager";
            dep = setDepartment();
        }
        public override void Display() {
            Console.WriteLine("Bonus: " + bounus);
            base.Display();
        }
        public override string ToString()
        {
            return base.ToString() + " Bonus: " + bounus;
        }
    }

    public class Employee : Person {
        private static int autoId = 0;

        private int _id = ++autoId;
        private double _salary;
        private string _desig;
        private DepartmentType _dep;

        public DepartmentType setDepartment() {
            Console.WriteLine("1. Sales.");
            Console.WriteLine("2. Developer.");
            Console.WriteLine("3. HR.");
            switch (Convert.ToInt32(Console.ReadLine())) {
                case 1: return DepartmentType.Sales;
                case 2: return DepartmentType.Developer;
                case 3: return DepartmentType.HR;
            }
            return DepartmentType.Developer;
        }

        public DepartmentType dep
        {
            get { return _dep; }
            set { _dep = value; }
        }

        public string desig
        {
            get { return _desig; }
            set { _desig = value; }
        }

        public double salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public int id
        {
            get { return _id; }
        }

        public Employee() { }

        public Employee(double salary, string desig, DepartmentType dept, string name, bool gender, string address, int d, int m, int y) : base(name, gender, address, d, m, y)
        {
            _salary = salary;
            _desig = desig;
            _dep = dept;
        }

        public virtual void Accept()
        {
            base.Accept();
            Console.WriteLine("Enter Salary: ");
            _salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Designation: ");
            _desig = Console.ReadLine();
            _dep = setDepartment();
        }

        public virtual void Display()
        {
            base.Display();
            Console.WriteLine("Salary: "+_salary);
            Console.WriteLine("Designation: "+_desig);
            Console.WriteLine("Department: " + _dep.ToString());
        }

        public override string ToString()
        {
            return "Id: " + _id +" Salary: "+ _salary + " Desig: " +_desig +" Department: "+_dep.ToString() +" "+ base.ToString();
        }
    }

    public class Person {
        private string _name;
        private bool _gender;
        private Date _date;
        private string _address;
        private int _age;

        public Person() {
            _date = new Date();
        }

        public Person(string name, bool gender, string address, int d, int m, int y) { 
            _name = name;
            _gender = gender;
            _address = address;
            _date = new Date(d, m, y);
        }

        public virtual void Accept() {
            Console.WriteLine("Enter Name: ");
            _name = Console.ReadLine();
            Console.WriteLine("Enter Gender: ");
            _gender = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Enter Address: ");
            _address = Console.ReadLine();
            Console.WriteLine("Enter Date: ");
            _date.AcceptDate();

            DateTime now = DateTime.Today;
            Date date2 = new Date(now.Day, now.Month, now.Year);
            _age = _date - date2;
        }

        public virtual void Display() { 
            Console.WriteLine("Name: "+ _name);
            Console.WriteLine("Address: "+ _address);
            Console.WriteLine("Gender: "+ (_gender ? "Male" : "Female"));
            Console.WriteLine("Birth Date: "+ _date.ToString());
            Console.WriteLine("Age: "+ _age);
        }
        public override string ToString()
        {
            return "Name: "+_name+" Address: "+_address+" Gender: "+(_gender?"Male ":"Female ")+"BirthDate: "+_date.ToString()+" Age: "+_age;
        }

        public string address
        {
            get { return _address; }
        }

        public Date date
        {
            get { return _date; }
        }

        public bool gender
        {
            get { return _gender; }
        }

        public string name
        {
            get { return _name; }
        }


    }

    public class Date
    {
        private int _date;
        private int _month;
        private int _year;

        public int year
        {
            get { return _year; }
            set { _year = value; }
        }

        public int month
        {
            get { return _month; }
            set { _month = value; }
        }


        public int date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Date() { 

        }

        public Date(int day, int month, int year) { 
            _date = day;
            _month = month;
            _year = year;
        }

        public void AcceptDate()
        {
            Console.WriteLine("Enter Day: ");
            _date=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Month: ");
            _month=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Year: ");
            _year=Convert.ToInt32(Console.ReadLine());
        }

        public void PrintDate()
        {
            Console.WriteLine("{0}-{1}-{2}", _date, _month, _year);
        }

        public bool IsValid()
        {
            return (_date > 0 && _date < 32 && _month < 13 && year < 10000 && month > 0&& year > 0);
        }

        public override string ToString()
        {
            return _date+"-"+_month+"-"+_year;
        }

        public static int operator -(Date d1, Date d2) { 
            return Math.Abs(d1.year - d2.year);
        }
    }
}
