using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppExample.Hoc.Chuong2
{
    public class Bai2
    {
        public Bai2()
        {

        }

        public void Run()
        {
            int a = Input("a");
            int b = Input("b");
            int c = Input("c");

            int max = GetMax(a, b);
            max = GetMax(max, c);

            Console.WriteLine("So lon nhat {0}, {1}, {2} la: {3}", a, b, c, max);
        }

        private int Input(string name)
        {
            int num;

            bool flag = true;

            do
            {
                flag = true;
                Console.Write("Nhập vào giá trị {0} = ", name);

                if (!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("Gia tri vua nhap khong phai la 1 so nguyen, vui long nhap lai!");

                    flag = false;
                }
            }
            while (!flag);

            return num;
        }

        private int GetMax(int num0, int num1)
        {
            if (num0 > num1)
            {
                return num0;
            }

            return num1;
        }
    }
}
