using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class EmployeeBLL
    {
        public List<Employee> GetAll()
        {
            EmployeeDAL dal = new EmployeeDAL();
            return dal.GetAll();
        }
        public void CreateEmployee(Employee employee)   // could later on change the return type to bool
                                                        // to make sure the employee creation was successful
                                                        // ....or do it here as well
        {
            // will validate that the department exists....isValidDepartment()
            DepartmentDAL deptdal = new DepartmentDAL();
            List<Department> departments =  deptdal.GetAll();
            EmployeeDAL empdal = new EmployeeDAL();
            List<Employee> employees = empdal.GetAll();

            if (isValidDepartment(employee.Department, departments))
            {
                Console.WriteLine("Valid Department.");
                // will validate employee ID.....isValidID()
                if (!isValidID(employee.ID, employees))
                {
                    Console.WriteLine("Valid Id.");
                    // call the save function of DAL by a EmployeeDAL object
                    empdal.Save(employee);
                    Console.WriteLine("Employee added successfully....");
                }
                else
                {
                    Console.WriteLine("Invalid Id. Employee with this id already exists...Employee not added.");
                }
            }
            else
            {
                Console.WriteLine("Invalid department...Employee not added.");
            }
            
        }
        public void UpdateEmployeeDepartment(string empName, string newDeptName) // could later on change the return type to bool to make sure the employee update was successful....
        {
            // first validate that the employee exists, return if it exists - by calling the ValidEmployee()
            EmployeeDAL empdal = new EmployeeDAL();
            List<Employee> employees =  empdal.GetAll();
            Employee e = ValidEmployee(empName, employees);

            // if it is true then call the UpdateDepartment() of DAL by EmployeeDAL object
            if (e != null) 
            {
                empdal.UpdateEmployeeDepartment(e, newDeptName);
            }
            else
            {
                Console.WriteLine("Employee does not exist.....");
            }
        }
        public void UpdateEmployeeSalary(string empName, string newSalary) 
        {
            // first validate that the employee exists, return if it exists - by calling the ValidEmployee()
            EmployeeDAL empdal = new EmployeeDAL();
            List<Employee> employees = empdal.GetAll();
            Employee e = ValidEmployee(empName, employees);

            // if it is true then call the UpdateSalary() of DAL by EmployeeDAL object
            if (e != null)
            {
                empdal.UpdateEmployeeSalary(e, newSalary);
            }
            else
            {
                Console.WriteLine("Employee does not exist.....");
            }
            
        }
        public void DeleteEmployee(string empName)
        {
            // ensure that the employee with this name exists by ValidEmployee()
            EmployeeDAL empdal = new EmployeeDAL();
            List<Employee> employees = empdal.GetAll();
            Employee e = ValidEmployee(empName, employees);

            // call the DeleteEmployee() of DAL
            if (e != null && OngoingProject(e))
            {
                empdal.DeleteEmployee(e);
                Console.WriteLine("Employee deleted successfully.....");
            }
            else
            {
                Console.WriteLine("Employee does not exist.....");
            }
            //Prevents deletion if the employee is part of ongoing projects(future extension)
            // OngoingProjectExist() - will always return true for now 
        }

        public List<Employee> Search(string keyword, int type)     // will need to add a parameter telling
                                                    // us what we are searching employee by 
        {
            // will call the search() of DAL
            EmployeeDAL dal = new EmployeeDAL();
            // will implement logic in search of DAL for each attribute we want to search by 
            return dal.Search(keyword, type);
        }

        private static bool isValidDepartment(string empdptname, List<Department> departments)
        {
            foreach(Department d in departments)
            {
                if (empdptname == d.Name)
                {
                    return true;
                }
            }
            return false;
        }
        private static bool isValidID(int empId, List<Employee> employees)
        {
            foreach (Employee emp in employees)
            {
                if (emp.ID == empId)
                {
                    return true;
                }
            }
            return false;
        }
        private static Employee ValidEmployee(string name, List<Employee> employees) // checks if the employee with name exists in the file or not
        {
            foreach (Employee emp in employees)
            {
                if (emp.Name.Equals(name))
                {
                    return emp;
                }
            }
            return null;
        }
        private bool OngoingProject(Employee e)
        {
            return true;
        }
    }
}
