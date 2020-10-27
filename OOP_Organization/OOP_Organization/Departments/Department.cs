using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Organization
{
    struct Department
    {
        #region Constructor;

        public Department(string Name,
                          DateTime DateOfCreation,
                          int NumberOfEmployees,
                          int NumberOfDepartments,
                          string ParentDepartment)
        {
            this.name = Name;
            this.dateOfCreation = DateOfCreation;
            this.numberOfEmployees = NumberOfEmployees;
            this.numberOfDepartments = NumberOfDepartments;
            this.parentDepartment = ParentDepartment;
        }

        #endregion Constructor

        #region Fields;

        private string name { get; set; }
        private DateTime dateOfCreation { get; set; }
        private int numberOfEmployees { get; set; }
        private int numberOfDepartments { get; set; }
        private string parentDepartment { get; set; }

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

        #endregion Methods
    }
}
