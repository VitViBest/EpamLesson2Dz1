using EpamLesson1Dz2.Abstracts;
using System;

namespace EpamLesson1Dz2.Models
{
    class Rabbit : Person
    {
        private Random _Random;

        public Rabbit(string name) : base("Зайчик-" + name)
        {
            _Random = new Random();
        }

        public override bool Crashed()
        {
            return _Random.Next(6) == 0;
        }

        public override string Enter()
        {
            string[] actions = { "Прыгнул", "Вошел", "Забежал" };
            return actions[_Random.Next(actions.Length)];
        }

        public override string Move()
        {
            string[] actions = { "Бежал", "Идет" };
            return actions[_Random.Next(actions.Length)];
        }

        public override string Stop()
        {
            string[] actions = { "Подошел", "Останавливается" };
            return actions[_Random.Next(actions.Length)];
        }
    }
}
