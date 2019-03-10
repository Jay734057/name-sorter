using name_sorter.Helpers;
using name_sorter.Models;
using System.Collections.Generic;
using Xunit;

namespace name_sorter.Test
{
    public class FileHelperTest
    {
        /// <summary>
        /// test the ReadNamesFromPath method with correct file path
        /// </summary>
        [Fact]
        public void CallReadNamesFromPath_CorrectFilePath_ReturnsListOfNames()
        {
            var names = FileHelper.ReadNamesFromPath("./unsorted-names-list.txt");

            Assert.IsType<List<Name>>(names);
        }

        /// <summary>
        /// test the ReadNamesFromPath method with fake file path 
        /// </summary>
        [Fact]
        public void CallReadNamesFromPath_FakeFilePath_ReturnsNull()
        {
            var names = FileHelper.ReadNamesFromPath("./unsorted-names-list-fake.txt");

            Assert.Null(names);
        }
    }
}
