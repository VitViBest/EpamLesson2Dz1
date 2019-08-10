using EpamLesson1Dz2.Abstracts;
using System;

namespace EpamLesson1Dz2.Models
{

    class Wolf : Person
    {
        public static string Text { get; set; }

        public string GetText()
        {
            return Text;
        }

        private int _Mass;

        private Random _Random;

        public Wolf(string name, int mass) : base("Волчок-" + name)
        {
            _Mass = mass;
            _Random = new Random();
        }

        public override bool Crashed()
        {
            return _Mass / 2 * 3 < (_Random.Next(_Mass));
        }

        public override string Enter()
        {
            string[] actions = { "Вошел", "Залез" };
            return actions[_Random.Next(actions.Length)];
        }

        public override string Move()
        {
            string[] actions = { "Бежал", "Проходил" };
            return actions[_Random.Next(actions.Length)];
        }

        public override string Stop()
        {
            string[] actions = { "Подошел", "Остановился" };
            return actions[_Random.Next(actions.Length)];
        }
    }
}
