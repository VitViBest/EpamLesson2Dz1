using EpamLesson1Dz2.Abstracts;
using System;

namespace EpamLesson1Dz2.Models
{
    class Bear : Person
    {
        private int _Mass;

        private int _Height;

        private Random _Random;

        public Bear(string name, int mass, int height) : base("Медведь-" + name)
        {
            _Mass = mass;
            _Height = height;
            _Random = new Random();
        }

        public override bool Crashed()
        {
            return _Random.Next(_Mass * _Height) > _Mass * _Height / 2;
        }

        public override string Enter()
        {
            string[] actions = { "Залез", "Вошел", "Забрался" };
            return actions[_Random.Next(actions.Length)];
        }

        public override string Move()
        {
            string[] actions = { "Пробирается", "Идет" };
            return actions[_Random.Next(actions.Length)];
        }

        public override string Stop()
        {
            string[] actions = { "Посмотрел", "Подошел" };
            return actions[_Random.Next(actions.Length)];
        }
    }
}
