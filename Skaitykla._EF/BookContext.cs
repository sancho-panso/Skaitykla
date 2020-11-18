using Microsoft.EntityFrameworkCore;
using Skaitykla._Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skaitykla._EF
{
    public class BookContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LendingBook> Lendings { get; set; }

        protected override  void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=skaityklaMVC;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        }
}


