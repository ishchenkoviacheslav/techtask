using DB.DAL;
using Shared.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.BLL
{
    public class BooksService
    {
        public void DuplicatePackingSlipForRoyalty(string name, string Author)
        {
            Console.WriteLine(nameof(DuplicatePackingSlipForRoyalty));
        }

        
        public void CallService(string Name, string Author)
        {
            DuplicatePackingSlipForRoyalty(Name, Author);
        }
    }
}
