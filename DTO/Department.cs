using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Department
    {
        public Department() { }
        public Department(int id, string name, string descrip) 
        {
            ID = id;
            Name = name;
            Description = descrip;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string ToString()
        {
            return $"\nID: {ID}\nName: {Name}\nDescription: {Description}\n";
        }
    }
}
