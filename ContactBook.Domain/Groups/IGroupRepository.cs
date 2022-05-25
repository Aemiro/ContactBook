using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Domain.Groups
{
    public interface IGroupRepository
    {
        Task<Group> Add(Group group);

        void Update(Group group);

        void Delete(int id);

        Task<Group> GetAsync(int id);
    }
}
