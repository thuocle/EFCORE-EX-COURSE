using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCOURSE.Model.Entities
{
    public class HocVien
    {
        public int HocVienID { get; set; }
        public int KhoaHocID { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string QueQuan { get; set; }
        public string SoDienThoai { get; set; }

    }
}
