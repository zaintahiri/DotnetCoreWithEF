﻿using DotnetCoreWithEF.Enums;
using System.ComponentModel.DataAnnotations;

namespace DotnetCoreWithEF.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [StringLength(200,ErrorMessage ="Title should be more then 5 characters",MinimumLength =5)]
        [Required(ErrorMessage ="Please enter title")]
        public string Titile { get; set; }
        [Required(ErrorMessage = "Please enter author")]
        public string Author { get; set; }
        [StringLength(200,MinimumLength =10)]
        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }
        public string? Category { get; set; }

        [Required(ErrorMessage = "Please choose language")]
        //public string Language { get; set; }
        //public int Language { get; set; }
        public int LanguageId { get; set; }
        public string? Language { get; set; }


        //added additional property for multi language
        //[Required(ErrorMessage = "Please choose languages")]
        //public List<string> MultiLanguages { get; set; }

        [Required(ErrorMessage = "Please choose languages")]
        public LanguagesEnum LanguageEnum { get; set; }

        [Display(Name ="Total pages of Book")]
        [Required(ErrorMessage = "Please enter total pages")]
        public int TotalPages { get; set; }

        [Display(Name ="Please select cover photo")]
        [Required]
        public IFormFile CoverPhoto{ get; set; }
        public string? CoverPhotoUrl { get; set; }

        [Display(Name = "Please select gallery photos")]
        [Required]
        public IFormFileCollection GalleryPhotos { get; set; }      

        public List<GalleryModel>? GalleryModels { get; set; }

        [Display(Name = "Please select PDF")]
        [Required]
        public IFormFile BookPdf { get; set; }
        public string? BookPdfURL { get; set; }

    }
}
