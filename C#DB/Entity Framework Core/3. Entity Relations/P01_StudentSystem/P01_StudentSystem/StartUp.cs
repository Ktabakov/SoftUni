using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using System;

namespace P01_StudentSystem
{
    class StartUp
    {
        static void Main(string[] args)
        {
            StudentSystemContext dbContext = new StudentSystemContext();

            dbContext.Database.Migrate();

            Console.WriteLine("Db Created");
        }
    }
}
