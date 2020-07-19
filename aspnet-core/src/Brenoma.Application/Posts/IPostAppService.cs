using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Brenoma.Posts.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brenoma.Posts
{
    public interface IPostAppService : IApplicationService
    {
        Task CreateAsync(PostCreateInput input);
        Task DeleteAsync(Guid id);
        Task<PostListDto> GetById(Guid id);
        Task<PostListDto> GetByAuthorId(Guid id);
        Task<ListResultDto<PostListDto>> GetAll();
    }
}
