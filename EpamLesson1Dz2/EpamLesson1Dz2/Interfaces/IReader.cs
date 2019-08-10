using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamLesson1Dz2.Interfaces
{
    interface IReader
    {
        void StartReading(IWriter writer);
    }
}
