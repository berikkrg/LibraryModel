namespace LibraryAPI.Data
{
    public class StreamLogProvider : ILoggerProvider
    {
        private readonly StreamWriter _logStream;

        public StreamLogProvider(StreamWriter logStream)
        {
            _logStream = logStream;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new StreamLogger(_logStream);
        }

        public void Dispose()
        {
        }
    }

    public class StreamLogger : ILogger
    {
        private readonly StreamWriter _logStream;

        public StreamLogger(StreamWriter logStream)
        {
            _logStream = logStream;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _logStream.WriteLine(formatter(state, exception));
        }
    }
}
