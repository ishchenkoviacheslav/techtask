using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public class BookException: Exception
    {
        public BookException(string message, Exception innerEx):base(message, innerEx)
        {
            
        }
    }
}
