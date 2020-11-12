using System;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    class Start
    {
        public void StartProgram()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string month = ReturnUsersVisitingMonth();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Zooet är öppet mellan 06-23.");

            var activeHours = ReturnUsersTimeInZoo();
            const int arriveTime = 0, leaveTime = 1;
            int userArrives = int.Parse(activeHours[arriveTime]);
            int userLeaves = int.Parse(activeHours[leaveTime]);

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Under ditt besök kan du se:");
            Console.ResetColor();
            DisplayAllAwakeAnimals(userArrives, userLeaves, month);
        }
        private string ReturnUsersVisitingMonth()
        {
            Console.WriteLine("Vilket datum vill du besöka Neptunus Zoo?");
            Console.ResetColor();
            string dateInput = Console.ReadLine();
            DateTime date = DateTime.Parse(dateInput);
            string month = date.ToString("MMMM");
            return month;
        }
        private string[] ReturnUsersTimeInZoo()
        {
            Console.WriteLine("Vilken tid vill du komma?");
            Console.ResetColor();
            string timeInput = Console.ReadLine();
            string[] hours = timeInput.Split('-');
            return hours;
        }
        private void DisplayAllAwakeAnimals(int userArrives, int userLeaves, string month)
        {
            Animal _animal = new Animal();
            var animalList = _animal.AnimalList();
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var animal in animalList)
            {
                if (IsAnimalAwake(userArrives, userLeaves, animal) && IsFeedingTime(userArrives, userLeaves, animal) && !IsHibernated(month, animal))
                {
                    Console.WriteLine($"{animal.Name}  *** matas kl {animal.FeedingTime.Hours} ***");
                }
                else if (IsAnimalAwake(userArrives, userLeaves, animal) && !IsFeedingTime(userArrives, userLeaves, animal) && !IsHibernated(month, animal))
                {
                    Console.WriteLine(animal.Name);
                }
            }
            Console.ResetColor();
        }
        private bool IsAnimalAwake(int userArrives, int userLeaves, Animal animal)
        {
            if (animal.FallsAsleep.Hours < 10)
            {
                if ((userArrives >= animal.WakesUp.Hours || userLeaves > animal.WakesUp.Hours) && (userArrives > animal.FallsAsleep.Hours || userLeaves > animal.FallsAsleep.Hours))
                {
                    return true;
                }
            }

            if ((userArrives >= animal.WakesUp.Hours || userLeaves > animal.WakesUp.Hours) && (userArrives < animal.FallsAsleep.Hours || userLeaves < animal.FallsAsleep.Hours))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsFeedingTime(int userArrives, int userLeaves, Animal animal)
        {
            if (userArrives < animal.FeedingTime.Hours && userLeaves > animal.FeedingTime.Hours)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsHibernated(string month, Animal animal)
        {
            string[] summerMonths = { "JUNI", "JULI", "AUGUSTI" };
            string[] winterMonths = { "DECEMBER", "JANUARI", "FEBRUARI" };

            if (summerMonths.Contains(month.ToUpper()) && animal.Hibernate == "Sommar")
            {
                return true;
            }
            else if (winterMonths.Contains(month.ToUpper()) && animal.Hibernate == "Vinter")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
