using ContactBook.Domain.Groups;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace ContactBook.Application.Groups.Commands
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, int>
    {
        private readonly IGroupRepository _groupRepository;
        public DeleteGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
        }
        public async Task<int> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var model = await _groupRepository.GetAsync(request.Id);
            if (model == null)
            {
                throw new EntryPointNotFoundException();
            }
            _groupRepository.Delete(request.Id);
            return 1;
        }
    }
    public class DeleteGroupCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
