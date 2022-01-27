using MyFirstServer.Server.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstServer.Server.HTTP
{
    public class Session
    {
        public const string SessionCookieName = "MyWebSeerverSID";

        public const string SessionCurrentDateKey = "CurrentDate";

        public const string SessionUnserKey = "AuthenticatedUserId";

        private Dictionary<string, string> data;

        public string Id { get; private set; }
        public Session(string id)
        {
            Guard.AgainstNull(id, nameof(id));

            Id = id;
            data = new Dictionary<string, string>();
        }

        public string this[string key]
        {
            get => this.data[key];
            set => this.data[key] = value;
        }


        public void Clear()
            => this.data.Clear();
        public bool ContainsKey(string key)
            => this.data.ContainsKey(key);
    }
}
