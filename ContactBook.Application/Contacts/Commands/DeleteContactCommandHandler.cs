using ContactBook.Domain.Contacts;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace ContactBook.Application.Contacts.Commands
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;
        public DeleteContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }
        public async Task<int> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var model = await _contactRepository.GetAsync(request.Id);
            if (model == null)
            {
                throw new EntryPointNotFoundException();
            }
            _contactRepository.Delete(request.Id);
            return 1;
        }
    }

    public class DeleteContactCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
