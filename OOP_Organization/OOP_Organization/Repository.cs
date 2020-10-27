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

        static public List<Employee> employees; //Employees DATA array

        static public List<Department> departments; //Departments DATA array

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

            Create();
            Save();
        }

        #endregion Constructor;



        #region Methods;

        void Create()
        {
            AddDepartment(new Organization("Organization", DateTime.Now, null));
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
            List<XElement> xElements = new List<XElement>();

            foreach (Department dept in departments)
            {
                switch (dept)
                {
                    case Bureau b:                        
                        XElement myBureau = new XElement(dept.GetType().ToString());
                        XAttribute bureauName = new XAttribute("name", dept.Name);
                        XAttribute bureauDateOfCreation = new XAttribute("dateOfCreation", DateTime.Now.ToShortDateString());
                        XAttribute bureauNumberOfEmployees = new XAttribute("numberOfEmployees", dept.NumberOfEmployees);
                        XAttribute bureauNumberDepartments = new XAttribute("numberOfDepartments", dept.NumberOfDepartments);
                        XAttribute bureauParentDepartment = new XAttribute("parentDepartment", dept.ParentDepartment);
                        myBureau.Add(bureauName,
                                     bureauDateOfCreation,
                                     bureauNumberOfEmployees,
                                     bureauParentDepartment,
                                     bureauParentDepartment);

                        xElements.Add(myBureau);
                        break;
                    case Division d:
                        XElement myDivision = new XElement(dept.GetType().ToString());
                        XAttribute divisionName = new XAttribute("name", dept.Name);
                        XAttribute divisionDateOfCreation = new XAttribute("dateOfCreation", DateTime.Now.ToShortDateString());
                        XAttribute divisionNumberOfEmployees = new XAttribute("numberOfEmployees", dept.NumberOfEmployees);
                        XAttribute divisionNumberDepartments = new XAttribute("numberOfDepartments", dept.NumberOfDepartments);
                        XAttribute divisionParentDepartment = new XAttribute("parentDepartment", dept.ParentDepartment);

                        xElements.Add(myDivision);
                        break;
                    default:
                        XElement myOrganization = new XElement(dept.GetType().ToString());
                        XAttribute organizationName = new XAttribute("name", dept.Name);
                        XAttribute organizationDateOfCreation = new XAttribute("dateOfCreation", DateTime.Now.ToShortDateString());
                        XAttribute organizationNumberOfEmployees = new XAttribute("numberOfEmployees", dept.NumberOfEmployees);
                        XAttribute organizationNumberDepartments = new XAttribute("numberOfDepartments", dept.NumberOfDepartments);
                        XAttribute organizationParentDepartment = new XAttribute("parentDepartment", dept.ParentDepartment);
                        myOrganization.Add(organizationName,
                                           organizationDateOfCreation,
                                           organizationNumberOfEmployees,
                                           organizationNumberDepartments,
                                           organizationParentDepartment);

                        xElements.Add(myOrganization);
                        break;
                }

                XElement father;
                father = xElements.Find(item => item.Name == "Organization");

                foreach (XElement x in xElements)
                {
                    switch (x.Attribute("parenetDepartment").ToString())
                    {                        
                        case "Strategy":
                            XElement strategy;
                            strategy = xElements.Find(item => item.Name == "Strategy");
                            strategy.Add(x);
                            father.Add(strategy);
                            break; 
                        case "Management":
                            XElement management;
                            management = xElements.Find(item => item.Name == "Management");
                            management.Add(x);
                            father.Add(management);
                            break;
                        default:
                            father.Add(x);
                            break;
                    }
                }
                

                

                //foreach (Employee emply in employees)
                //{
                //    if (emply.Department == dept.Name)
                //    {
                //        XElement myEmployee = new XElement(emply.GetType().ToString());

                //        XAttribute employeeNumber = new XAttribute("number", emply.Number);
                //        XAttribute employeeName = new XAttribute("name", emply.Name);
                //        XAttribute employeeLastName = new XAttribute("lastName", emply.LastName);
                //        XAttribute employeeAge = new XAttribute("age", emply.Age);
                //        XAttribute employeeDepartment = new XAttribute("department", emply.Department);
                //        XAttribute employeeSalary = new XAttribute("salary", emply.Salary);
                //        XAttribute employeeNumberOfProjects = new XAttribute("numberOfProjects", emply.DaysWorked);

                //        myEmployee.Add(employeeNumber, employeeName, employeeLastName, employeeAge, employeeDepartment, employeeSalary, employeeNumberOfProjects);

                //        myDepartment.Add(myEmployee);

                //        ++numberOfEmployees;
                //    }
                //}

                //XAttribute departmentNumberOfEmployees = new XAttribute("numberOfEmployees", numberOfEmployees);

                //myDepartment.Add(departmentName, departmentDateOfCreation, departmentNumberOfEmployees);

                //myOrganization.Add(myDepartment);
            }

            //myOrganization.Save("new.xml");
        }

        #endregion Methods

        void AddEmloyee(Employee newEmployee)
        {
            employees.Add(newEmployee);
            //this.employees[employeeIndex] = newEmployee;
            this.employeeIndex++;
        }

        void AddDepartment(Department newDepartment)
        {
            departments.Add(newDepartment);
            //this.departments[departmentIndex] = newDepartment;
            this.departmentIndex++;
        }
    }
}
