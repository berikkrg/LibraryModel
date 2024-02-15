using LibraryAPI.Data;
using LibraryData.Configurations;
using LibraryData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.Context
{
    public class LibraryDbContext : DbContext
    {
        private readonly ILogger _logger;
        private readonly StreamWriter _logStream = new StreamWriter("Data/Logging/LibraryDbLog.txt", append: true);
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options, ILogger<LibraryDbContext> logger) : base(options)
        {
            _logger = logger;
        }
        //public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
        //    : base(options)
        //{

        //    Database.EnsureCreated();

        //}

        //public LibraryDbContext(DbContextOptions options) : base(options)
        //{
        //    Database.EnsureCreated();
        //}

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ReaderConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            string connString = config.GetConnectionString("LibraryConnectionString");
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddProvider(new StreamLogProvider(_logStream)))).EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(connString);
        }

        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
        }

    }

    
}
