using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCOURSE.Model.Entities
{
    public class KhoaHoc
    {
        public int KhoaHocID { get; set; }
        public string TenKhoaHoc { get; set; }
        public string MoTa { get; set; }
        public int HocPhi { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public IEnumerable<HocVien> HocVien { get; set; }
        public IEnumerable<NgayHoc> NgayHoc { get; set; }
    }
}
