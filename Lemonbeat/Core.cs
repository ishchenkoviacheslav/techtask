using Services.BLL.BooksService;
using Shared.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lemonbeat
{
    public class Core
    {
        //public void Request(object model, int typeOfOperation)
        //{
        //    switch (model)
        //    {
        //        case Book book:
        //            BookException bookEx = BooksService.Process(book, typeOfOperation);
        //            if (bookEx == null)
        //                ResponseBookOK?.Invoke(book);
        //            else
        //                ResponseBookBAD?.Invoke(bookEx);
        //            break;
        //        default:
        //            break;
        //    }
        //}

        public Action<Book> ResponseBookOK;
        public Action<BookException> ResponseBookBAD;

        public Action<string> CommonError;
    }
}
