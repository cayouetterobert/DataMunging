using System;

namespace DataMungingDemo.SingletonFunctions
{
    // using Single-responsibility principle
    #region Logger
    public sealed class Logger
    {
        private static readonly Logger _logger = new Logger();

        private Logger()
        {
        }

        public static Logger GetLogger()
        {
            return _logger;
        }

        public void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
    #endregion
}
