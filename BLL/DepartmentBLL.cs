using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class DepartmentBLL
    {
        public List<Department> GetAll()
        {
            DepartmentDAL dal = new DepartmentDAL();
            return dal.GetAll();   
        }
        public void AddDepartment(Department department) 
        { 
            // call the save() of DepartmentDAL
            DepartmentDAL deptdal = new DepartmentDAL();
            List<Department> departments = deptdal.GetAll();
            if (!isValidDepartment(department.ID, department.Name, departments))
            {
                deptdal.Save(department);
                Console.WriteLine("Department added.");
            }
            else
            {
                Console.WriteLine("Department already exists...");
            }
        }
        public void DeleteDepartment(string dName)
        {
            // checking if department exists
            DepartmentDAL deptdal = new DepartmentDAL();
            List<Department> departments = deptdal.GetAll();
            if (isValidDepartment(0, dName, departments))
            {
                deptdal.DeleteDepartment(dName);
                Console.WriteLine("Department deleted.");
            }
            else
            {
                Console.WriteLine("Department does not...");
            }
        }
        public void UpdateDepartmentName(string oldName, string newName)
        {
            DepartmentDAL deptdal = new DepartmentDAL();
            List<Department> departments = deptdal.GetAll();
            if (isValidDepartment(0,oldName, departments))
            {
                // calls an updateName() of departmentDAL
                DepartmentDAL dal = new DepartmentDAL();
                dal.UpdateName(oldName, newName);
                Console.WriteLine("Department updated...");
            }
            else
            {
                Console.WriteLine("Department not found.");
            }
        }
        public void UpdateDepartmentDescription(string deptName, string newDescription) 
        {
            DepartmentDAL deptdal = new DepartmentDAL();
            List<Department> departments = deptdal.GetAll();
            if (isValidDepartment(0, deptName, departments))
            {
                // calls an updateDescription() of departmentDAL
                DepartmentDAL dal = new DepartmentDAL();
                dal.UpdateDescription(deptName, newDescription);
                Console.WriteLine("Department updated...");
            }
            else
            {
                Console.WriteLine("Department not found.");
            }
        }
        private static bool isValidDepartment(int id, string empdptname, List<Department> departments)
        {
            foreach (Department d in departments)
            {
                if ((empdptname == d.Name) || (id == d.ID))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
