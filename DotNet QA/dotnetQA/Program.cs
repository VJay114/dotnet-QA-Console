
using System;
using System.Collections.Generic;

namespace DotnetQA
{
    class Program
    {
        static List<Question> QAs = new List<Question>
        {
            new Question
            {
                Text = "What does C# stand for?",
                Choices = new List<Choice>
                {
                    new Choice { Value = "C Sharp", Answer = true },
                    new Choice { Value = "C Slide" },
                    new Choice { Value = "C Snake" },
                    new Choice { Value = "C Square" }
                }
            },
            new Question
            {
                Text = "Who developed the .NET Framework?",
                Choices = new List<Choice>
                {
                    new Choice { Value = "Google" },
                    new Choice { Value = "Microsoft", Answer = true },
                    new Choice { Value = "Apple" },
                    new Choice { Value = "IBM" }
                }
            },
            new Question
            {
                Text = "Which data type holds true/false in C#?",
                Choices = new List<Choice>
                {
                    new Choice { Value = "int" },
                    new Choice { Value = "string" },
                    new Choice { Value = "bool", Answer = true },
                    new Choice { Value = "double" }
                }
            },
            new Question
            {
                Text = "Which keyword is used to define a class in C#?",
                Choices = new List<Choice>
                {
                    new Choice { Value = "def" },
                    new Choice { Value = "function" },
                    new Choice { Value = "class", Answer = true },
                    new Choice { Value = "struct" }
                }
            }
        };

   static void Main(string[] args)
        {
            Console.WriteLine("=== Multiple Choice Quiz ===");

            var random = new Random();
            var shuffledQuestions = QAs.OrderBy(q => random.Next()).ToList();

            int score = 0;
            int total = shuffledQuestions.Count;

            for (int qIndex = 0; qIndex < total; qIndex++)
            {
                var question = shuffledQuestions[qIndex];
                Console.WriteLine($"\nQuestion No. {qIndex + 1}: {question.Text}");

                // Shuffle the choices
                var shuffledChoices = question.Choices.OrderBy(c => random.Next()).ToList();

                // Display the choices
                for (int i = 0; i < shuffledChoices.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {shuffledChoices[i].Value}");
                }

                int answerNumber;
                while (true)
                {
                    Console.Write("Your answer (enter number): ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out answerNumber) &&
                        answerNumber >= 1 && answerNumber <= shuffledChoices.Count)
                    {
                        break; // ✅ valid answer → exit the while loop
                    }

                    Console.WriteLine("⚠ Invalid input. Please enter a valid number between 1 and {0}.", shuffledChoices.Count);
                }

                // Check the answer
                var selectedChoice = shuffledChoices[answerNumber - 1];
                if (selectedChoice.Answer)
                {
                    Console.WriteLine("✅ Correct!");
                    score++;
                }
                else
                {
                    var correctChoice = shuffledChoices.First(c => c.Answer);
                    int correctIndex = shuffledChoices.IndexOf(correctChoice) + 1;
                    Console.WriteLine($"❌ Wrong! Correct answer is: {correctIndex}. {correctChoice.Value}");
                }
            }

            Console.WriteLine($"\nQuiz Finished! You got {score} out of {total}.\n\n\n");
        }
    }


    class Question
    {
        public string Text { get; set; } = "";
        public List<Choice> Choices { get; set; } = new List<Choice>();
    }

    class Choice
    {
        public string Value { get; set; } = "";
        public bool Answer { get; set; } = false;
    }
   
}
