using DB.DAL;
using Shared.Book;
using System;
using System.Collections.Generic;
using System.Text;
using Shared.Services;
namespace Services.BLL
{
    public class BookService: IService<IBookModel>
    {
        public void DuplicatePackingSlipForRoyalty(string name, string Author)
        {
            Console.WriteLine(nameof(DuplicatePackingSlipForRoyalty));
        }

        
        public void CallService(IBookModel bookModel)
        {
            DuplicatePackingSlipForRoyalty(bookModel.Name, bookModel.Author);
        }
    }
}
