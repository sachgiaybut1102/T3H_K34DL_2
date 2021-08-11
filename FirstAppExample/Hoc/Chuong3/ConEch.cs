using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppExample.Hoc.Chuong3
{
    public class ConEch : IDongVatTrenCan, IDongVatDuoiNuoc
    {
        public void Jump()
        {
            Console.WriteLine("Nhay");
        }

        public void Swim()
        {
            Console.WriteLine("Boi");
        }
    }
}
