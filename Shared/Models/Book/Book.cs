using Shared.IServiceModel;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Book
{
    public class Book: IBookModel, IDeliveryModel,  IGenerateCommissionPaymentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Address { get; set; }
        public int ImportantNumber { get; set; }
        public float Sum { get; set; }

        /// <summary>
        /// Check all field is not null or empty of some another validation rules
        /// </summary>
        public void Validate()
        {
            IBookModel ibook = this;
            if (string.IsNullOrEmpty(ibook.Author))
                new BookException("Author is null or empty");

            if (string.IsNullOrEmpty(ibook.Name))
                new BookException("Name is null or empty");

            IDeliveryModel idel = this;
            if (string.IsNullOrEmpty(idel.Address))
                new BookException("Address is null or empty");

        }
    }
}
