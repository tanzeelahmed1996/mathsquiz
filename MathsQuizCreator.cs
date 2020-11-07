using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsQuiz
{
    class MathsQuizCreator
    {
        static Random rnd = new Random();
        static int correctAnswer = 0;
        static int incorrectAnswer = 0;
        static int difficulty;
        static int numberOfQuestions;
        static double firstVariable;
        static double secondVariable;
        static char operators;
        static string userAns;
        static string question;


        public MathsQuizCreator()
        {

        }

        public void Run()
        {

            welcomeMessageGenerator();
            questionCreator();
            exitMessageGenerator();

        }

        public static bool checkAns()
        {

            if (operators == '+')
            {
                double sum = firstVariable + secondVariable;

                if (double.Parse(userAns) == sum)
                {
                    Console.WriteLine("Correct");
                    return true;
                }
            }
            else if (operators == '-')
            {
                double sum = firstVariable - secondVariable;

                if (double.Parse(userAns) == sum)
                {
                    Console.WriteLine("Correct");
                    return true;
                }
            }
            else if (operators == '/')
            {
                double sum = Math.Round(firstVariable / secondVariable, 2);

                if (double.Parse(userAns) == sum)
                {
                    Console.WriteLine("Correct");
                    return true;
                }

            }
            else if (operators =='*')
            {
                double sum = firstVariable * secondVariable;

                if (double.Parse(userAns) == sum)
                {
                    Console.WriteLine("Correct");
                    return true;
                }
            }
            else if (operators == '^')
            {
                double sum = Math.Pow(firstVariable, secondVariable);

                if (double.Parse(userAns) == sum)
                {
                    Console.WriteLine("Correct");
                    return true;
                }
            }
            Console.WriteLine("Incorrect");
            return false;
        }

        public static char randomOperator()
        {
            if (difficulty == 3)
            {
                char[] operators = { '+', '-', '/', '*', '^' };
                return operators[rnd.Next(0, 5)];
            }
            else if (difficulty == 2)
            {
                char[] operators = { '+', '-', '/', '*' };
                return operators[rnd.Next(0, 4)];
            }
            else
            {
                char[] operators = { '+', '-' };
                return operators[rnd.Next(0, 2)];
            }
        }

        public static int randomNum()
        {
            return rnd.Next(1, 99);
        }

        public static string questionGen()
        {
            firstVariable = randomNum();
            secondVariable = randomNum();
            operators = randomOperator();

            string question = firstVariable + " " + operators + " " + secondVariable + " ?";

            if (question.Contains('/'))
            {
                while (firstVariable % secondVariable != 0)
                {
                    firstVariable = randomNum();
                    secondVariable = randomNum();
                }
                question = firstVariable + " " + operators + " " + secondVariable + " ?";
                return question;

            }
            else if (question.Contains('^'))
            {
                while (secondVariable > 3)
                {
                    secondVariable = randomNum();
                }
                question = firstVariable + " " + operators + " " + secondVariable + " ?";
                return question;

            }
            return question;


        }

        public static void welcomeMessageGenerator()
        {
            Console.WriteLine("Hi, welcome to the most challneging maths quiz ever :)" +
                                "\nPlease enter how many questions you would like to answer: ");

            numberOfQuestions = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Select difficulty (1-3). \n1 for easy (+,-),\n2 for medium (+, -, *, /), \nOr 3 for hard (+, -, *, /, x^).");
            difficulty = Int32.Parse(Console.ReadLine());
        }

        public static void exitMessageGenerator()
        {
            Console.WriteLine("End of quiz!\nCorrect: " + correctAnswer + "\nIncorrect: " + incorrectAnswer);
            Console.ReadKey();
        }

        public static void questionCreator()
        {
            for (int i = 0; i < numberOfQuestions; i++)
            {
                question = questionGen();

                Console.WriteLine(question);
                userAns = Console.ReadLine();

                countOfCorrectOrIncorrectAnswers();
        
            }
        }

        public static void countOfCorrectOrIncorrectAnswers()
        {
            if (checkAns())
            {
                correctAnswer++;
            }
            else
            {
                incorrectAnswer++;
            }

        }

    }
}
