using ContactBook.Domain.Groups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ContactBook.Persistence.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _context;

        public GroupRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Group> Add(Group group)
        {
            var model = _context.groups.Add(group).Entity;
            await _context.SaveChangesAsync();
            return model;
        }

        public void Delete(int id)
        {
            _context.Remove(_context.groups.FindAsync(id).Result);
            _context.SaveChangesAsync();
        }

        public async Task<Group> GetAsync(int id)
        {
            var group = await _context.groups.FindAsync(id);
            if (group != null)
            {
                await _context.Entry(group)
                    .Collection(i => i.Contacts).LoadAsync();
            }

            return group;
        }

        public void Update(Group group)
        {
            _context.Entry(group).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

    }
}
