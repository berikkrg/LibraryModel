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
    /// <summary>
    /// The LibraryDbContext class represents the session with the database and can be used to query and save instances of your entities.
    /// It is a subclass of Microsoft.EntityFrameworkCore.DbContext.
    /// </summary>

    public class LibraryDbContext : DbContext
    {
        // An instance of ILogger to enable logging.
        private readonly ILogger _logger;
        // A StreamWriter that writes characters to a stream in a particular encoding, here used for logging.
        private readonly StreamWriter _logStream = new StreamWriter("Data/Logging/LibraryDbLog.txt", append: true);
        /// <summary>
        /// The constructor for the LibraryDbContext class.
        /// </summary>
        /// <param name="options">The options to be used by a DbContext.</param>
        /// <param name="logger">An instance of ILogger to be used for logging.</param>
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options, ILogger<LibraryDbContext> logger) : base(options)
        {
            _logger = logger;
        }
        //DbSets are represent a collection of all entities depending on type of entity
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuration of relations between database entities.
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
            // configure the options builder to use a console logger and enable sensitive data logging
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())).EnableSensitiveDataLogging();
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddProvider(new StreamLogProvider(_logStream)))).EnableSensitiveDataLogging();
            optionsBuilder.UseSqlServer(connString);
        }

        public override void Dispose()
        {
            base.Dispose();
            //dispose logstream after using it
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            //asynchronously dispose logstream after using it
            await _logStream.DisposeAsync();
        }

    }

    
}
