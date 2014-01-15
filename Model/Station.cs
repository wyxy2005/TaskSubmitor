using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class Station
    {

        public Station()
        { 
        }

        public Station(string address, string name, string id, string ename, string shortName, string num)
        {
            this.Address = address;
            this.Name = name;
            this.Id = id;
            this.Ename = ename;
            this.ShortName = shortName;
            this.Num = num;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Ename { get; set; }
        public string ShortName { get; set; }
        public string Num { get; set; }
    }
}
