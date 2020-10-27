using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OOP_Organization
{
    struct Repository
    {
        #region Variables;

        List<Employee> employees; //Employees DATA array

        public List<Department> departments; //Departments DATA array

        private string path; //PATH to file

        public int employeeIndex; //Current INDEX for employee to add

        public int departmentIndex; //Current INDEX for department to add

        #endregion Variables

        #region Constructor;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Path">Path to file to construct</param>
        public Repository(string Path)
        {
            this.path = Path;
            this.employeeIndex = 0;
            this.departmentIndex = 0;
            this.employees = new List<Employee>();
            this.departments = new List<Department>();

            //Load(path);
        }

        #endregion Constructor;

        //Make some code
    }
}
