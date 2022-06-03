
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private readonly List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }

        public Person GetOldestMember()
        {
            var oldestMember = this.people.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestMember;
        }
    }
}
