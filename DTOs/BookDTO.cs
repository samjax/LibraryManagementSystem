namespace LibraryManagment.Api.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsCheckedOut { get; set; }

        public int PatronId { get; set; }
    }
}