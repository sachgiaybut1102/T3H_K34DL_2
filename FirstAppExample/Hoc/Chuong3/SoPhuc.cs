using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppExample.Hoc.Chuong3
{
    public class SoPhuc
    {
        private int _phanThuc;
        private int _phanAo;

        public SoPhuc()
        {
            _phanThuc = 0;
            _phanAo = 0;
        }

        public SoPhuc(int phanThuc, int phanAo)
        {
            _phanThuc = phanThuc;
            _phanAo = phanAo;
        }

        public static SoPhuc Cong(SoPhuc a, SoPhuc b)
        {
            SoPhuc result = new SoPhuc();

            result._phanThuc = a._phanThuc + b._phanThuc;
            result._phanAo = a._phanAo + b._phanAo;

            return result;
        }

        public static SoPhuc Cong(SoPhuc a, int b)
        {
            SoPhuc result = new SoPhuc();

            result._phanThuc = a._phanThuc + b;
            result._phanAo = a._phanAo;

            return result;
        }

        /// <summary>
        /// Nạp chồng toán tử công hai số phức với nhau
        /// </summary>
        /// <param name="a">Số phức</param>
        /// <param name="b">Số phức</param>
        /// <returns>Một số phức</returns>
        public static SoPhuc operator +(SoPhuc a, SoPhuc b)
        {
            SoPhuc result = new SoPhuc();

            result._phanThuc = a._phanThuc + b._phanThuc;
            result._phanAo = a._phanAo + b._phanAo;

            return result;
        }

        /// <summary>
        /// Nạp chồng toán tử cộng một số phức với 1 số nguyên
        /// </summary>
        /// <param name="a">Số phức</param>
        /// <param name="b">số nguyên</param>
        /// <returns>Số nguyên</returns>
        public static SoPhuc operator +(SoPhuc a, int b)
        {
            SoPhuc result = new SoPhuc();

            result._phanThuc = a._phanThuc + b;
            result._phanAo = a._phanAo;

            return result;
        }

        public void In()
        {
            Console.Write("({0} , {1})", _phanThuc, _phanAo);
        }
    }
}
