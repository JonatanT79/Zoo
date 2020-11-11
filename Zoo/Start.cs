using System;
using System.Linq;

namespace Zoo
{
    class Start
    {
        public void StartProgram()
        {
            Animal _animal = new Animal();
            const int arriveTime = 0, leaveTime = 1;

            Console.WriteLine("Vilket datum vill du besöka Neptunus Zoo?");
            string dateInput = Console.ReadLine();
            DateTime date = DateTime.Parse(dateInput);
            string month = date.ToString("MMMM");
            Console.WriteLine("Zooet är öppet mellan 06-23.");

            Console.WriteLine("Vilken tid vill du komma?");
            string timeInput = Console.ReadLine();
            var hours = timeInput.Split('-');
            int arrive = int.Parse(hours[arriveTime]);
            int leaves = int.Parse(hours[leaveTime]);
            Console.WriteLine("");

            Console.WriteLine("Under ditt besök kan du se:");
            var animalList = _animal.AnimalList();

            foreach (var animal in animalList)
            {
                if (AnimalIsAwake(arrive, leaves, animal) && IsFeedingTime(arrive, leaves, animal) && !IsHibernated(month, animal))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(animal.Name + "  *** matas kl " + animal.FeedingTime + " ***");
                    Console.ResetColor();
                }
                else if (AnimalIsAwake(arrive, leaves, animal) && !IsFeedingTime(arrive, leaves, animal) && !IsHibernated(month, animal))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(animal.Name);
                    Console.ResetColor();
                }
            }
        }
        public bool AnimalIsAwake(int arrive, int leaves, Animal animal)
        {
            if (animal.FallsAsleep.Hours < 10)
            {
                if ((arrive >= animal.WakesUp.Hours || leaves > animal.WakesUp.Hours) && (arrive > animal.FallsAsleep.Hours || leaves > animal.FallsAsleep.Hours))
                {
                    return true;
                }
            }
            if ((arrive >= animal.WakesUp.Hours || leaves > animal.WakesUp.Hours) && (arrive < animal.FallsAsleep.Hours || leaves < animal.FallsAsleep.Hours))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsFeedingTime(int arrive, int leaves, Animal animal)
        {
            if (arrive < animal.FeedingTime.Hours && leaves > animal.FeedingTime.Hours)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsHibernated(string month, Animal animal)
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
