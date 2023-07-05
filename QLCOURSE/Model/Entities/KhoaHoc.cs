using QLCOURSE.Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCOURSE.Model.Entities
{
    public class KhoaHoc
    {
        public int KhoaHocID { get; set; }
        [MaxLength(10)]
        public string TenKhoaHoc { get; set; }
        public string MoTa { get; set; }
        [Range(0, 10000)]
        public int HocPhi { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public IEnumerable<HocVien> HocVien { get; set; }
        public IEnumerable<NgayHoc> NgayHoc { get; set; }
        public KhoaHoc(inputType it)
        {
            if(it == inputType.Them)
            {
                TenKhoaHoc = InputHelper.InputSTR(Res.TenKhoaHoc, Res.Error, 1, 10);
                MoTa = InputHelper.InputSTR(Res.MoTa, Res.Error, 1, 30);
                HocPhi = InputHelper.InputINT(Res.HocPhi, Res.Error, 1, 10000);
                NgayBatDau = InputHelper.InputDT(Res.NgayBatDau, Res.Error, new DateTime(2023, 1, 1), new DateTime(2023, 12, 31));
                NgayKetThuc = InputHelper.InputDT(Res.NgayKetThuc, Res.Error, new DateTime(2023, 1, 1), new DateTime(2023, 12, 31));
            }
        }
        public KhoaHoc()
        {
            
        }
    }
}
