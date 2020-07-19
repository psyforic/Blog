using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brenoma.Categories.Dto
{
    [AutoMapTo(typeof(Category))]
    public class CategoryCreateInput
    {
        public string Name { get; set; }
    }
}
