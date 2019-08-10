using EpamLesson1Dz2.Abstracts;
using EpamLesson1Dz2.Interfaces;
using EpamLesson1Dz2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EpamLesson1Dz2
{
    /// <summary>
    /// Class read story.
    /// </summary>
    class Reader:ReaderAbstract
    {
        public static int GoodEnd { get; private set; }

        public static int BadEnd { get; private set; }

        public static int Count => BadEnd + GoodEnd;

        static Reader()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Ends.txt"))
                {
                    GoodEnd = int.Parse(sr.ReadLine());
                    BadEnd = int.Parse(sr.ReadLine());
                }
            }
            catch
            {
                GoodEnd = 0;
                BadEnd = 0;
            }
        }
        
        // Person will be selected randomly or consistently.
        public bool _Random { get; set; } = false;

        // End of story is happy constantly.
        public bool _HappyEnd { get; set; } = false;

        public Reader()
        {
            People = new List<Person>();
        }

        public Reader(List<Person> people)
        {
            People = people;
        }

        // Void reads and writes story.
        public override void StartReading(IWriter writer)
        {
            // Contains people in home.
            var inHome = new List<Person>();
            // Home had crashed.
            var crash = false;
            writer.Write("Стоит в поле теремок.");
            try
            {
                while (People.Count != inHome.Count && !crash)
                {
                    var personIndex = 0;
                    var person = _GetPerson(inHome, out personIndex);
                    _Moving(person, writer);
                    _Answer(inHome, person, writer, out crash);
                    inHome.Add(person);
                    _GetExeption();
                }
                if (crash)
                    _Crashing(inHome, writer);
                else
                    _Happy(writer);
            }
            catch (PersonExeption ex)
            {
               writer.Write(ex.Message);
               writer.Write(ex.Solve);
            }
            finally
            {
                writer.Write("Конец.");
                _WriteStatistic();
            }
        }

        private void _WriteStatistic()
        {
            using (StreamWriter sr = new StreamWriter("Ends.txt",false))
            {
                sr.WriteLine(GoodEnd);
                sr.WriteLine(BadEnd);
            }
        }

        private Random _R = new Random();

        // Retuen Exeption
        protected override void _GetExeption()
        {
            int i = _R.Next(15);
            switch (i)
            {
                case 1:
                    BadEnd++;
                    throw new PersonExeption("Но вдруг, от количества персонажей внутри, теремок упал.", "К счастью, всем удалось спастись.");
                case 2 when (i < 7):
                    BadEnd++;
                    throw new PersonExeption("В лесу начался сезон охоты.", "Героям пришлось убежать и спрятаться в лесу.");
                case 3:
                    GoodEnd++;
                    throw new PersonExeption("Герои осмотрели теремок и нашли много просторных комнат под зданием.", "Теперь места хватит всем жлающим и теремок точно не сломается");
            }

        }

        // When home is crashing.
        private void _Crashing(List<Person> people, IWriter writer)
        {
            writer.Write("Вдруг, затрещал теремок, упал набок и весь развалился");
            StringBuilder refugees = new StringBuilder("Еле-еле удалось выбраться из него: ");
            foreach (var p in people)
                refugees.Append($"{p.Name},");
            refugees.Remove(refugees.Length - 1, 1);
            refugees.Append(" - в целости и сохранности.");
            writer.Write(refugees.ToString());
            if(people.Count>1)
            writer.Write("Принялись они бревна носить, доски пилить — новый теремок строить. " +
                         " Лучше прежнего получился!");
            BadEnd++;

        }

        // Happy end
        private void _Happy(IWriter writer)
        {
            writer.Write("Стоял теремок еще много лет и все жили в нем долго и счастливо.");
            GoodEnd++;
        }

        // Person go to home.
        private void _Moving(Person person,IWriter writer)
        {
            var action = person.Move() + " " + person.Name + ".";
            writer.Write(action);
            action = $"{person.Stop()} и спрашивает: ";
            writer.Write(action);
            writer.Write("--- Терем - теремок! Кто в тереме живет?");
        }

        // People in home are answering.
        private void _Answer(List<Person> inHome, Person person, IWriter writer, out bool crash)
        {
            if (inHome.Count == 0)
            {
                writer.Write("Никто не отзывается");
                writer.Write($"{person.Enter()} {person.Name} и живет в теремке.");
            }
            else
            {
                foreach (var i in inHome)
                    writer.Write($"--- Я, {i.Name}!");
                writer.Write("--- А ты кто?");
                writer.Write($"--- А я - {person.Name}.");
                writer.Write(inHome.Count > 1 ? "--- Иди к нам жить" : "--- Иди ко мне жить");
                writer.Write($"{person.Enter()} в теремок.");
            }
            crash = !_HappyEnd? _CrashTest(inHome,person):false;
            if (!crash&&inHome.Count>0)
                writer.Write($"Стали они в{inHome.Count + 1}-ем жить.");

        }

        // Test for build.
        private bool _CrashTest(List<Person> inHome, Person person)
        {
            //int count = 0;
            //foreach (var i in inHome)
            //    if (i.Crashed())
            //        count++;
            //if (person.Crashed())
            //    count++;
            //return count >= (inHome.Count + 1) / 3 * 2;
            return person.Crashed();
        }

        //Takes a new person
        private Person _GetPerson(List<Person> inHome,out int index)
        {
            if(!_Random)
            {
                index = 0;
                return People.First(p => !inHome.Contains(p));
            }
            else
            {
                var freePeople = People.Where(p => !inHome.Contains(p)).ToList();
                                
                index = new Random().Next(freePeople.Count);
                return freePeople[index];
            }
        }
    }
}
