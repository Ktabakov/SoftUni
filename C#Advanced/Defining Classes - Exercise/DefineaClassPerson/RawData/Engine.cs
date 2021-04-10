using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Engine
    {
        public double EngineSpeed { get; set; }

        public double EnginePower { get; set; }

        public Engine(double engineSpeed, double enginePower)
        {
            EngineSpeed = engineSpeed;
            EnginePower = enginePower;
        }
    }
}
