namespace GradeBook
{
    public delegate void GradeAddedDelegate(Object sender, EventArgs args);  //object to take any parameter of any data type
    /// Base Class
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;

    }
    public abstract class Book : NamedObject, IBook // class cany implement many interface but not many classes as multiple inheritance isn't allowed
    {
        public Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }

    /// Derived class
    public class InMemoryBook : Book
    {

        List<double> grades;

        //readonly string category = "Science";
        public const string CATEGORY = "Science";

        public InMemoryBook(string name) : base(name)
        {
            grades = new();
            //Name = name;
        }


        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded; // event keyword is used to add some restrictions and gives capabilities to this GradeAddedDelegate

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            //var result = 0.0;
            //var highestGrade = double.MinValue;
            //var lowestGrade = double.MaxValue;
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            /// foreach (var grade in grades)
            //var index = 0;
            /// do  // if the list is empty this will fail because it runs at least one time trying index empty list
            //while (index < grades.Count)
            for (var index = 0; index < grades.Count; index++)
            {
                // if (number > highGrade)
                // {
                //     highGrade = number;
                // }
                /*if (grades[index] == 42.1)
                {
                    /// break; // exit the loop 
                    /// continue; // continue by skipping the lines below
                    /// goto done;
                }*/
                /*Static method*/
                result.High = Math.Max(grades[index], result.High);
                result.Low = Math.Min(grades[index], result.Low);
                result.Average += grades[index];
                //index++;
            }//while (index < grades.Count);

            result.Average /= grades.Count;

            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }

            /// done:
            return result;
        }
    }
}