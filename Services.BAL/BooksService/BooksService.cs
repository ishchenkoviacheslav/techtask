using DB.DAL;
using Shared.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public class BooksService
    {
        public void DuplicatePackingSlipForRoyalty()
        {
            Console.WriteLine(nameof(DuplicatePackingSlipForRoyalty));
        }

        public void GenerateCommission(float sum)
        {
            Console.WriteLine(nameof(GenerateCommission) + " " + sum);
        }
        public void CallService(Book book)
        {
            //BooksService service = new BooksService();
            DuplicatePackingSlipForRoyalty();
            //like price :)
            GenerateCommission(book.Name.GetHashCode());
        }
    }
}
