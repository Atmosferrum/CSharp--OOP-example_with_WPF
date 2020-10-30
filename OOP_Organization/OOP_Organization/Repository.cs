using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using System.Collections.ObjectModel;
//using System.Collections.Specialized;

namespace OOP_Organization
{
    struct Repository
    {
        #region Variables;

        static public List<Employee> employees; //Employees DATA array

        static public List<Department> departments; //Departments DATA array

        List<XElement> xElements; //XML Data

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
            employees = new List<Employee>();            
            departments = new List<Department>();            
            this.xElements = new List<XElement>();
            //employees.CollectionChanged += EmployeesChanged;
            //departments.CollectionChanged += DepartmentsChanged;
            Create();
            Save();
        }

        #endregion Constructor;

        #region Methods;

        void Create()
        {
            AddDepartment(new Organization("Organization", DateTime.Now, ""));
            AddDepartment(new Bureau("Management", DateTime.Now, "Organization"));
            AddDepartment(new Bureau("Strategy", DateTime.Now, "Organization"));
            AddDepartment(new Division("Marketing", DateTime.Now, "Management"));
            AddDepartment(new Division("PR", DateTime.Now, "Management"));
            AddDepartment(new Division("Production", DateTime.Now, "Strategy"));
            AddDepartment(new Division("HR", DateTime.Now, "Strategy"));

            foreach (Department dept in departments)
            {
                if (dept is Organization)
                    AddEmloyee(new HeadOfOrganization(0, "G", "Man", 99, dept.Name, 0, 1000));
                else
                {
                    AddEmloyee(new HeadOfDepartment(0, "Ulfric", "Stormcloak", 45, dept.Name, 0, 365));
                    AddEmloyee(new Worker(1, "Sam", "Fisher", 33, dept.Name, 0, 155));
                    AddEmloyee(new Worker(1, "Sam", "Fisher", 33, dept.Name, 0, 155));
                    AddEmloyee(new Intern(1, "Illusive", "Man", 33, dept.Name, 0, 155));
                    AddEmloyee(new Intern(1, "Illusive", "Man", 33, dept.Name, 0, 155));
                    AddEmloyee(new Intern(1, "Illusive", "Man", 33, dept.Name, 0, 155));
                    AddEmloyee(new Intern(1, "Illusive", "Man", 33, dept.Name, 0, 155));
                }

            }
        }

        void Save()
        {
            CreateToSave();
        }

        void CreateToSave()
        {
            foreach (Department dept in departments)
            {
                XElement myDepartment = new XElement(dept.GetType().ToString());
                XAttribute departmentName = new XAttribute("name", dept.Name);
                XAttribute departmentDateOfCreation = new XAttribute("dateOfCreation", DateTime.Now.ToShortDateString());
                XAttribute departmentNumberOfEmployees = new XAttribute("numberOfEmployees", dept.NumberOfEmployees);
                XAttribute departmentNumberDepartments = new XAttribute("numberOfDepartments", dept.NumberOfDepartments);
                XAttribute departmentParentDepartment = new XAttribute("parentDepartment", dept.ParentDepartment);
                myDepartment.Add(departmentName,
                                 departmentDateOfCreation,
                                 departmentNumberOfEmployees,
                                 departmentNumberDepartments,
                                 departmentParentDepartment);

                EmployeeToSave(dept.Name, ref myDepartment);

                xElements.Add(myDepartment);                
            }

            OrganizeToSave();
        }

        //private void EmployeesChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.Action == NotifyCollectionChangedAction.Add)
        //    {
        //        foreach (ICount i in departments)
        //        {
        //            i.CountEmployees();
        //        };
        //    }
        //}

        //private void DepartmentsChanged(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.Action == NotifyCollectionChangedAction.Add)
        //    {
        //        foreach (ICount i in departments)
        //        {
        //            i.CountDepartments();
        //        };
        //    }
            
        //}

        void OrganizeToSave()
        {
            XElement father;
            father = xElements.Find(item => (string)item.Attribute("name") == "Organization");

            foreach (XElement x in xElements)
            {
                switch ((string)x.Attribute("parentDepartment"))
                {
                    case "Strategy":
                        XElement strategy;
                        strategy = xElements.Find(item => (string)item.Attribute("name") == "Strategy");
                        strategy.Add(x);
                        break;
                    case "Management":
                        XElement management;
                        management = xElements.Find(item => (string)item.Attribute("name") == "Management");
                        management.Add(x);
                        break;
                    case "Organization":
                        father.Add(x);
                        break;
                    default:
                        break;
                }
            }

            father.Save("new.xml");
        }

        void EmployeeToSave(string name, ref XElement dept)
        {
            foreach (Employee emply in employees)
            {
                if (emply.Department == name)
                {
                    XElement myEmployee = new XElement("EMPLOYEE");

                    XAttribute employeeNumber = new XAttribute("number", emply.Number);
                    XAttribute employeeName = new XAttribute("name", emply.Name);
                    XAttribute employeeLastName = new XAttribute("lastName", emply.LastName);
                    XAttribute employeeAge = new XAttribute("age", emply.Age);
                    XAttribute employeeDepartment = new XAttribute("department", emply.Department);
                    XAttribute employeeSalary = new XAttribute("salary", emply.Salary);
                    XAttribute employeeNumberOfProjects = new XAttribute("numberOfProjects", emply.DaysWorked);

                    myEmployee.Add(employeeNumber, employeeName, employeeLastName, employeeAge, employeeDepartment, employeeSalary, employeeNumberOfProjects);
                    dept.Add(myEmployee);                   
                }
            }
        }


        void AddEmloyee(Employee newEmployee)
        {
            employees.Add(newEmployee);
            this.employeeIndex++;

        }

        void AddDepartment(Department newDepartment)
        {
            departments.Add(newDepartment);
            this.departmentIndex++;
        }

        #endregion Methods
    }
}
