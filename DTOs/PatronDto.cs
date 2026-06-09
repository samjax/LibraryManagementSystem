using LibraryManagment.Api.Models;

namespace LibraryManagment.Api.DTOs
{
    public class PatronDto
    {
        public int PatronId { get; set; }
        public string? Name { get; set; } = string.Empty;

        public List<Book>? Books { get; set; } = new List<Book>();
    }
}