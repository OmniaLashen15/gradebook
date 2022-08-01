namespace GradeBook.Tests;


public delegate string writeLogDelegate(string logMessage);
public class TypeTests
{
    int count = 0;
    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        writeLogDelegate log = ReturnMessage;
        log += ReturnMessage; //two lines are for invoking different methods but having same signature as this delegate
        log += IncrementCount;
        //log = new writeLogDelegate(ReturnMessage);
        //log = ReturnMessage;  // make the delegate pointing to this method
        var result = log("Hello!");
        //Assert.Equal("Hello!", result);
        Assert.Equal(3, count);

    }
    string IncrementCount(string message)
    {
        count++;
        return message.ToLower();
    }
    string ReturnMessage(string message)
    {
        count++;
        return message;
    }

    [Fact]
    public void StringBehavesLikeValueTypes()
    {
        string name = "Omnia";
        var upper = MakeUpperCase(name);

        Assert.Equal("Omnia", name);
        Assert.Equal("OMNIA", upper);


    }

    private string MakeUpperCase(string parameter)
    {
        return parameter.ToUpper();
    }

    [Fact]
    public void ValueTypePassByReference()
    {
        var x = GetInt();
        SetInt(ref x);

        //Assert.Equal(3, x); ===> failed
        Assert.Equal(42, x);
    }

    private void SetInt(ref int x)
    {
        x = 42;
    }
    [Fact]
    public void ValueTypePassByValue()
    {
        var x = GetInt();
        SetInt(x);

        Assert.Equal(3, x);
    }

    private void SetInt(int x)
    {
        x = 42;
    }

    private int GetInt()
    {
        return 3;
    }

    [Fact]
    public void CanSetNameFromReference()
    {
        // book1 ===> "New Name"
        // book ===> "New Name"
        // both of them have the same reference but different object
        /// arrange
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name");       ///Passing by value copying the value from book1 and placing it into this parameter book , book1 and book have same reference 

        Assert.Equal("New Name", book1.Name);

    }
    private void SetName(Book book, string name)
    {
        book.Name = name;
    }

    [Fact]
    public void CSharpPassByValue()
    {                                    // book1 ===> "Book 1"
                                         // book ===> "New Name"
                                         // both of them have the different reference and different objects

        /// arrange
        var book1 = GetBook("Book 1");
        GetBookSetName(book1, "New Name");       ///Passing by value copying the value from book1 and placing it into this parameter book , book1 and book have same reference 

        Assert.Equal("Book 1", book1.Name);
        //Assert.Equal("New Name", book1.Name);


    }
    private void GetBookSetName(Book book, string name)
    {
        book = new Book(name);
        book.Name = name;
    }
    [Fact]
    public void CSharpPassByReference()
    {    // book ===> book1 ===> "New Name"
         // book1 is pointing to different object and this object does have the name "New Name"

        /// arrange
        var book1 = GetBook("Book 1");
        GetBookSetName(out book1, "New Name");       ///Passing by reference copying the value from book1 and placing it into this parameter book , book1 and book have same reference 

        Assert.Equal("New Name", book1.Name);

    }
    private void GetBookSetName(out Book book, string name)
    {
        book = new Book(name);
        book.Name = name;
    }

    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        /// arrange
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
        Assert.NotEqual(book1, book2);
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
        /// arrange
        var book1 = GetBook("Book 1");
        var book2 = book1;

        Assert.Same(book1, book2); // to check that book1 and book2 references to the same instance
        Assert.True(Object.ReferenceEquals(book1, book2)); // is the same as Assert.Same
    }
    Book GetBook(string name)
    {
        return new Book(name);
    }
}