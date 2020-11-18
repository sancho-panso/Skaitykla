using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Skaitykla._Domain
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public Guid AuthorID { get; set; }
        public List<LendingBook> Lendings { get; set; }
    }
}
