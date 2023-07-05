using QLCOURSE.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCOURSE.Model.Entities
{
    public class NgayHoc
    {
        public int NgayHocID { get; set; }
        public int KhoaHocID { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
        public string NoiDung { get; set; }
        public string GhiChu { get; set; }
        public NgayHoc(inputType it)
        {
            if(it == inputType.Them)
            {
                KhoaHocID = InputHelper.InputINT(Res.KhoaHocID, Res.Error);
                NoiDung = InputHelper.InputSTR(Res.NoiDung, Res.Error);
                GhiChu = InputHelper.InputSTR(Res.GhiChu, Res.Error);

            }
        }
        public NgayHoc()
        {
            
        }
    }
}
