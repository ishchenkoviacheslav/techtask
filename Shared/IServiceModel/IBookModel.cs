using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Services
{
    public interface IBookModel
    {
        string Name { get; set; }
        string Author { get; set; }
    }
}
