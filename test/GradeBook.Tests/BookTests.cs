using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void GradeNotAddedIfGreaterThanOneHundred()
        {
            var book = new InMemoryBook("");
            book.AddGrade(101);

            var result = book.GetStatistics();

            Assert.Equal(Double.NaN, result.Average);
        }

        [Fact]
        public void GradeNotAddedIfLessThanZero()
        {
            var book = new InMemoryBook("");
            book.AddGrade(-1);

            var result = book.GetStatistics();

            Assert.Equal(Double.NaN, result.Average);
        }

        [Fact]
        public void BookCalculatesStatistics()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);

        }
    }
}
