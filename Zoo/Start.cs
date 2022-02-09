using System;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    enum SummerMonths
    {
        JUNI = 6,
        JULI = 7,
        AUGUSTI = 8,
    }
    enum WinterMonths
    {
        JANUARI = 1,
        FEBRUARI = 2,
        DECEMBER = 12
    }
    class Start
    {
        public void StartProgram()
        {
            Visitor visitor = new Visitor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            visitor.VisitingDate = ReturnVisitorVisitingMonth();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Zooet är öppet mellan 06-23.");

            visitor.ArriveTime = ReturnVisitorArriveTimeInZoo();
            visitor.LeaveTime = ReturnVisitorLeaveTime();

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Under ditt besök kan du se:");
            Console.ResetColor();
            DisplayAllAwakeAnimals(visitor);
        }
        private DateTime ReturnVisitorVisitingMonth()
        {
            Console.WriteLine("Vilket datum vill du besöka Neptunus Zoo? (datum-månad)");
            Console.ResetColor();
            string dateInput = Console.ReadLine();
            DateTime date = DateTime.Parse(dateInput);
            return date;
        }
        private TimeSpan ReturnVisitorArriveTimeInZoo()
        {
            Console.WriteLine("Vilken tid kommer du till Zoo:et? (Format: hh:mm)");
            Console.ResetColor();
            string timeInput = Console.ReadLine();
            TimeSpan arriveTime = TimeSpan.Parse(timeInput);
            return arriveTime;
        }
        private TimeSpan ReturnVisitorLeaveTime()
        {
            Console.WriteLine("Vilken tid lämnar du Zoo:et? (Format: hh:mm)");
            string timeInput = Console.ReadLine();
            TimeSpan leaveTime = TimeSpan.Parse(timeInput);
            return leaveTime;
        }
        private void DisplayAllAwakeAnimals(Visitor visitor)
        {
            Animal _animal = new Animal();
            var animalList = _animal.AnimalList();
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var animal in animalList)
            {
                if (IsAnimalAwake(visitor, animal) && IsFeedingTime(visitor, animal) && !IsHibernated(visitor, animal))
                {
                    Console.WriteLine($"{animal.Name}  *** matas kl {animal.FeedingTime.Hours} ***");
                }
                else if (IsAnimalAwake(visitor, animal) && !IsFeedingTime(visitor, animal) && !IsHibernated(visitor, animal))
                {
                    Console.WriteLine(animal.Name);
                }
            }
            Console.ResetColor();
        }
        private bool IsAnimalAwake(Visitor visitor, Animal animal)
        {
            if (animal.FallsAsleep.Hours < 10)
            {
                if ((visitor.ArriveTime >= animal.WakesUp || visitor.LeaveTime > animal.WakesUp) && (visitor.ArriveTime > animal.FallsAsleep || visitor.LeaveTime > animal.FallsAsleep))
                {
                    return true;
                }
            }

            if ((visitor.ArriveTime >= animal.WakesUp || visitor.LeaveTime > animal.WakesUp) && (visitor.ArriveTime < animal.FallsAsleep || visitor.LeaveTime < animal.FallsAsleep))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsFeedingTime(Visitor visitor, Animal animal)
        {
            if (visitor.ArriveTime < animal.FeedingTime && visitor.LeaveTime > animal.FeedingTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool IsHibernated(Visitor visitor, Animal animal)
        {
            if (Enum.GetName(typeof(SummerMonths), visitor.VisitingDate.Month) != null &&  animal.Hibernate == "Sommar")
            {
                return true;
            }
            else if (Enum.GetName(typeof(WinterMonths), visitor.VisitingDate.Month) != null && animal.Hibernate == "Vinter")
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

//TODO: Ändra logiken för "DisplayAllAwakeAnimal" metoden