using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Employee
    {
        public Employee() { }
        public Employee(int id, string name, int age, string department,
            string salary, string jDate) 
        {
            ID = id;
            Name = name;
            Age = age;
            Department = department;
            Salary = salary;
            JoiningDate = jDate;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public string Salary { get; set; }
        public string JoiningDate { get; set; }
        public string ToString()
        {
            return $"\nID: {ID}\nName:{Name}\nAge: {Age}\n" +
                $"Department: {Department}\nSalary: {Salary}\n" +
                $"JoiningDate: {JoiningDate}\n";
        }
    }
}
