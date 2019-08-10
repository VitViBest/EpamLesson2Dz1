using EpamLesson1Dz2.Interfaces;
using System.Collections.Generic;

namespace EpamLesson1Dz2.Abstracts
{
    abstract class ReaderAbstract : IReader
    {
        // Contains everyone person in story.
        public List<Person> People { get; protected set; }

        public abstract void StartReading(IWriter writer);

        protected virtual void _GetExeption()
        {
            throw new PersonExeption("Напали пришельцы.","Все были уничтожены.");
        }
    }
}
