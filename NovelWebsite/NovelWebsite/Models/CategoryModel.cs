using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class CategoryModel : BaseModel
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
    }
}
