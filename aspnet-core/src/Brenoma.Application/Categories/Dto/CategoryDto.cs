using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brenoma.Categories.Dto
{
    [AutoMapTo(typeof(Category))]
    public class CategoryDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
