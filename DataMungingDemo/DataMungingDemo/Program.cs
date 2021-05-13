using DataMungingDemo.Business;
using DataMungingDemo.SingletonFunctions;

namespace DataMungingDemo
{
    class Program
    {
        /// <summary>
        /// Main Entry Point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Call WeatherData function to read weather.txt file and then get and calculate Smallest Temperature Spread
            var weather = new Weather();
            weather.WeatherData();

            // Call Football League function to read football.txt file and then get and calculate team with smallest Difference of for and Against
            var football = new Football();
            football.FootballLeague();

            ReadLine.GetReadLine().ReadWait();
        }
    }
}

