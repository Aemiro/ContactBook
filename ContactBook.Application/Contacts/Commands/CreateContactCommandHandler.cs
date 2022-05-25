using ContactBook.Application.Contacts.Queries;
using ContactBook.Domain.Contacts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace ContactBook.Application.Contacts.Commands
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ContactQueryModel>
    {
        private readonly IContactRepository _contactRepository;
        public CreateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }
        public async Task<ContactQueryModel> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var newModel = new Contact(request.Name, request.Nickname, request.Phone, request.Email, request.Website, request.Gender, request.FileInfo.ToString(), request.CreatedAt, request.UpdatedAt, request.GroupId, request.BirthDate);
            var model = await _contactRepository.Add(newModel);
            return new ContactQueryModel
            {
                Id = model.Id,
                Name= model.Name,
                Nickname= model.Nickname,
                Phone= model.Phone,
                Email= model.Email,
                Gender= model.Gender,
                Website= model.Website,
                Picture= model.Picture,
                BirthDate= model.BirthDate,
                CreatedAt= model.CreatedAt,
                UpdatedAt= model.UpdatedAt,
                GroupId= model.GroupId
            };
        }
    }
    public class CreateContactCommand : IRequest<ContactQueryModel>
    {
        public String Name { get; set; }
        public String Nickname { get; set; }
        public String Phone { get; set; }
        public String Email { get; set; }
        public String Gender { get; set; }
        public String Website { get; set; }
        public int? GroupId { get; set; }
        public DateTime? BirthDate { get; set; }
        internal JObject FileInfo { get; private set; }
        public IFormFile Picture { get; set; }

        internal DateTime CreatedAt { get; private set; }
        public void SetCreatedAt(DateTime createdAt)
        {
            CreatedAt = createdAt;
        }
        internal DateTime UpdatedAt { get; private set; }
        public void SetUpdatedAt(DateTime updatedAt)
        {
            UpdatedAt = updatedAt;
        }

        public void SetFileInfo(JObject fileInfo)
        {
            this.FileInfo = fileInfo;
        }
    }
}
