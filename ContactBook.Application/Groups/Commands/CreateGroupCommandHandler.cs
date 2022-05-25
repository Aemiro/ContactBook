using ContactBook.Application.Groups.Queries;
using ContactBook.Domain.Groups;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ContactBook.Application.Groups.Commands
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, GroupQueryModel>
    {
        private readonly IGroupRepository _groupRepository;
        public CreateGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
        }
        public async Task<GroupQueryModel> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var newModel = new Group(request.Name, request.FileInfo.ToString(), request.CreatedAt, request.UpdatedAt);
            var model = await _groupRepository.Add(newModel);
            return new GroupQueryModel
            {
                Id = model.Id,
                Name = model.Name,
                Picture = model.Picture,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt

            };
        }
    }
    public class CreateGroupCommand : IRequest<GroupQueryModel>
    {
        public String Name { get; set; }
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
