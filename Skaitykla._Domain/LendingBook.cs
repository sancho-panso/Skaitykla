using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Skaitykla._Domain
{
    public class LendingBook
    {

        public int ID { get; set; }
        public int LendedBookID { get; set; }
        public Book LendedBook { get; set; }
        public User User { get; set; }
        public int UserID { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public bool isAvailable { get => (TimeTo < DateTime.Now);}
    }
}
