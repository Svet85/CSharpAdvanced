using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name => this.name;
        public int Age => this.age;

        public int CompareTo(Person other)
        {
            int result = this.name.CompareTo(other.name);
            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
            }

            return result;
        }

        public override bool Equals(object? obj)
        {
            var other = obj as Person;
            if (other == null)
            {
                return false;
            }

            return this.Age == other.Age && this.Name == other.Name;
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() ^ this.age.GetHashCode();
        }


        //public override bool Equals(object obj)
        //{
        //    if (obj == null || obj.GetType() != this.GetType())
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        var person = obj as Person;
        //        return Equals(person);
        //    }
        //}

        //public bool Equals(Person other)
        //{
        //    if (other == null)
        //        return false;

        //    return this.name == other.name && this.age == other.age;
        //}

        //public override int GetHashCode()
        //{
        //    return this.name.GetHashCode() ^ this.age.GetHashCode();
        //}
    }
}
