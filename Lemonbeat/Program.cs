using Shared;
using System;
using System.Collections.Generic;

namespace Lemonbeat
{
    class Program
    {
        static void Main(string[] args)
        {
            Core core = new Core();
            core.Request(new List<string>, new Book {Author = "Anderson", Name = "My life" });
        }
    }
}
