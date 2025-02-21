using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DTO;

namespace DAL
{
    public class EmployeeDAL
    {
        public void Save(Employee employee) // employee creation related....
                                            // should contain logic related to validation of no duplicate ID creation
                                            // or we could add this unique id logic in BLL...
        {
            StreamWriter finW = new StreamWriter("Employees.txt", true);
            string data = $"{employee.ID};{employee.Name};{employee.Age};" +
                $"{employee.Department};{employee.Salary};{employee.JoiningDate}";
            finW.WriteLine(data);
            finW.Close();
        }
        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            StreamReader foutR = new StreamReader("Employees.txt");
            string data = foutR.ReadLine();
            while (data != null)
            {
                string[] employeeInfo = data.Split(";");

                Employee employeeObj = new Employee();
                employeeObj.ID = int.Parse(employeeInfo[0]);
                employeeObj.Name = employeeInfo[1];
                employeeObj.Age = int.Parse(employeeInfo[2]);
                employeeObj.Department = employeeInfo[3];
                employeeObj.Salary = employeeInfo[4];
                employeeObj.JoiningDate = employeeInfo[5];

                employees.Add(employeeObj);
                data = foutR.ReadLine();
            }
            foutR.Close();
            return employees;
        }

        // search function has a switch case against each parameter
        public List<Employee> Search(string key, int type)
        {
            List<Employee> found = new List<Employee>();

            List<Employee> emps = GetAll();
            switch (type)
            {
                case 1: // bt id
                    foreach (Employee employee in emps)
                    {
                        if (employee.ID == int.Parse(key))
                        {
                            found.Add(employee);
                        }
                    }
                    if (found.Count == 0)
                    {
                        Console.WriteLine("Employee Not found...");
                    }
                    break;
                case 2: // by name
                    foreach (Employee employee in emps)
                    {
                        if (employee.Name == key)
                        {
                            found.Add(employee);
                        }
                    }
                    if (found.Count == 0)
                    {
                        Console.WriteLine("Employee Not found...");
                    }
                    break;
                case 3: // by department
                    foreach (Employee employee in emps)
                    {
                        if (employee.Department == key)
                        {
                            found.Add(employee);
                        }
                    }
                    if (found.Count == 0)
                    {
                        Console.WriteLine("Employee Not found...");
                    }
                    break;
                case 4: // by joining date
                    foreach (Employee employee in emps)
                    {
                        if (employee.JoiningDate == key)
                        {
                            found.Add(employee);
                        }
                    }
                    if (found.Count == 0)
                    {
                        Console.WriteLine("Employee Not found...");
                    }
                    break;
                case 5:
                    Console.WriteLine("Exiting....");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
            return found;
        }


        // DELETION
        // function for deleting employee and rewriting or removing its records
        // called by BLL
        public void DeleteEmployee(Employee e)
        {
            List<Employee> emp = GetAll();
            emp.RemoveAll(employee => employee.Name == e.Name);

            ReSaveAll(emp);
        }

        // UPDATION-----DEPARTMENT and SALARY----seperate function called by seperate function of BLL according to user's choice
        // function for updating some employee's info
        // called by BLL
        public void UpdateEmployeeDepartment(Employee e, string newDName)
        {
            e.Department = newDName;
            // now rewriting and saving the changes in file
            // will make a list by getall method and then will remove the employee with old info
            // after that will add the emp with new info

            List<Employee> emp = GetAll();
            emp.RemoveAll(employee => employee.Name == e.Name);
            emp.Add(e);

            ReSaveAll(emp);
        }
        public void UpdateEmployeeSalary(Employee e, string newSal)
        {
            e.Salary = newSal;
            // now rewriting and saving the changes in file
            // will make a list by getall method and then will remove the employee with old info
            // after that will add the emp with new info

            List<Employee> emp = GetAll();
            emp.RemoveAll(employee => employee.Name == e.Name);
            emp.Add(e);

            ReSaveAll(emp);
        }

        public void UpdateDeptNameAfterNameChanges(string oldName, string newName)
        {
            List<Employee> employees = GetAll();
            foreach (Employee e in employees) 
            {
                if (e.Department == oldName) { 
                    e.Department = newName;
                }
            }
            ReSaveAll(employees);
        }
        public void ReSaveAll(List<Employee> employees)
        {
            FileStream fin = new FileStream("Employees.txt", FileMode.Create);
            StreamWriter finW = new StreamWriter(fin);
            foreach (Employee employee in employees) 
            {
                string data = $"{employee.ID};{employee.Name};{employee.Age};" +
                $"{employee.Department};{employee.Salary};{employee.JoiningDate}";
                finW.WriteLine(data);
            }
            finW.Close();
            fin.Close();
            //Console.WriteLine("Employee Updated....");
        }
    }
}
