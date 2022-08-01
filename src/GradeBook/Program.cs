using System;
using System.Collections.Generic;

namespace GradeBook
{


    class Program
    {
        static void Main(string[] args)
        {
            #region Class
            var book = new Book("Omnia's Grade Book");
            book.GradeAdded += OnGradeAdded;

            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    book.AddGrade('A');
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }

            }

            var stats = book.GetStatistics();

            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

            #endregion

            #region declaring variables
            // var x = 34.1;
            // var y = 10.3;
            // var result = x + y;
            // Console.WriteLine(result);
            #endregion

            #region  arrays
            //double[] numbers = new double[3];
            /*var numbers = new double[3];
            numbers[0] = 12.7;
            numbers[1] = 10.3;
            numbers[2] = 6.11;
            var result = numbers[0];
            result = result + numbers[1];
            result = result + numbers[2];*/

            #region array initialization syntax and looping
            /*
            var result = 0.0;
            var numbers = new[] { 12.7, 10.3, 6.11, 4.1 };
            foreach (double number in numbers)
            {
                result += number;
            }
            */
            #endregion
            //Console.WriteLine(result);

            #endregion

            #region Lists
            //var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 };
            //grades.Add(56.1);

            #endregion

            #region  if/else statements
            if (args.Length > 0)
            {  // string interpolation
                Console.WriteLine($"Hello, {args[0]}!");
            }

            else
            {
                Console.WriteLine("Hello!");
            }
            #endregion
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }

}


//dotnet run --project src\GradeBook\GradeBook.csproj