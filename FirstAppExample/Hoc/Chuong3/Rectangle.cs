using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppExample.Hoc.Chuong3
{
    public class Rectangle : Shapes
    {
        protected double _width;
        public double Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        protected double _height;
        public double Height
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

        public Rectangle()
        {

        }

        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public override double GetArea()
        {
            return _width * _height;
        }
    }
}
