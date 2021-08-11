using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppExample.Hoc.Chuong2
{
    public  class Muc21
    {
        public void TinhTong()
        {
            int n; //khởi tạo biến n kiểu dữ liệu n
            Console.Write("Nhap so phan tu cua day so: ");

            do
                n = int.Parse(Console.ReadLine()); //Nhận giá trị từ bàn phím và ép kiểu về int rồi gán cho n
            while (n <= 0);

            Int16[] arr = new Int16[n]; //Tạo ra mảng int với n phần tử

            for (int i = 0; i < n; i++) //Chạy vòng lặp để nhập vào giá trị cho các phần tử cho mảng
            {
                Console.Write("A[{0}] = ", i + 1);
                arr[i] = Int16.Parse(Console.ReadLine());
            }

            Int16 s = 0; //Tạo ra biển lưu tổng giá trị các phần tử trong mảng

            for (int i = 0; i < n; i++) ///chạy vòng lặp cộng dồn mỗi lần
            {
                s += arr[i];
            }
               
            Console.Write("Tong day so bang: {0}", s); //In ra tổng
        }

        private void HoanVi(int a, int b)
        {
            int tam = a;
            a = b;
            b = tam;
            Console.WriteLine("Trong HoanVi: a = " + a + ";b = " + b);
        }

        private void HoanVi(ref int a, ref int b)
        {
            int tam = a;
            a = b;
            b = tam;
            Console.WriteLine("Trong HoanVi: a = " + a + ";b = " + b);
        }

        public void HoanViMain()
        {
            int a = 5, b = 21;

            Console.WriteLine("Su dung tham tri:");
            Console.WriteLine("Truoc HoanVi: a = {0}; b = {1}", a, b);
            HoanVi(a, b);
            Console.WriteLine("Sau HoanVi: a = " + a + ";b = " + b);

            Console.WriteLine("Su dung tham chieu:");
            Console.WriteLine("Truoc HoanVi: a = {0}; b = {1}", a, b);
            HoanVi(ref a, ref b);
            Console.WriteLine("Sau HoanVi: a = " + a + ";b = " + b);

        }
    }
}
