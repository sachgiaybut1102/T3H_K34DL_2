using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppExample.Hoc.Chuong3
{
    public class Cat
    {
        private int _weight;
        public int Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }
        private int _height;
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        public static int Count = 0;
        private int _countDynamic = 0;
        public int CountDynamic
        {
            get
            {
                return _countDynamic;
            }
        }
        public Cat()
        {
            _weight = 20;
            _height = 500;
            Count++;
            _countDynamic++;
        }
    }
}
