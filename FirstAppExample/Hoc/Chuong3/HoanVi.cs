using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppExample.Hoc.Chuong3
{
    public class HoanVi
    {
        public void ThamTri(int a, int b)
        {
            int swap = a;
            a = b;
            b = swap;

            Console.WriteLine("a = {0}, b = {1}", a, b);
        }

        public void ThamChieu(ref int a, ref int b)
        {
            int swap = a;
            a = b;
            b = swap;

            Console.WriteLine("a = {0}, b = {1}", a, b);
        }
    }
}
