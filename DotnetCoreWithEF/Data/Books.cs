namespace DotnetCoreWithEF.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Titile { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string? Category { get; set; }
        //public string? Language { get; set; }
        public int LanguageId { get; set; }
        public int TotalPages { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public Languages Language { get; set; }
        public string? CoverPhotoUrl { get; set; }
    }
}
