namespace GradeBook
{
    public delegate void GradeAddedDelegate(Object sender, EventArgs args);  //object to take any parameter of any data type
    public class Book
    {

        List<double> grades;
        public string Name { get; set; }
        //readonly string category = "Science";
        public const string CATEGORY = "Science";

        public Book(string name)
        {
            grades = new();
            Name = name;
        }


        public void AddGrade(double grade)
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

        public event GradeAddedDelegate GradeAdded; // event keyword is used to add some restrictions and gives capabilities to this GradeAddedDelegate

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
        public Statistics GetStatistics()
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