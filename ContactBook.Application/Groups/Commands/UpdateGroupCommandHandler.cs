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
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, GroupQueryModel>
    {
        private readonly IGroupRepository _groupRepository;
        public UpdateGroupCommandHandler(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
        }
        public async Task<GroupQueryModel> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var model = await _groupRepository.GetAsync(request.Id);
            if (model == null)
            {
                throw new EntryPointNotFoundException();
            }
            model.SetName(request.Name);
            if (request.FileInfo.ToString().Length > 0)
            {
                model.SetPicture(request.FileInfo.ToString());
            }
            model.SetUpdatedAt(request.UpdatedAt);
            _groupRepository.Update(model);
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
    public class UpdateGroupCommand : IRequest<GroupQueryModel>
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public JObject FileInfo { get; private set; }
        public IFormFile Picture { get; set; }
        internal DateTime UpdatedAt { get; private set; }
        public void SetUpdatedAt(DateTime updatedAt)
        {
            this.UpdatedAt = updatedAt;
        }
        public void SetFileInfo(JObject fileInfo)
        {
            this.FileInfo = fileInfo;
        }
    }
}
