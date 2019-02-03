using Shared.Book;
using System;
using System.Collections.Generic;

namespace Lemonbeat
{
    class Program
    {
        static void Main(string[] args)
        {
            Core<Book> core = new Core<Book>();
            core.Request(new List<string>(), new Book {Author = "Anderson", Name = "My life" });
        }
    }
}
