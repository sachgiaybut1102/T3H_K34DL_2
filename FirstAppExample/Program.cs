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

            Circle circle = new Circle(30);

            List<Shapes> shapes = new List<Shapes>();

            shapes.Add(rectangle);
            shapes.Add(square);
            shapes.Add(circle);

            Shapes shapes1 = new Rectangle(30, 30);
            
            foreach(var shape in shapes)
            {
                Console.WriteLine(shape.GetArea());
            }
            //Console.Write("A rectangle area = {0}", rectangle.GetArea());
            //Console.WriteLine();
            //Console.Write("A square area = {0}", square.GetArea());
            //Console.WriteLine();
            //Console.Write("A circle area = {0}", circle.GetArea());

            IDongVatTrenCan dongVatTrenCan = new ConEch();
            dongVatTrenCan.Jump();

            Console.ReadKey();
        }
    }
}
