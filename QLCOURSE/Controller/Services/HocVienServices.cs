using QLCOURSE.Controller.IServices;
using QLCOURSE.Model.Entities;
using QLCOURSE.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCOURSE.Controller.Services
{
    public class HocVienServices : IHocVienServices
    {
        private readonly AppDbContext dbContext;

        public HocVienServices()
        {
            this.dbContext = new AppDbContext();
        }
        private HocVien IsHocVien(int hvID)
        {
            return dbContext.HocVien.FirstOrDefault(x => x.HocVienID == hvID);
        }
        public KhoaHoc IsKhoaHoc(int khID)
        {
            return dbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocID == khID);
        }
        public void UpdateStudentInfo(int hvID)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var hv = IsHocVien(hvID);
                    if ( hv == null)
                    {
                        Console.WriteLine("Hoc Vien" + Res.KhongTonTai);
                        Console.WriteLine(Res.ThatBai);
                        return;
                    }
                    hv.UpDate();
                    if (!InputHelper.CheckHocVienRule(hv))
                    {
                        Console.WriteLine(Res.Error);
                        Console.WriteLine(Res.ThatBai);
                        return;
                    }
                    dbContext.Update(hv);
                    dbContext.SaveChanges();
                    Console.WriteLine(Res.ThanhCong);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void SearchStudentsByName(string tenHV)
        {
            var query = from hv in dbContext.HocVien
                        join kh in dbContext.KhoaHoc on hv.KhoaHocID equals kh.KhoaHocID
                        join n in dbContext.NgayHoc on kh.KhoaHocID equals n.KhoaHocID
                        where hv.HoTen == tenHV
                        group new { hv, kh, n } by new { hv.HoTen, hv.HocVienID } into gHV
                        select new
                        {
                            hoten = gHV.Key.HoTen,
                            khoahoc = gHV.Select(x=> new
                            {
                                tenkh = x.kh.TenKhoaHoc
                            })
                        };
            foreach (var item in query)
            {
                    Console.WriteLine($"{item.hoten}: ");
                    foreach (var kh in item.khoahoc)
                    {
                        Console.WriteLine($"{kh.tenkh}");
                    }
            }
        }
    }
}
