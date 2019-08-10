using EpamLesson1Dz2.Abstracts;
using System;

namespace EpamLesson1Dz2.Models
{
    class Mouse : Person
    {
        private Random _Random;

        public Mouse(string name) : base("Мышка-" + name)
        {
            _Random = new Random();
        }

        public override bool Crashed()
        {
            return _Random.Next(10) == 1;
        }

        public override string Enter()
        {
            string[] actions = { "Запрыгнула", "Забежала" };
            return actions[_Random.Next(actions.Length)];
        }

        public override string Move()
        {
            string[] actions = { "Бежала", "Шла мимо", "Проходила", "Идет", "Бежит" };
            return actions[_Random.Next(actions.Length)];
        }

        public override string Stop()
        {
            string[] actions = { "Остановилась", "Посмотрела", "Подумала" };
            return actions[_Random.Next(actions.Length)];
        }
    }
}
