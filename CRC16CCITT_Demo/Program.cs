using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRC16CCITT_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = Encoding.ASCII.GetBytes("String de prueba de 256 bytes de largooooo");

            var res1 = Core.AddCrcToBuffer(buffer, buffer.Length);

            var res2 = Core.AddCrcToBuffero(buffer, buffer.Length);
        }
    }
}
