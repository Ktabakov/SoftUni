using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Robot : IIdentifiable, IModel
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Id { get; private set; }

        public string Model { get; private set; }
    }
}
