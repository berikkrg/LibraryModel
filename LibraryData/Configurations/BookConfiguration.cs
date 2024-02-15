using LibraryData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId);
            builder.HasOne(b => b.Category).WithMany(a => a.Books).HasForeignKey(b => b.CategoryId);
            builder.HasOne(b => b.Reader).WithMany(a => a.Books).HasForeignKey(b => b.ReaderId);

        }
    }
}
