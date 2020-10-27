using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Organization
{
    abstract class Employee
    {
        #region Fields;

        private int number;
        private string name;
        private string lastName;
        private int age;
        private string department;
        private int salary;
        private int daysWorked;

        #endregion Fields

        #region Constuctor;

        public Employee(int Number, string Name, string LastName, int Age,string Department, int Salary, int DaysWorked)
        {
            this.number = Number;
            this.name = Name;
            this.lastName = LastName;
            this.age = Age;
            this.department = Department;
            this.salary = Salary;
            this.daysWorked = DaysWorked;
        }

        #endregion Constuctor        

        #region Properties;

        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public string Department
        {
            get { return this.department; }
            set { this.department = value; }
        }

        public virtual int Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        public int DaysWorked
        {
            get { return this.daysWorked; }
            set { this.daysWorked = value; }
        }

        #endregion Properties

        #region Methods;

        public string print()
        {
            return $"{this.number}" +
                   $"{this.name,20}" +
                   $"{this.lastName,20}" +
                   $"{this.age,20}" +
                   $"{this.department,20}" +
                   $"{this.salary,20}" +
                   $"{this.daysWorked,20}";
        }

        #endregion Methods
    }
}
