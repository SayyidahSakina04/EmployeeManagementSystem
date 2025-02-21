using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BLL;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace PL
{
    internal class EmployeeManagement
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("---------WELCOME TO EMPLOYEE MANAGEMENT SYSTEM---------");
            Console.WriteLine("MENU:");
            int choice = 0;
            Console.WriteLine("1. List All Employees");
            Console.WriteLine("2. Add New Employee");
            Console.WriteLine("3. Update Employee Details");
            Console.WriteLine("4. Delete Employee");
            Console.WriteLine("5. Search Employees (by ID, Name, Department, Joining Date)");
            Console.WriteLine("6. Manage Departments(Add, Edit, Delete Departments");
            Console.WriteLine("7. Exit");
            Console.WriteLine("\nEnter the number your action: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice) 
            {
                case 1:
                    // listing all employees
                    Console.WriteLine("\n\nList of All Employees");
                    EmployeeBLL readbll = new EmployeeBLL();
                    List<Employee> employees = readbll.GetAll();
                    foreach(Employee e in employees)
                    {
                        Console.WriteLine(e.ToString());
                    }
                    break;
                case 2:
                    // add new employee
                    Console.WriteLine("Enter ID:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Age:");
                    int age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Department:");
                    string department = Console.ReadLine();
                    Console.WriteLine("Enter Salary:");
                    string salary = Console.ReadLine();
                    Console.WriteLine("Enter Joining date:");
                    string jDate = Console.ReadLine();
                    Employee employee = new Employee(id, name, age, department, salary, jDate);
                    EmployeeBLL addbll = new EmployeeBLL();
                    addbll.CreateEmployee(employee);
                    break;
                case 3:
                    // update department or salary --- give option
                    Console.WriteLine("1. Update Department.");
                    Console.WriteLine("2. Update Salary.");
                    int update = int.Parse(Console.ReadLine());
                    if(update == 1)
                    {
                        Console.WriteLine("Enter employee name: ");
                        string emp = Console.ReadLine();
                        Console.WriteLine("Enter new department of employee:");
                        string dept = Console.ReadLine();
                        EmployeeBLL bll = new EmployeeBLL();
                        bll.UpdateEmployeeDepartment(emp, dept);
                    }
                    else if (update == 2)
                    {
                        Console.WriteLine("Enter employee name: ");
                        string emp = Console.ReadLine();
                        Console.WriteLine("Enter new salary of employee:");
                        string newsalary = Console.ReadLine();
                        EmployeeBLL bll = new EmployeeBLL();
                        bll.UpdateEmployeeSalary(emp, newsalary);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice....");
                    }
                    break;
                case 4:
                    // deleting employee
                    Console.WriteLine("Enter employee name: ");
                    string empName = Console.ReadLine();
                    EmployeeBLL empbll = new EmployeeBLL();
                    empbll.DeleteEmployee(empName);
                    break;
                case 5:
                    Console.WriteLine("Search employee by:");
                    SearchEmployee();
                    break;
                case 6:
                    Console.WriteLine("MANAGEMENT OF DEPARTMENT: ");
                    DepartmentManagement();
                    break;
                case 7:
                    Console.WriteLine("EXITING THE PROGRAM....");
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
                                
                               
        }
        public static void SearchEmployee()
        {
            Console.WriteLine("1. Id.");
            Console.WriteLine("2. Name.");
            Console.WriteLine("3. Department.");
            Console.WriteLine("4. JoiningDate.");
            Console.WriteLine("5. Exit.");
            Console.WriteLine("Enter the action you want...");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your keyword:");
            string keyword = Console.ReadLine();
            EmployeeBLL empbll = new EmployeeBLL();
            List<Employee> searchedEmp = empbll.Search(keyword, choice);
            if (searchedEmp.Count != 0) {
                Console.WriteLine("Employee details:");
                foreach (Employee emp in searchedEmp)
                {
                    Console.WriteLine(emp.ToString());
                }
            }
        }
        public static void DepartmentManagement()
        {
            Console.WriteLine("0. List Departments.");
            Console.WriteLine("1. Add Department.");
            Console.WriteLine("2. Edit Department Name.");
            Console.WriteLine("3. Edit Department Description. ");
            Console.WriteLine("4. Delete Department.");
            Console.WriteLine("5. Exit.");
            Console.WriteLine("\nEnter your choice of action: ");
            int choice = int.Parse(Console.ReadLine());
            DepartmentBLL deptbll = new DepartmentBLL();

            switch (choice)
            {
                case 0:
                    List<Department> depts = deptbll.GetAll();
                    foreach (Department dept in depts)
                    {
                        Console.WriteLine(dept.ToString());
                    }
                    break;
                case 1: // adding dept
                    Console.WriteLine("Enter ID:");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Description:");
                    string description = Console.ReadLine();
                    Department department = new Department(id, name, description);
                    //DepartmentBLL deptbll = new DepartmentBLL();
                    deptbll.AddDepartment(department);
                    break;
                case 2: // edit dept name
                    Console.WriteLine("Enter old name:");
                    string oldName = Console.ReadLine();
                    Console.WriteLine("Enter new name:");
                    string newName = Console.ReadLine();
                    //DepartmentBLL deptbll = new DepartmentBLL();
                    deptbll.UpdateDepartmentName(oldName, newName);

                    break;
                case 3: // edit dept description
                    Console.WriteLine("Enter department name:");
                    string deptname = Console.ReadLine();
                    Console.WriteLine("Enter new description: ");
                    string descrip = Console.ReadLine();
                    //DepartmentBLL deptbll = new DepartmentBLL();
                    deptbll.UpdateDepartmentDescription(deptname, descrip);

                    break;
                case 4: // delete department
                    Console.WriteLine("Enter department name:");
                    string depname = Console.ReadLine();
                    deptbll.DeleteDepartment(depname);
                    break; 
                case 5:
                    Console.WriteLine("Exiting......");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
