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
    /// <summary>
    /// Configuration of Author entity for dbContext. Implements IEntityTypeConfiguration
    /// </summary>
    public class AuthorConfiguration:IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasMany(a => a.Books);
        }
    }
}
