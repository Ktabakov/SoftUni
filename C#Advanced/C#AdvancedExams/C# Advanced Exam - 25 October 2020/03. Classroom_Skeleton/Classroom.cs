using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public int Capacity { get; set; }

        public int Count { get { return students.Count; } }

        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            if (students.Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return $"No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = students.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);
            
            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {firstName} {lastName}";
            }

            return $"Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();

            if (students.Any(p => p.Subject == subject))
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");

                foreach (var item in students)
                {
                    if (item.Subject == subject)
                    {
                        sb.AppendLine($"{item.FirstName} {item.LastName}");
                    }
                }
                return sb.ToString().Trim();
            }
            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName , string lastName)
        {
            Student student = students.FirstOrDefault(p => p.FirstName == firstName && p.LastName == lastName);

            return student;
        }
    }
}
