using EpamLesson1Dz2.Abstracts;
using System;

namespace EpamLesson1Dz2.Models
{
    class Fox : Person
    {

        private int _Mass;

        private Random _Random;

        public Fox(string name, int mass) : base("Лисичка-" + name)
        {
            _Mass = mass;
            _Random = new Random();
        }

        public override bool Crashed()
        {
            return _Mass * (_Random.Next(_Mass)) < _Mass / 3;
        }

        public override string Enter()
        {
            string[] actions = { "Вошла", "Забралась" };
            return actions[_Random.Next(actions.Length)];
        }

        public override string Move()
        {
            string[] actions = { "Пришла", "Бежит" };
            return actions[_Random.Next(actions.Length)];
        }

        public override string Stop()
        {
            string[] actions = { "Остановилась", "Посмотрела" };
            return actions[_Random.Next(actions.Length)];
        }
    }
}
