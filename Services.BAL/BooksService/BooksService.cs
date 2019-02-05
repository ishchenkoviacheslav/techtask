using DB.DAL;
using Shared.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public class BooksService: IBookService
    {
        public void DuplicatePackingSlipForRoyalty()
        {

        }

        public void GenerateCommission(float sum)
        {

        }
        public static void CallService(Book book)
        {
            BooksService service = new BooksService();
            service.DuplicatePackingSlipForRoyalty();
            //like price :)
            service.GenerateCommission(book.Name.GetHashCode());
        }
    }
}
