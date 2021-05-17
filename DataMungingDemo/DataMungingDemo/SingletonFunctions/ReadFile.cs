using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace DataMungingDemo.SingletonFunctions
{
    // using Single-responsibility principle
    #region ReadFile
    public sealed class ReadFile
    {
        private static readonly ReadFile _readFile = new ReadFile();

        /// <summary>
        /// Constructor
        /// </summary>
        private ReadFile()
        {
        }

        /// <summary>
        /// Setup the singleton
        /// </summary>
        /// <returns></returns>
        public static ReadFile Read()
        {
            return _readFile;
        }

        /// <summary>
        /// Function to read a text file on specific location
        /// </summary>
        /// <param name="fileName">name of file to be read</param>
        /// <param name="titleIndex">Main title column to be read like team name, Dy etc.</param>
        /// <param name="firstColumnIndex">first column to be read</param>
        /// <param name="secondColumnIndex">second column to be read</param>
        /// <returns>List of data read from a specific file</returns>
        public List<Models.Model> FileReader(string fileName, int titleIndex, int firstColumnIndex, int secondColumnIndex)
        {
            try
            {
                // Read file {Note: need to create folder in C directory and than keep weather.txt and football.txt file in C:/Files}
                var lines = File.ReadAllLines(ConfigurationSettings.AppSettings["BasePath"] + fileName);
                var list = new List<Models.Model>();

                // Iterate all lines
                for (var i = 1; i < lines.Length; i++)
                {
                    // if line has no content or containing on --------- then we will skip that line
                    if (lines[i].Length == 0 || lines[i].Contains("-----")) continue;

                    // Get value of specific index on current line
                    var obj = new Models.Model
                    {
                        Title = lines[i].Split(' ')?.Where(x => x != "")?.ToArray()[titleIndex],
                        Max = decimal.Parse(lines[i].Split(' ')?.Where(x => x != "")?.ToArray()[firstColumnIndex]
                            ?.Replace("*", "")),
                        Min = decimal.Parse(lines[i].Split(' ')?.Where(x => x != "")?.ToArray()[secondColumnIndex]
                            ?.Replace("*", ""))
                    };

                    // calculate difference two specific column for example difference between For and Against
                    if (obj.Max < obj.Min)
                        obj.Difference = obj.Min - obj.Max;
                    else
                        obj.Difference = obj.Max - obj.Min;

                    // add object in list
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                Logger.GetLogger().WriteMessage("Exception  = " + ex);
                throw;
            }
        }
    }
    #endregion
}
