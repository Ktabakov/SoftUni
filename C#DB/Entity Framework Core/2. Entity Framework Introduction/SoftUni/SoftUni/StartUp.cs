namespace SoftUni
{
    using Microsoft.EntityFrameworkCore;
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext DbContext = new SoftUniContext();

            Console.WriteLine(RemoveTown(DbContext));
        }

        //Problem 3
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Employee[] employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 4
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 5
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 6
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address newAddress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(newAddress);

            Employee nakovEmployee = context
                .Employees
                .First(e => e.LastName == "Nakov");

            nakovEmployee.Address = newAddress;
            context.SaveChanges();

            var employeesAddresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToArray();

            foreach (var e in employeesAddresses)
            {
                sb.AppendLine(e);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 007
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(pd => pd.Project.StartDate.Year >= 2001 && pd.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    ProjectsArr = e.EmployeesProjects.Select(p =>
                    new
                    {
                        ProjectName = p.Project.Name,
                        StartDate = p.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        EndDate = p.Project.EndDate.HasValue ? p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                    })
                    .ToArray()
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var ep in e.ProjectsArr)
                {
                    sb.AppendLine($"--{ep.ProjectName} - {ep.StartDate} - {ep.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 8
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                .Addresses
                .OrderByDescending(o => o.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(ad => new
                {
                    AddressText = ad.AddressText,
                    TownName = ad.Town.Name,
                    EmployeesCount = ad.Employees.Count
                })
                .ToArray();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 9
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var empWithId147 = context
                .Employees
                .Include(p => p.EmployeesProjects)
                .ThenInclude(p => p.Project)
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    ProjectsArr = e.EmployeesProjects.Select(p => new
                    {
                        ProjectNames = p.Project.Name
                    })
                    .OrderBy(p => p.ProjectNames)
                    .ToArray()
                })
                .ToArray();



            foreach (var employee in empWithId147)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                foreach (var item in employee.ProjectsArr)
                {
                    sb.AppendLine(item.ProjectNames);
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {

            StringBuilder sb = new StringBuilder();

            var departments = context
                .Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(e => new
                {
                    DepartmentName = e.Name,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Employees = e.Employees.Select(emp => new
                    {
                        EmployeeFirstName = emp.FirstName,
                        EmployeeLastName = emp.LastName,
                        EmployeeJobTitle = emp.JobTitle
                    })
                    .OrderBy(e => e.EmployeeFirstName)
                    .ThenBy(e => e.EmployeeLastName)
                    .ToArray()
                })
                .ToArray();


            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.DepartmentName} - {dep.ManagerFirstName} {dep.ManagerLastName}");

                foreach (var emp in dep.Employees)
                {
                    sb.AppendLine($"{emp.EmployeeFirstName} {emp.EmployeeLastName} - {emp.EmployeeJobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context
                .Projects
                .OrderByDescending(d => d.StartDate)
                .Take(10)
                .Select(i => new
                {
                    i.Name,
                    i.Description,
                    StartDate = i.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var p in projects)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

              var employees = context
                .Employees
                .Where(d => d.Department.Name == "Engineering" ||
                d.Department.Name == "Tool Design" ||
                d.Department.Name == "Marketing" ||
                d.Department.Name == "Information Services");
                
            foreach (var employee in employees)
            {
                employee.Salary += employee.Salary * 0.12m;
            }

            context.SaveChanges();

            var employeesToPrint = employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var e in employeesToPrint)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in employeees)
            {

                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {

            StringBuilder sb = new StringBuilder();

            var projectWithId2 = context
                .Projects
                .First(p => p.ProjectId == 2);

             context.EmployeesProjects
                .ToList()
                .ForEach(ep => context.EmployeesProjects.Remove(ep));

            context.Projects.Remove(projectWithId2);

            context.SaveChanges();

            context
                .Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList()
                .ForEach(p => sb.AppendLine(p));

            return sb.ToString().TrimEnd();
        }

        //Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            Address[] addressesInSeattle = context
                .Addresses
                .Where(a => a.Town.Name == "Seattle")
                .ToArray();

            Employee[] employeesInSeattle = context
                .Employees
                .ToArray()
                .Where(e => addressesInSeattle.Any(a => a.AddressId == e.AddressId))
                .ToArray();

            foreach (Employee e in employeesInSeattle)
            {
                e.AddressId = null;
            }

            context.Addresses
                .RemoveRange(addressesInSeattle);

            Town seattle = context
                .Towns
                .First(t => t.Name == "Seattle");

            context.Towns.Remove(seattle);

            context.SaveChanges();

            return $"{addressesInSeattle.Length} addresses in Seattle were deleted";
        }
    }
}
