using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Organization
{
    abstract class Department
    {
        #region Constructor;

        public Department(string Name,
                          DateTime DateOfCreation,
                          //int NumberOfEmployees,
                          //int NumberOfDepartments,
                          string ParentDepartment)
        {
            this.name = Name;
            this.dateOfCreation = DateOfCreation;
            this.numberOfEmployees = 0;
            this.numberOfDepartments = 0;
            this.parentDepartment = ParentDepartment;
        }

        #endregion Constructor

        #region Fields;

        protected string name { get; set; }
        protected DateTime dateOfCreation { get; set; }
        public int numberOfEmployees { get; set; }
        public int numberOfDepartments { get; set; }
        protected string parentDepartment { get; set; }

        #endregion Fields


        #region Properties;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public DateTime DateOfCreation
        {
            get { return this.dateOfCreation; }
            set { this.dateOfCreation = value; }
        }

        public int NumberOfEmployees
        {
            get { return this.numberOfEmployees; }
            set { this.numberOfEmployees = value; }
        }

        public int NumberOfDepartments
        {
            get { return this.numberOfDepartments; }
            set { this.numberOfDepartments = value; }
        }

        public string ParentDepartment
        {
            get { return this.parentDepartment; }
            set { this.parentDepartment = value; }
        }

        #endregion Properties


        #region Methods;

        string print()
        {
            return $"{this.name,15}" +
                   $"{this.dateOfCreation,15}" +
                   $"{this.numberOfEmployees}";
        }

        //public virtual int CountEmployees()
        //{
        //    int count = 0;

        //    foreach (Employee emply in Repository.employees)
        //        if (emply.Department == Name)
        //            ++count;
        //    return count;
        //}

        //public virtual int CountDepartments()
        //{
        //    int count = 0;

        //    foreach (Department dept in Repository.departments)
        //        if (dept.ParentDepartment == Name)
        //            ++count;
        //    return count;
        //}

        #endregion Methods
    }
}
