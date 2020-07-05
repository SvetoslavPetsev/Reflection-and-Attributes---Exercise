﻿namespace ValidationAttributes.Models
{
    using ValidationAttributes.Attributes;

    public class Person
    {
        private const int MIN_AGE = 12;
        private const int MAX_AGE = 90;
        public Person(string fullNme, int age)
        {
            this.FullName = fullNme;
            this.Age = age;
        }
        [MyRequired]
        public string FullName { get; set; }

        [MyRange(MIN_AGE, MAX_AGE)]
        public int Age { get; set; }
    }
}
