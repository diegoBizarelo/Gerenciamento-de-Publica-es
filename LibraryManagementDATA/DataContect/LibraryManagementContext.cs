using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementDATA.DataContect
{
    public class LibraryManagementContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BookAuthor>().HasKey(e => new { e.AuthorId, e.BookId});

            builder.Entity<BookAuthor>().HasOne(e => e.Book)
                                        .WithMany(b => b.BooksAuthors)
                                        .HasForeignKey(b => b.BookId);
            builder.Entity<BookAuthor>().HasOne(e => e.Author)
                                        .WithMany(a => a.BooksAuthors)
                                        .HasForeignKey(a => a.AuthorId);
        }
    }
}
