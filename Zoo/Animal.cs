using System;
using System.Collections.Generic;

namespace Zoo
{
    class Animal
    {
        public string Name { get; set; }
        public string Hibernate { get; set; }
        public TimeSpan WakesUp { get; set; }
        public TimeSpan FallsAsleep { get; set; }
        public TimeSpan FeedingTime { get; set; }
        public List<Animal> AnimalList()
        {
            List<Animal> AnimalList = new List<Animal>()
            {
                new Animal() { Name = "Björn", Hibernate = "Vinter", WakesUp = new TimeSpan(9, 0, 0), FallsAsleep = new TimeSpan(20, 0, 0), FeedingTime = new TimeSpan(12, 0, 0)},
                new Animal() { Name = "Latmask", Hibernate = "Sommar", WakesUp = new TimeSpan(12, 0, 0), FallsAsleep = new TimeSpan(14, 0, 0), FeedingTime = new TimeSpan(13, 0, 0)},
                new Animal() { Name = "Nattuggla", Hibernate = "-", WakesUp = new TimeSpan(21, 0, 0), FallsAsleep = new TimeSpan(5, 0, 0), FeedingTime = new TimeSpan(21, 0, 0)},
                new Animal() { Name = "Sjölejon", Hibernate = "-", WakesUp = new TimeSpan(6, 0, 0), FallsAsleep = new TimeSpan(18, 0, 0), FeedingTime = new TimeSpan(14, 0, 0)},
                new Animal() { Name = "Säl", Hibernate = "-", WakesUp = new TimeSpan(6, 0, 0), FallsAsleep = new TimeSpan(18, 0, 0), FeedingTime = new TimeSpan(14, 0, 0)},
                new Animal() { Name = "Varg", Hibernate = "-", WakesUp = new TimeSpan(6, 0, 0), FallsAsleep = new TimeSpan(20, 0, 0), FeedingTime = new TimeSpan(12, 0, 0)},
                new Animal() { Name = "Älg", Hibernate = "-", WakesUp = new TimeSpan(7, 0, 0), FallsAsleep = new TimeSpan(19, 0, 0), FeedingTime = new TimeSpan(10, 0, 0)}
            };
            return AnimalList;
        }
    }
}
