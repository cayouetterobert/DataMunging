using System;

namespace DataMungingDemo.SingletonFunctions
{
    // using Single-responsibility principle
    #region ReadLine
    public sealed class ReadLine
    {
        private static readonly ReadLine _readLine = new ReadLine();

        private ReadLine()
        {
        }

        public static ReadLine GetReadLine()
        {
            return _readLine;
        }

        public void ReadWait()
        {
            Console.ReadLine();
        }
    }

    #endregion
}
