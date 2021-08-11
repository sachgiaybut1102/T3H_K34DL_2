using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAppExample.Hoc.Chuong3
{
    public class Diem
    {
        private int _x;
        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        private int _y;
        public int Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        /// <summary>
        /// Nhập giá trị cho x và y.
        /// </summary>
        public void Nhap()
        {
            _x = GetGiaTri("X");
            _y = GetGiaTri("Y");
        }

        /// <summary>
        /// Dùng để đảo tọa độ âm sang dương và ngược lại.
        /// </summary>
        public void DoiToaDo()
        {
            _x = -_x;
            _y = -_y;
        }

        /// <summary>
        /// Dùng để thay đổi tọa độ của điểm hiện tại sang vị trí mới
        /// </summary>
        /// <param name="dx">Khoảng cách đến từ vị trí hiện tại đến vị mới trên trục x</param>
        /// <param name="dy">>Khoảng cách đến từ vị trí hiện tại đến vị mới trên trục y</param>
        public void DiChuyen(int dx, int dy)
        {
            _x += dx;
            _y += dy;
        }

        /// <summary>
        /// Dùng để hiển thị giá tọa đọa điểm.
        /// </summary>
        public void Hien()
        {
            Console.WriteLine("Toa do: ({0} , {1})", _x, _y);
        }

        /// <summary>
        /// Phương thức sẽ chuẩn hóa đầu vào dữ liệu và trả về một số kiểu nguyên.
        /// </summary>
        /// <param name="tenBien">Dùng để đặt hiển thị tên biến mà người dùng muốn nhập giá trị.</param>
        /// <returns>1 số nguyên.</returns>
        private int GetGiaTri(string tenBien)
        {
            bool flag;

            int num;

            do
            {
                flag = true;

                Console.Write("{0} = ", tenBien);

                if (!int.TryParse(Console.ReadLine(), out num))
                {
                    Console.WriteLine("Chuoi vua nhap khong phai la 1 so nguyen, vui long nhap lai!!!");

                    flag = false;
                }


            } while (!flag);

            return num;
        }
    }
}
