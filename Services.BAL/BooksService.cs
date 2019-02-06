using DB.DAL;
using Shared.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public class BooksService: IService<Book>
    {
        public void DuplicatePackingSlipForRoyalty()
        {
            Console.WriteLine(nameof(DuplicatePackingSlipForRoyalty));
        }

        
        public void CallService(Book book)
        {
            //BooksService service = new BooksService();
            DuplicatePackingSlipForRoyalty();
            //like price :)
        }
    }
}
