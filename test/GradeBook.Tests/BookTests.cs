namespace GradeBook.Tests;

public class BookTests
{
    /*
    [Fact]
    public void Test1()
    {
        /// arrange
        var x = 5;
        var y = 2;
        var expected = 7;

        /// act
        //var actual = x * y;
        var actual = x + y;

        /// assert
        Assert.Equal(expected, actual);
    }
    */
    [Fact]
    public void BookCalculateAnAverageGrade()
    {
        /// arrange
        var book = new InMemoryBook("");
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);

        /// act
        var result = book.GetStatistics();

        /// assert
        Assert.Equal(85.6, result.Average, 1);
        Assert.Equal(90.5, result.High, 1);
        Assert.Equal(77.3, result.Low, 1);
        Assert.Equal('B', result.Letter);
        //third parameter in assert is for precision

    }
}