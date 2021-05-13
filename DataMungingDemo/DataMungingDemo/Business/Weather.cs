using System.Linq;
using DataMungingDemo.SingletonFunctions;

namespace DataMungingDemo.Business
{
    public class Weather
    {
        /// <summary>
        /// Function to get weather.txt file data, calculate min, max, smallest Temperature Spread and then print the expected result
        /// </summary>
        public void WeatherData()
        {
            // Call ReadDataFromFile function to read text file data{parameters: file name, index of Dy column, index of MxT column, index of MnT}
            var list = ReadFile.Read().FileReader("weather.txt", 0, 1, 2);

            // Get smallest temperature spread by difference of MxT, MnT  
            // Get Day with min difference by comparing all differences
            var smallestTemperatureSpread = list.Aggregate((i1, i2) => i1.Difference < i2.Difference ? i1 : i2);

            // Get Day with maximum
            var biggest = list.Aggregate((i1, i2) => i1.Max > i2.Max ? i1 : i2);

            // Get Day with minimum MnT
            var smallest = list.Aggregate((i1, i2) => i1.Min < i2.Min ? i1 : i2);

            // Print Day with Smallest Temperature Spread 
            Logger.GetLogger().WriteMessage("Smallest Temperature Spread Day = " + smallestTemperatureSpread?.Title);
            Logger.GetLogger().WriteMessage("Min Temperature Day = " + smallest?.Title);
            Logger.GetLogger().WriteMessage("Max Temperature Day = " + biggest?.Title);
        }
    }
}
