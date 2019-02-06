using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Book
{
    public class BookException: Exception
    {
        public BookException()
        {
        }
        public BookException(string message):base(message)
        {

        }
        public BookException(string message, Exception innerEx):base(message, innerEx)
        {
            
        }
    }
}
