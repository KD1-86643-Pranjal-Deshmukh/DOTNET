using AttributesLib;
namespace EntityLib
{
    [DataTable]
    public class Student {
        [KeyColumn]
        public int RollNo { get; set; }

        [DataColumn]
        public string Name { get; set; }

        [DataColumn(name = "address")]
        public string Address { get; set; }

        [DataColumn(name = "course")]
        public string Course { get; set; }
    }

    [DataTable(name = "employee")]
    public class Employee
    {
        [KeyColumn]
        public int EmpNo { get; set; }

        [DataColumn(name = "name")]
        public string Name { get; set; }

        [DataColumn(name = "address")]
        public string Address { get; set; }

        [DataColumn(name = "salary")]
        public double Salary { get; set; }

        [UnMapped]
        public double AnnualSalary { get; set; }

        [DataColumn(name = "designation")]
        public string Designation { get; set; }
    }
}
