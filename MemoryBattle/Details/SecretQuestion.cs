using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryBattle.Details
{
    public class SecretQuestion
    {
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }

        public SecretQuestion(string question, string correctAnswer)
        {
            Question = question;
            CorrectAnswer = correctAnswer;
        }

        public bool IsCorrect(string answer)
        {
            return string.Equals(answer?.Trim(), CorrectAnswer?.Trim(), StringComparison.OrdinalIgnoreCase);
        }
    }

    public static class QuestionBank
    {
        private static readonly Random _random = new Random();
        private static readonly List<SecretQuestion> _allQuestions = new List<SecretQuestion>
        {
            new SecretQuestion("What is the capital of France?", "Paris"),
            new SecretQuestion("What is 7 x 8?", "56"),
            new SecretQuestion("What planet is known as the Red Planet?", "Mars"),
            new SecretQuestion("What is the largest ocean on Earth?", "Pacific"),
            new SecretQuestion("How many continents are there?", "7"),
            new SecretQuestion("What is the chemical symbol for gold?", "Au"),
            new SecretQuestion("What is the smallest prime number?", "2"),
            new SecretQuestion("What year did World War II end?", "1945"),
            new SecretQuestion("What is the fastest land animal?", "Cheetah"),
            new SecretQuestion("What is the square root of 144?", "12"),
            new SecretQuestion("Who painted the Mona Lisa?", "Leonardo da Vinci"),
            new SecretQuestion("What is the largest mammal?", "Blue Whale"),
            new SecretQuestion("How many legs does a spider have?", "8"),
            new SecretQuestion("What is the boiling point of water in Celsius?", "100"),
            new SecretQuestion("What gas do plants absorb from the atmosphere?", "Carbon Dioxide")
        };

        public static List<SecretQuestion> GetRandomQuestions(int count)
        {
            if (count > _allQuestions.Count)
                count = _allQuestions.Count;

            var shuffled = _allQuestions.OrderBy(x => _random.Next()).ToList();
            return shuffled.Take(count).ToList();
        }

        public static SecretQuestion GetRandomQuestion()
        {
            int index = _random.Next(_allQuestions.Count);
            return _allQuestions[index];
        }
    }
}