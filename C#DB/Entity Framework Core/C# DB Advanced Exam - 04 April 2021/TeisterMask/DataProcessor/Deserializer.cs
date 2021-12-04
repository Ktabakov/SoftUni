namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Projects");
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectsImportDto[]), root);
            using StringReader reader = new StringReader(xmlString);

            ProjectsImportDto[] projectsDto = (ProjectsImportDto[])serializer.Deserialize(reader);

            List<Project> projects = new List<Project>();

            foreach (var dto in projectsDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isOpenDateValid = DateTime.TryParseExact(dto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime openDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? dueDate = null;
                if (!string.IsNullOrWhiteSpace(dto.DueDate))
                {
                    bool isDueDateValid = DateTime.TryParseExact(dto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime realDueDate);

                    if (!isDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    dueDate = realDueDate;
                }

                Project p = new Project()
                {
                    Name = dto.Name,
                    OpenDate = openDate,
                    DueDate = dueDate,
                };

                HashSet<Task> projectTasks = new HashSet<Task>();

                foreach (var taskDto in dto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    bool isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime taskOpenDate); 

                    if (!isTaskOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out DateTime taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    if(taskOpenDate > taskDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < p.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (p.DueDate.HasValue && taskDueDate > p.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Task task = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType,
                        Project = p
                    };

                    projectTasks.Add(task);
                }
                p.Tasks = projectTasks;
                projects.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedProject, p.Name, p.Tasks.Count));
            }
            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var dbTasks = context
                .Tasks
                .Select(t => t.Id)
                .ToArray();

            IEnumerable<EmployeeImportDto> employeeDto = JsonConvert.DeserializeObject<IEnumerable<EmployeeImportDto>>(jsonString);
            List<Employee> employees = new List<Employee>();

            foreach (var dto in employeeDto)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Employee e = new Employee()
                {
                    Email = dto.Email,
                    Phone = dto.Phone,
                    Username = dto.Username,
                };


                ICollection<EmployeeTask> tasks = new HashSet<EmployeeTask>();

                foreach (var taskId in dto.Tasks.Distinct())
                {
                    if (!dbTasks.Contains(taskId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask t = new EmployeeTask()
                    {
                        TaskId = taskId,
                        Employee = e                      
                    };
                    tasks.Add(t);
                }

                e.EmployeesTasks = tasks;
                employees.Add(e);
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, e.Username, e.EmployeesTasks.Count));
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}