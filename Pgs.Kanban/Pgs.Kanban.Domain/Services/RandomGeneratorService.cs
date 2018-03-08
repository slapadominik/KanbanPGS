using System;
using System.Collections.Generic;
using System.Text;

namespace Pgs.Kanban.Domain.Services
{
    public class RandomGeneratorService
    {
        private Random randomGenerator = new Random();
        private static List<int> magicNumbers = new List<int>();

        public int GenerateRandomNumber()
        {
            var number = randomGenerator.Next();
            return number;
        }

        public int GenerateRandomNumber(int maxValue)
        {
            var number = randomGenerator.Next(maxValue);
            return number;
        }

        public void AddNumberToList(int number)
        {
            magicNumbers.Add(number);
        }

        public void DeleteNumber(int number)
        {
            magicNumbers.Remove(number);
        }

        public List<int> GetAllNumbers()
        {
            return magicNumbers;
        }
    }
}
