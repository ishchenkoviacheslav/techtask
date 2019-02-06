using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Services
{
    public interface IBookService
    {
        string Name { get; set; }
        string Author { get; set; }
    }
}
