using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Organization
{
    class Division : Department
    {
        public Division(string Name,
                        DateTime DateOfCreation,
                        //int NumberOfEmployees,
                        //int NumberOfDepartments, 
                        string ParentDepartment)
            : base(Name,
                  DateOfCreation,
                  //NumberOfEmployees, 
                  //NumberOfDepartments, 
                  ParentDepartment)
        { }
    }
}
