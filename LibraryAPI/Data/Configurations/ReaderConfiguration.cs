using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryData.Configurations
{
    /// <summary>
    /// Configuration of Author entity for dbContext. Implements IEntityTypeConfiguration
    /// </summary>
    public class ReaderConfiguration : IEntityTypeConfiguration<Reader>
    {
        public void Configure(EntityTypeBuilder<Reader> builder)
        {
            builder.HasKey(r => r.Id);
            builder.HasMany(r => r.Books).WithOne(b => b.Reader);
        }
    }
}
