using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GutenbergBookshelf.Models
{
    public class Book
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int CurrentPage { get; set; }
        public bool IsFinished { get; set; }

    }
}
