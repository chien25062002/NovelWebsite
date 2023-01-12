﻿using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class BookTagEntity : BaseEntity
    {
        [Key]
        public string BookTagId { get; set; }
        public string BookTagName { get; set; }
    }
}