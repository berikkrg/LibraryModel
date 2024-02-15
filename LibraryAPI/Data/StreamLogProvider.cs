namespace LibraryAPI.Data
{
    /// <summary>
    /// The StreamLogProvider class implements the ILoggerProvider interface and provides a logger that writes to a stream.
    /// </summary>
    public class StreamLogProvider : ILoggerProvider
    {
        // A StreamWriter that writes characters to a stream in a particular encoding, here used for logging.
        private readonly StreamWriter _logStream;
        /// <summary>
        /// The constructor for the StreamLogProvider class.
        /// </summary>
        /// <param name="logStream">The StreamWriter that writes characters to a stream in a particular encoding.</param>
        public StreamLogProvider(StreamWriter logStream)
        {
            _logStream = logStream;
        }
        /// <summary>
        /// The CreateLogger method creates a new StreamLogger with the specified category name.
        /// </summary>
        /// <param name="categoryName">The name of the category for messages produced by the logger.</param>
        /// <returns>A new StreamLogger with the specified category name.</returns>
        public ILogger CreateLogger(string categoryName)
        {
            return new StreamLogger(_logStream);
        }

        public void Dispose()
        {
        }
    }
    /// <summary>
    /// The StreamLogger class implements the ILogger interface and provides a logger that writes to a stream.
    /// </summary>
    public class StreamLogger : ILogger
    {
        private readonly StreamWriter _logStream;
        /// <summary>
        /// The constructor for the StreamLogger class.
        /// </summary>
        /// <param name="logStream">The StreamWriter that writes characters to a stream in a particular encoding.</param>
        public StreamLogger(StreamWriter logStream)
        {
            _logStream = logStream;
        }

        /// <summary>
        /// The BeginScope method creates a new scope for grouping related log messages.
        /// </summary>
        /// <param name="state">The state to associate with the scope.</param>
        /// <returns>A disposable object that ends the log scope on dispose.</returns>
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        /// <summary>
        /// The IsEnabled method checks if the specified log level is enabled.
        /// </summary>
        /// <param name="logLevel">The log level to check.</param>
        /// <returns>True if the specified log level is enabled; otherwise, false.</returns>
        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }
        /// <summary>
        /// The Log method writes a log entry.
        /// </summary>
        /// <param name="logLevel">The log level of the entry.</param>
        /// <param name="eventId">The event ID of the entry.</param>
        /// <param name="state">The state of the entry.</param>
        /// <param name="exception">The exception related to the entry.</param>
        /// <param name="formatter">The function to create a string message of the log.</param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _logStream.WriteLine(formatter(state, exception));
        }
    }
}
