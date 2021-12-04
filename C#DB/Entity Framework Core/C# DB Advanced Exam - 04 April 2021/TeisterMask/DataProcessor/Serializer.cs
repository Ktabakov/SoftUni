namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Projects");
            XmlSerializerNamespaces nameSpaces = new XmlSerializerNamespaces();
            nameSpaces.Add(string.Empty, string.Empty);
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectsTaskExportDto[]), root);

            using StringWriter writer = new StringWriter(sb);

            ProjectsTaskExportDto[] projects = context
                                      .Projects
                                      .ToArray()
                                      .Where(p => p.Tasks.Any())
                                      .Select(p => new ProjectsTaskExportDto()
                                      {
                                          ProjectName = p.Name,
                                          TasksCount = p.Tasks.Count(),
                                          HasEndDate = p.DueDate != null ? "Yes" : "No",
                                          Tasks = p.Tasks
                                          .Select(t => new TaskExportDto()
                                          {
                                              Name = t.Name,
                                              Label = t.LabelType.ToString()
                                          })
                                          .OrderBy(t => t.Name)
                                          .ToArray()
                                      })
                                      .OrderByDescending(p => p.TasksCount)
                                      .ThenBy(p => p.ProjectName)
                                      .ToArray();

            serializer.Serialize(writer, projects, nameSpaces);
            return sb.ToString().TrimEnd();

        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context
                .Employees
                .ToArray()
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                    .Where(et => et.Task.OpenDate >= date)
                    .Select(et => et.Task)
                    .OrderByDescending(d => d.DueDate)
                    .ThenBy(d => d.Name)
                    .Select(t => new
                    {
                        TaskName = t.Name,
                        OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = t.LabelType.ToString(),
                        ExecutionType = t.ExecutionType.ToString()
                    })
                    .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Count())
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            Console.WriteLine(json);
            return json.ToString().TrimEnd();
        }
    }
}