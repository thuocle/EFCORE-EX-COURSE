using QLCOURSE.Controller.IServices;
using QLCOURSE.Model.Entities;
using QLCOURSE.Model.Helper;
using System.Linq;

namespace QLCOURSE.Controller.Services
{
    public class KhoaHocServices : IKhoaHocServices
    {
        private readonly AppDbContext dbContext;

        public KhoaHocServices()
        {
            this.dbContext = new AppDbContext();
        }
        public KhoaHoc IsKhoaHoc(int khID)
        {
            return dbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocID == khID);
        }
        public void AddCourse(KhoaHoc kh)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (!InputHelper.CheckKhoaHocRule(kh))
                    {
                        Console.WriteLine(Res.Error);
                        Console.WriteLine(Res.ThatBai);
                        return;
                    }
                    dbContext.Add(kh);
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

        public void DeleteCourse(int khID)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (IsKhoaHoc(khID) == null)
                    {
                        Console.WriteLine("Khoa hoc" + Res.KhongTonTai);
                        Console.WriteLine(Res.ThatBai);
                        return;
                    }
                    dbContext.Remove(IsKhoaHoc(khID));
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

        public void CalculateRevenueInMonth()
        {
            var query = from hv in dbContext.HocVien
                        join kh in dbContext.KhoaHoc on hv.KhoaHocID equals kh.KhoaHocID
                        join n in dbContext.NgayHoc on kh.KhoaHocID equals n.KhoaHocID 
                        orderby kh.NgayBatDau
                        group new
                        {
                            hv,
                            kh,
                            n
                        } by new
                        {
                           Months = kh.NgayBatDau.Month
                        } into gDoanhThu 
                        select new
                        {
                            Thang = gDoanhThu.Key.Months,
                            doanhThu = gDoanhThu.Sum(x => x.kh.HocPhi)
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"Thang {item.Thang}:");
                Console.WriteLine(item.doanhThu + "000VND");
            }
            Console.WriteLine("Tong doanh thu cua trung tam: " + query.Sum(x=>x.doanhThu)+"000VND");
        }
        public void CalculateRevenueInMonth2()
        {
        
        }
    }
}
