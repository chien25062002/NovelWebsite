using System;
using System.Collections.Generic;

namespace NovelWebsite.Models
{
    public class Category : Base
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
    }
}
