namespace Singleton.Example
{
    public sealed class Logger : IDisposable
    {
        private static Logger? _instance;
        private static readonly object _lock = new object();

        private StreamWriter _writer;

        private Logger()
        {
            _writer = new StreamWriter("app.log", append: true);
            _writer.AutoFlush = true;
        }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }

        public void Log(string message)
        {
            _writer.WriteLine($"{DateTime.Now:HH:mm:ss} - {message}");
        }

        public void Dispose()
        {
            _writer?.Dispose();
        }
    }
}
