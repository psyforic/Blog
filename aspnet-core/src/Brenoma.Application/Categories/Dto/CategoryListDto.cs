using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Brenoma.Posts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brenoma.Categories.Dto
{
    [AutoMapFrom(typeof(Category))]
    public class CategoryListDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
