using System.Linq;
using DataMungingDemo.SingletonFunctions;

namespace DataMungingDemo.Business
{
    public class Football
    {
        /// <summary>
        /// Function to get football.txt file data, calculate smallest Difference between For and Against then print the expected result
        /// </summary>
        public void FootballLeague()
        {
            // Call ReadDataFromFile function to read text file data{parameters: file name, index of Team column, For column Index, Against column index}
            // Using singleton to read 
            var list = ReadFile.Read().FileReader("football.txt", 1, 6, 8);

            // Get Team with smallest difference of For and Against score
            var smallestDifference = list.Aggregate((i1, i2) => i1.Difference < i2.Difference ? i1 : i2);

            // Print Team name with smallest diff, value of For and value of Against
            // Using singleton to write message
            Logger.GetLogger().WriteMessage("\nTeam name with smallest difference = " + smallestDifference?.Title);
            Logger.GetLogger().WriteMessage("For = " + smallestDifference?.Max);
            Logger.GetLogger().WriteMessage("Against  = " + smallestDifference?.Min);
        }
    }
}
