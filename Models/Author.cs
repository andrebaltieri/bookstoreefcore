using System.Collections.Generic;

namespace BookStore.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public User User { get; set; }
        public IList<AuthorBook> Books { get; set; }
    }
}