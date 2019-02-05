using DB.DAL;
using Shared.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL.BooksService
{
    public class BooksService: IBookService
    {
       // private static DbContext context = new DbContext();
       //public static BookException Process(Book book, int typeOfOperation)
       // {
       //     try
       //     {
       //         BookOperations op = (BookOperations)typeOfOperation;
       //         switch (op)
       //         {
       //             // If the payment is for a physical product, generate a packing slip for shipping
       //             // If the payment is for a book, create a duplicate packing slip for the royalty department.
       //             // If the payment is for a physical product or a book, generate a commission payment to the
       //             case BookOperations.BuyRealBook:

       //                 break;
       //             // If the payment is for a book, create a duplicate packing slip for the royalty department.
       //             case BookOperations.BuyEBook:

       //                 break;
       //             default:
       //                 break;
       //         }
       //         book.Validate();
       //         context.Books.Add(book);
       //         context.Save();
       //         return null;
       //     }
       //     catch (BookException bookEx)
       //     {
       //         return bookEx;
       //     }
            
       //}
    }
}
