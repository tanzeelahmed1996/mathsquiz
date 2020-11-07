using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsQuiz
{
    class MathsQuizCreator
    {
        Random rnd = new Random();
        int correctAnswer = 0;
        int incorrectAnswer = 0;
        int difficulty;
        int numberOfQuestions;
        double firstVariable;
        double secondVariable;
        char operators;
        string userAns;
        string question;


        public MathsQuizCreator()
        {

        }

        public void Run()
        {

            welcomeMessageGenerator();
            questionCreator();
            exitMessageGenerator();

        }

        private bool checkAns()
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

        private char randomOperator()
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

        private int randomNum()
        {
            return rnd.Next(1, 99);
        }

        private string questionGen()
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

        private void welcomeMessageGenerator()
        {
            Console.WriteLine("Hi, welcome to the most challneging maths quiz ever :)" +
                                "\nPlease enter how many questions you would like to answer: ");

            numberOfQuestions = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Select difficulty (1-3). \n1 for easy (+,-),\n2 for medium (+, -, *, /), \nOr 3 for hard (+, -, *, /, x^).");
            difficulty = Int32.Parse(Console.ReadLine());
        }

        private void exitMessageGenerator()
        {
            Console.WriteLine("End of quiz!\nCorrect: " + correctAnswer + "\nIncorrect: " + incorrectAnswer);
            Console.ReadKey();
        }

        private void questionCreator()
        {
            for (int i = 0; i < numberOfQuestions; i++)
            {
                question = questionGen();

                Console.WriteLine(question);
                userAns = Console.ReadLine();

                countOfCorrectOrIncorrectAnswers();
        
            }
        }

        private void countOfCorrectOrIncorrectAnswers()
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
