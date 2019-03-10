using name_sorter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace name_sorter.Test
{
    public class NameModelTest : IClassFixture<NameModelTestFixture>
    {
        /// <summary>
        /// test the Name constructor method with correct name string
        /// </summary>
        [Fact]
        public void CallNameConstructor_StringWithCorrectName_ReturnsNameObject()
        {
            var name = new Name($"{NameModelTestFixture.FIRST_NAME} {NameModelTestFixture.LAST_NAME}");

            Assert.IsType<Name>(name);
            Assert.Equal(NameModelTestFixture.FIRST_NAME, name.GivenNames);
            Assert.Equal(NameModelTestFixture.LAST_NAME, name.Surname);
        }

        /// <summary>
        /// test the Name constructor method with null string
        /// </summary>
        [Fact]
        public void CallNameConstructor_NullString_ThrowsNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(
                () => new Name(null)
            );
        }

        /// <summary>
        /// test the Name constructor method with empty string or white spaces
        /// </summary>
        [Fact]
        public void CallNameConstructor_EmptyOrWhiteSpaceString_ThrowsArgumentOutOfRangeException()
        {
            var argumentOutOfRangeException = Assert.Throws<ArgumentOutOfRangeException>(
                () => new Name("")
            );

            Assert.Equal("startIndex",
                         argumentOutOfRangeException.ParamName);

            argumentOutOfRangeException = Assert.Throws<ArgumentOutOfRangeException>(
                () => new Name("  ")
            );

            Assert.Equal("startIndex",
                         argumentOutOfRangeException.ParamName);
        }

        /// <summary>
        /// test the Name constructor method with name string of one word
        /// </summary>
        [Fact]
        public void CallNameConstructor_OneWordString_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(
                () => new Name("Name")
            );
        }

        /// <summary>
        /// test the Name ToString method
        /// </summary>
        [Fact]
        public void CallToString_ReturnsFullName()
        {
            var name = new Name($"{NameModelTestFixture.FIRST_NAME} {NameModelTestFixture.LAST_NAME}");

            var fullName = name.ToString();
            Assert.Equal($"{NameModelTestFixture.FIRST_NAME} {NameModelTestFixture.LAST_NAME}", fullName);
        }
    }
}
