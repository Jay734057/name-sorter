using name_sorter.Helpers;
using name_sorter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace name_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            List<Name> names = FileHelper.ReadNamesFromPath(path);

            if (names != null)
            {
                //sort the list of names
                names = names.OrderBy(n => n.Surname).ThenBy(n => n.GivenNames).ToList();

                //print the sorted list on the screen
                foreach (Name name in names)
                {
                    Console.WriteLine(name);
                }

                //write to the file
                FileHelper.WriteNamesToPath(names);
            }

            Console.WriteLine("\npress any key to exit the process...");

            Console.ReadKey();
        }
    }
}
