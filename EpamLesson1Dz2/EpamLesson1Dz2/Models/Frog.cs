using EpamLesson1Dz2.Abstracts;
using System;

namespace EpamLesson1Dz2.Models
{
    class Frog : Person
    {
        private Random _Random;

        public Frog(string name) : base("Лягушка-" + name)
        {
            _Random = new Random();
        }

        public override bool Crashed()
        {
            return _Random.Next(8) == 0;
        }

        public override string Enter()
        {
            string[] actions = { "Прыгнула", "Вошла", "Забралась" };
            return actions[_Random.Next(actions.Length)];
        }

        public override string Move()
        {
            string[] actions = { "Прискакала", "Проходила", "Скачет", "Бежит" };
            return actions[_Random.Next(actions.Length)];
        }

        public override string Stop()
        {
            string[] actions = { "Подпрыгнула", "Посмотрела" };
            return actions[_Random.Next(actions.Length)];
        }
    }
}
