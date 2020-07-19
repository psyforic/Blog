using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Brenoma.Authors;
using Brenoma.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brenoma.Posts.Dto
{
    [AutoMapFrom(typeof(Post))]
    public class PostListDto : FullAuditedEntityDto<Guid>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
