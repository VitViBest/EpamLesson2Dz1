
using EpamLesson1Dz2.Interfaces;

namespace EpamLesson1Dz2.Abstracts
{
    abstract class Person : IPerson
    {
        public string Name { get; private set; }

        public Person(string name)
        {
            Name = name;
        }

        // Person go to home.
        public abstract string Move();

        // Person stoped hear a home.
        public abstract string Stop();

        // Person enter in home.
        public abstract string Enter();

        // Person can crash a home.
        public virtual bool Crashed()
        {
            return false;
        }
    }
}
