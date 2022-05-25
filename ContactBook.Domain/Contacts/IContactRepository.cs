using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Domain.Contacts
{
    public interface IContactRepository
    {
        Task<Contact> Add(Contact contact);

        void Update(Contact contact);

        void Delete(int id);

        Task<Contact> GetAsync(int id);
    }
}
