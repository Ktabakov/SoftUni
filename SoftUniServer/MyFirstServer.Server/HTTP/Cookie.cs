using MyFirstServer.Server.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstServer.Server.HTTP
{
    public class Cookie
    {
        public Cookie(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            this.Name = name;
            this.Value = value;
        }

        public string Name { get; private set; }

        public string Value { get; private set; }

        public override string ToString()
            => $"{this.Name} = {this.Value}";
    }
}
