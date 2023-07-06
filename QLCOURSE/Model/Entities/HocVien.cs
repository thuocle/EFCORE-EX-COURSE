using QLCOURSE.Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(20)]
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string QueQuan { get; set; }
        [MaxLength(10)]
        public string SoDienThoai { get; set; }
        public HocVien(inputType it)
        {
            if(it == inputType.Them)
            {
                KhoaHocID = InputHelper.InputINT(Res.KhoaHocID, Res.Error);
                HoTen = InputHelper.InputName(Res.HoTen, Res.Error, 1, 20);
                NgaySinh = InputHelper.InputDT(Res.NgaySinh, Res.Error, new DateTime(1990, 1,1), new DateTime(2010, 12, 31));
                DiaChi = InputHelper.InputSTR(Res.DiaChi, Res.Error);
                QueQuan = InputHelper.InputSTR(Res.QueQuan, Res.Error);
                SoDienThoai = InputHelper.PhoneNumBer(Res.SoDienThoai, Res.Error);
            }
        } 
        public HocVien()
        {
            
        }
        public void UpDate()
        {
            KhoaHocID = InputHelper.InputINT(Res.KhoaHocID, Res.Error);
            HoTen = InputHelper.InputName(Res.HoTen, Res.Error, 1, 20);
            NgaySinh = InputHelper.InputDT(Res.NgaySinh, Res.Error, new DateTime(1990, 1, 1), new DateTime(2010, 12, 31));
            DiaChi = InputHelper.InputSTR(Res.DiaChi, Res.Error);
            QueQuan = InputHelper.InputSTR(Res.QueQuan, Res.Error);
            SoDienThoai = InputHelper.PhoneNumBer(Res.SoDienThoai, Res.Error);
        }
    }
}
