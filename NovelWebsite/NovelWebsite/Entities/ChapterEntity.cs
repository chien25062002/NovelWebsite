﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class ChapterEntity : BaseEntity
    {
        [Key]
        public int ChapterId { get; set; }

        [ForeignKey("BookId")]
        public BookEntity Book { get; set; }
        public int BookId { get; set; }
        public string ChapterNumber { get; set; }
        public string ChapterName { get; set; }
        public string Content { get; set; }
        public int Views { get; set; }
        public int Likes { get; set; }
    }
}
