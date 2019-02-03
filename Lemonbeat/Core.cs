using Services.BLL.BooksService;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonbeat
{
    public class Core
    {
        public void Request(List<string> actions, object model)
        {
            switch (model)
            {
                case Book book:
                    ResponseBookOK.Invoke(book);
                    break;
                default:
                    break;
            }
        }

        public Action<Book> ResponseBookOK;
        public Action<BookException> ResponseBookBAD;


    }
}
