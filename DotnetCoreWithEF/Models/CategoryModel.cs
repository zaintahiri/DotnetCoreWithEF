﻿using System.ComponentModel.DataAnnotations;

namespace DotnetCoreWithEF.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
