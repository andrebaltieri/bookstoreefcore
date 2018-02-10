using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IList<AuthorBook> Authors { get; set; }
    }
}