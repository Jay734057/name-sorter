using System;

namespace name_sorter.Models
{
    public class Name
    {
        public string Surname { get; set; }
        public string GivenNames { get; set; }

        /// <summary>
        /// covert the full name string into surname and given names
        /// </summary>
        /// <param name="fullName">full name string</param>
        public Name(string fullName)
        {
            try
            {
                //split the full name into surname and given names
                string[] names = fullName.Split(' ');

                Surname = names[names.Length - 1];
                GivenNames = fullName.Remove(fullName.Length - Surname.Length).Trim();

                if (string.IsNullOrEmpty(GivenNames))
                {
                    throw new ArgumentException();
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Can not convert string {fullName} to Name object.");
                throw;
            }

        }

        /// <summary>
        /// return the full name string
        /// </summary>
        /// <returns>the full name string</returns>
        public override string ToString()
        {
            return $"{GivenNames} {Surname}";
        }
    }
}
