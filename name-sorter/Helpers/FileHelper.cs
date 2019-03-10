using name_sorter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace name_sorter.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// Read the list of name from path and convert to a list of name objects
        /// </summary>
        /// <param name="path">the file path</param>
        /// <returns>a list of name objects</returns>
        public static List<Name> ReadNamesFromPath(string path = "./unsorted-names-list.txt")
        {
            try
            {
                // Open the text file using a stream reader.
                using (StreamReader streamReader = new StreamReader(path))
                {
                    // Read the entire file.
                    string file = streamReader.ReadToEnd();

                    //split by lines
                    List<string> lines = file.Split('\n').ToList();

                    //remove empty lines
                    lines.RemoveAll(l => string.IsNullOrWhiteSpace(l));

                    //convert lines to names line by line
                    List<Name> names = lines.Select(l => new Name(l)).ToList();

                    return names;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);

                return null;
            }
        }

        /// <summary>
        /// write the sorted list of names to file
        /// </summary>
        /// <param name="names">the sorted list of names</param>
        /// <param name="path">file path</param>
        /// <param name="fileName">file name</param>
        public static void WriteNamesToPath(List<Name> names, string path = "./", string fileName = "sorted-names-list.txt")
        {
            try
            {
                // stream writer to generate the output file.
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, fileName)))
                {
                    foreach (Name name in names)
                    {
                        outputFile.WriteLine(name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("The sorted name list could not be written to file:");
                Console.WriteLine(ex.Message);
            }

        }
    }
}
