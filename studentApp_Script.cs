using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Drawing;

namespace StudentApp
{
    internal class Student
    {
        //Data members, data fields, or characteristics 
        private string studentNumber;
        private string studentLastName;
        private string studentFirstName;
        private int score1;
        private int score2;
        private int score3;
        private string major;

        //List<Student> listStudents = new List<Student>();

        //Default constructor
        public Student()
        {

        }

        //Constructor with one argument
        public Student(string sID)
        {
            studentNumber = sID;
        }

        //Constructor with three arguments
        public Student(string sID, string lastName, string firstName)
        {
            studentNumber = sID;
            studentLastName = lastName;
            studentFirstName = firstName;
        }

        //Constructor with six arguments
        public Student(string sID, string lastName, string firstName,
                                           int s1, int s2, int s3, string maj)
        {
            studentNumber = sID;
            studentLastName = lastName;
            studentFirstName = firstName;
            score1 = s1;
            score2 = s2;
            score3 = s3;
            major = maj;
        }

        //Properties
        public string StudentLastName
        {
            get
            {
                return studentLastName;
            }
            set
            {
                studentLastName = value;
            }
        }

        public string StudentFirstName
        {
            get
            {
                return studentFirstName;
            }
            set
            {
                studentFirstName = value;
            }
        }

        public string StudentNumber
        {
            get
            {
                return studentNumber;
            }
            set
            {
                studentNumber = value;
            }
        }

        public string Major
        {
            get
            {
                return major;
            }
            set
            {
                major = value;
            }
        }

        public int Score1
        {
            get
            {
                return score1;
            }
            set
            {
                score1 = value;
            }
        }

        public int Score2
        {
            get
            {
                return score2;
            }
            set
            {
                score2 = value;
            }
        }

        public int Score3
        {
            get
            {
                return score3;
            }
            set
            {
                score3 = value;
            }
        }



        static void Main(string[] args)
        {
            bool yesOrNo;

            do //The app ask to continue adding student details before exiting.
            {
                WriteLine("The app lets user to put student details and display them" +
               "\nIt verifies if the score entered is number or not. " +
               "\nAnd keeps notifing until Score is number");
                WriteLine();

                Student firstStudentObject = new Student();
                firstStudentObject.StudentFirstName = AskForStudentName("First");
                firstStudentObject.StudentLastName = AskForStudentName("Last");
                firstStudentObject.StudentNumber = AskForStudentNumber();
                firstStudentObject.Major = AskForMajor(firstStudentObject.StudentFirstName);
                firstStudentObject.Score1 = AskForExamScore(1);
                firstStudentObject.Score2 = AskForExamScore(2);
                firstStudentObject.Score3 = AskForExamScore(3);

                Clear();
                WriteLine("Student Details");
                WriteLine("----------------");
                WriteLine(firstStudentObject.ToString());

                WriteLine("Do you want to add an other student? Y/N");
                string inputValue = ReadLine();
                inputValue.ToUpper();

                if (inputValue.ToUpper() == "Y")
                {
                    yesOrNo = true;
                    Clear();
                }
                else
                {
                    yesOrNo = false;
                    ReadKey();

                }


            } while (yesOrNo);
        }

        public double CalculateAverage()
        {
            return (score1 + score2 + score3) / 3.0;
        }

        public override string ToString()
        {
            return "Name: " +
                studentFirstName + " " + studentLastName +
                "\nMajor: " + major +
                "\nScore Average: " +
                CalculateAverage().ToString("F2");
        }


        static int AskForExamScore(int whichOne)
        {
            string inputValue;  // local variables
            int aScore = 0;        // method
            bool inValue = true;
            bool errorValue = true;

            while (inValue) //stay running until input is Number
            {
                try //Catch exception if score is not numbers
                {
                    if (errorValue == false)
                    {
                        Write("\nEnter again the Score {0}: ", whichOne);
                    }
                    else
                    {
                        Write("Enter the Score {0}: ", whichOne);
                    }

                    inputValue = ReadLine();

                    //Checking if input is Number or not
                    //int i is not used
                    int i = 0;
                    bool result = int.TryParse(inputValue, out i);

                    //changing the state of varible
                    //they are used in While Loop
                    if (result == true)
                    {
                        inValue = false;
                        errorValue = true;
                    }
                    else
                    {
                        inValue = true;
                        errorValue = false;
                    }

                    aScore = int.Parse(inputValue);
                }
                catch (Exception e)
                {
                    aScore = 0; //initialize "Score" to 0 until it got the number value
                    errorValue = false;
                    WriteLine("\nUse only numbers to enter the Score {0}: ", whichOne);

                }
            }

            return aScore;
        }

        static string AskForStudentName(string whichOne)
        {
            string inValue;
            Write("Enter Student {0} Name: ", whichOne);
            inValue = ReadLine();
            return inValue;
        }
        static string AskForMajor(string name)
        {
            string inValue;
            Write("Enter {0}\'s Major: ", name);
            inValue = ReadLine();
            return inValue;
        }
        static string AskForStudentNumber()
        {
            string inValue;
            Write("Enter Student Number: ");
            inValue = ReadLine();
            return inValue;
        }


    }
}
