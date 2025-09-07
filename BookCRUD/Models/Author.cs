﻿using System.ComponentModel.DataAnnotations;

namespace BookCRUD.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
