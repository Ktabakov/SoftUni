﻿using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext DbContext = new FootballBettingContext();

            DbContext.Database.EnsureCreated();

            Console.WriteLine("Created");

            DbContext.Database.EnsureDeleted();
        }
    }
}
