using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRPG.Game
{
    public class TestClass
    {
        public string Name { get; private set; } = string.Empty;

        public bool DoSomething(string value)
        {
            Name = value;
            return true;
        }
    }
}
