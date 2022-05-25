
using ContactBook.Domain.Contacts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ContactBook.Persistence.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Contact> Add(Contact contact)
        {
            var model = _context.contacts.Add(contact).Entity;
            await _context.SaveChangesAsync();
            return model;
        }

        public void Delete(int id)
        {
            _context.Remove(_context.contacts.FindAsync(id).Result);
            _context.SaveChangesAsync();
        }

        public async Task<Contact> GetAsync(int id)
        {
            return await _context.contacts.FindAsync(id);

        }

        public void Update(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

    }
}
