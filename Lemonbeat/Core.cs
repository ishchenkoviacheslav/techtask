using Services.BLL.BooksService;
using Shared.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonbeat
{
    public class Core<T>
    {
        public void Request(List<string> actions, object model)
        {
            if(actions == null || actions.Count == 0)
            {
                CommonError.Invoke("actions is null or count == 0");
                return;
            }
            switch (model)
            {
                case Book book:
                    BookException bookEx = BooksService.Process(actions, book);
                    if (bookEx == null)
                        ResponseBookOK.Invoke(book);
                    else
                        ResponseBookBAD.Invoke(bookEx);
                    break;
                default:
                    break;
            }
        }

        public Action<T> ResponseBookOK;
        public Action<BookException> ResponseBookBAD;

        public Action<string> CommonError;
    }
}
