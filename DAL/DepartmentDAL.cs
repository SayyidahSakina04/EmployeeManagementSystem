using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DepartmentDAL
    {
        public void Save(Department department)
        {
            StreamWriter finW = new StreamWriter("Departments.txt", true);
            string data = $"{department.ID};{department.Name};{department.Description}";
            finW.WriteLine(data);
            finW.Close();
        }
        public List<Department> GetAll()
        {
            List<Department> departments = new List<Department>();

            StreamReader foutR = new StreamReader("Departments.txt");
            string data = foutR.ReadLine();
            while (data != null)
            {
                string[] departmentInfo = data.Split(";");

                Department departmentObj = new Department();
                departmentObj.ID = int.Parse(departmentInfo[0]);
                departmentObj.Name = departmentInfo[1];
                departmentObj.Description = departmentInfo[2];

                departments.Add(departmentObj);
                data = foutR.ReadLine();
            }
            foutR.Close();
            return departments;
        }


        // DELETION
        // function for deleting department and rewriting or removing its record
        // called by BLL

        public void DeleteDepartment(string name)
        {
            List<Department> departments = GetAll();
            departments.RemoveAll(depts => depts.Name == name);

            ReSaveAll(departments);
        }

        // UPDATION-----NAME and DESCRIPTION----seperate function called by seperate function of BLL according to user's choice
        // function for updating some department's info
        // called by BLL

        public void UpdateName(string oldName, string newName)
        {
            List<Department> departments = GetAll();
            foreach (Department department in departments) 
            { 
                if (department.Name == oldName)
                {
                    department.Name = newName;
                    break;
                }
            }
            EmployeeDAL empdal = new EmployeeDAL();
            empdal.UpdateDeptNameAfterNameChanges(oldName,newName);
            ReSaveAll(departments);
        }
        public void UpdateDescription(string deptName, string newDescrip)
        {
            List<Department> departments = GetAll();
            foreach (Department department in departments)
            {
                if (department.Name == deptName)
                {
                    department.Description = newDescrip;
                    break;
                }
            }
            ReSaveAll(departments);
        }
        public void ReSaveAll(List<Department> dept)
        {
            FileStream fin = new FileStream("Departments.txt", FileMode.Create);
            StreamWriter finW = new StreamWriter(fin);
            foreach (Department department in dept)
            {
                string data = $"{department.ID};{department.Name};{department.Description}";
                finW.WriteLine(data);
            }
            finW.Close();
            fin.Close();
        }
    }
}
