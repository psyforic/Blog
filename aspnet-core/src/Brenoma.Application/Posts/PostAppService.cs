using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Brenoma.Posts.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brenoma.Posts
{
    public class PostAppService : BrenomaAppServiceBase, IPostAppService
    {
        private readonly IPostManager _postManager;
        private readonly IRepository<Post, Guid> _postRepository;

        public PostAppService(IPostManager postManager, IRepository<Post, Guid> postRepository)
        {
            _postManager = postManager;
            _postRepository = postRepository;
        }
        public async Task CreateAsync(PostCreateInput input)
        {
            var post = Post.Create(input.Title, input.Body, input.AuthorId, input.CategoryId);
            await _postManager.CreateAsync(post);
        }

        public async Task DeleteAsync(Guid id)
        {
            var post = await _postManager.GetAsync(id);
            await _postRepository.DeleteAsync(post);
        }

        public async Task<ListResultDto<PostListDto>> GetAll()
        {
            var posts = await _postRepository.GetAll()
                .Include(x => x.Author)
                .Include(x => x.Category)
                .OrderByDescending(x => x.CreationTime)
                .ToListAsync();
            if (posts != null)
            {
                return new ListResultDto<PostListDto>(ObjectMapper.Map<List<PostListDto>>(posts));
            }
            return null;
        }

        public async Task<PostListDto> GetByAuthorId(Guid id)
        {
            var post = await _postRepository.FirstOrDefaultAsync(x => x.AuthorId == id);
            if (post != null)
            {
                return ObjectMapper.Map<PostListDto>(post);
            }
            throw new UserFriendlyException("No Posts Found For the given Author");
        }

        public async Task<PostListDto> GetById(Guid id)
        {
            var post = await _postManager.GetAsync(id);
            return ObjectMapper.Map<PostListDto>(post);
        }
    }
}
