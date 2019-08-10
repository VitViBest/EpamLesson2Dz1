using EpamLesson1Dz2.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using EpamLesson1Dz2.Models;

namespace EpamLesson1Dz2
{
    class Program
    {
        static Reader Creating()
        {
            Reader reader;
            List<Person> people = new List<Person>();
            int i = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Произвести настройку персонажей (1-да, 2-автоматически):");
                if (!int.TryParse(Console.ReadLine(), out i))
                    i = 0;
                switch (i)
                {
                    case 1:
                        int f = 0;
                        do
                        {
                            Console.Clear();
                            foreach (var p in people)
                                Console.WriteLine(p.Name);
                            Console.WriteLine("\n1-добавить персонажа, 2-удалить, 3-закончить настройку :");
                            if (!int.TryParse(Console.ReadLine(), out f))
                                f = 0;
                            switch (f)
                            {
                                case 1:
                                    _Add(people);
                                    break;
                                case 2:
                                    _Delete(people);
                                    break;
                                case 3:
                                    if (people.Count == 0)
                                    {
                                        _ShowError("Список пуст!");
                                        f = 0;
                                        continue;
                                    }
                                    break;
                                default:
                                    _ShowError();
                                    break;

                            }
                        } while (f!=3);
                        break;
                    case 2:
                        people = _Initialization();
                        break;
                    default:
                        _ShowError();
                        break;
                }
            } while (i != 1 && i != 2);
            reader = new Reader(people);
            bool test = false;
            do
            {
                if (test)
                {
                    _ShowError();
                }
                test = false;
                Console.Clear();
                Console.WriteLine("Персонажи в случайном порядке?(1-да, 2-нет):");
                if (!int.TryParse(Console.ReadLine(), out i) || i < 1 || i > 2)
                {
                    test = true;
                }
            } while (test);
            reader._Random = i == 1;
            test = false;
            do
            {
                if (test)
                {
                    _ShowError();
                }
                test = false;
                Console.Clear();
                Console.WriteLine("Всегда счастливый конец?(1-да, 2-нет):");
                if (!int.TryParse(Console.ReadLine(), out i) || i < 1 || i > 2)
                {
                    test = true;
                }
            } while (test);
            reader._HappyEnd = i == 1;
            return reader;
        }

        //Add new person.
        static void _Add(List<Person> people)
        {
            int i = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("1-мышка, " +
                                  "2-жабка, " +
                                  "3-зайчик,\n" +
                                  "4-лисичка, " +
                                  "5-волк, " +
                                  "6-медведь,\n" +
                                  "7-отмена");
                if (!int.TryParse(Console.ReadLine(), out i))
                    i = 0;
                switch (i)
                {
                    case 1:
                        people.Add(new Mouse(_GetName(people, "Мышка-")));
                        break;
                    case 2:
                        people.Add(new Frog(_GetName(people, "Лягушка-")));
                        break;
                    case 3:
                        people.Add(new Rabbit(_GetName(people, "Зайчик-")));
                        break;
                    case 4:
                        people.Add(new Fox(_GetName(people, "Лисичка-"), _GetMass()));
                        break;
                    case 5:
                        people.Add(new Wolf(_GetName(people, "Волчок-"), _GetMass()));
                        break;
                    case 6:
                        people.Add(new Bear(_GetName(people, "Медведь-"), _GetMass(), _GetHeight()));
                        break;
                    case 7:
                        return;
                    default:
                        _ShowError();
                        break;
                }
            } while (i<1||i>7);
        }

        static void _ShowError(string message= "Неверное значение!")
        {
            Console.WriteLine(message);
            Console.ReadKey();
        }

        static string _GetName(List<Person> people, string type)
        {
            string name="";
            bool test = false;
            do
            {
                if (test)
                {
                    _ShowError();
                }
                test = false;
                Console.Clear();
                Console.WriteLine("Имя:");
                name= Console.ReadLine();
                test =name.Length == 0|| people.Any(x => x.Name.ToLower().CompareTo((type + name).ToLower()) == 0);
            } while (test);
            return name;
        }

        static int _GetMass()
        {
            int mass = 0;
            bool test = false;
            do
            {
                if (test)
                {
                    _ShowError();
                }
                test = false;
                Console.Clear();
                Console.WriteLine("Вес: ");
                test = !int.TryParse(Console.ReadLine(), out mass) || mass < 30 || mass > 100;
            } while (test);
            return mass;
        }

        static int _GetHeight()
        {
            int height = 0;
            bool test = false;
            do
            {
                if (test)
                {
                    _ShowError();
                }
                test = false;
                Console.Clear();
                Console.WriteLine("Рост: ");
                test = !int.TryParse(Console.ReadLine(), out height) || height < 1 || height > 7;
            } while (test);
            return height;
        }

        //Delete person
        static void _Delete(List<Person> people)
        {
            if (people.Count > 0)
            {
                int i = - 1;
                bool test = false;
                do
                {
                    if (test)
                        _ShowError();
                    test = false;
                    Console.Clear();
                    Console.WriteLine("Индекс:");
                    if (int.TryParse(Console.ReadLine(), out i) && i > -1 && i < people.Count)
                        people.RemoveAt(i);
                    else
                    {
                        test = true;
                    }
                } while (test);
            }
            else
            {
                _ShowError("Список пуст!");
            }
        }
        
        //Basic order
        static List<Person> _Initialization()
        {
            var people = new List<Person>();
            people.Add(new Mouse("норушка"));
            people.Add(new Frog("квакушка"));
            people.Add(new Fox("сестричка", 100));
            people.Add(new Wolf("братик", 150));
            people.Add(new Bear("косолапый", 500, 10));
            return people;
        }

        static void Main(string[] args)
        {
            Reader reader = Creating();
            var consoleWriter = new ConsoleWriter(ConsoleColor.White, ConsoleColor.Black);
            reader.StartReading(consoleWriter);
           
        }
    }
}
