using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Organization
{
    class Intern : Employee
    {

        public Intern(int Number, string Name, string LastName, int Age, string Department, int Salary, int NumberOfProjects)
            : base(Number, Name, LastName, Age, Department, Salary, NumberOfProjects)
        {

        }

        public override int Salary { get => base.Salary; set => base.Salary = value; }
    }
}
