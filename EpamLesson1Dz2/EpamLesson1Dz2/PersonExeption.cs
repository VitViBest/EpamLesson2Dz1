using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLesson1Dz2
{
    class PersonExeption : Exception
    {
        public string Solve { get;private set; }

        public PersonExeption(string message,string solve) : base(message)
        {
            Solve = solve;
        }
    }
}
