using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstAppExample.Common;
using FirstAppExample.Hoc.Chuong3;

namespace FirstAppExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(20, 30);

            Square square = new Square(30);

            Rectangle square1 = new Square(30);

            Console.Write("A rectangle area = {0}", rectangle.GetArea());
            Console.WriteLine();
            Console.Write("A square area = {0}", square.GetArea());

            Console.ReadKey();
        }
    }
}
