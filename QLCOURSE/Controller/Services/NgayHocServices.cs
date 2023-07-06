using QLCOURSE.Controller.IServices;
using QLCOURSE.Model.Entities;
using QLCOURSE.Model.Helper;

namespace QLCOURSE.Controller.Services
{
    public class NgayHocServices : INgayHocServices
    {
        private readonly AppDbContext dbContext;

        public NgayHocServices()
        {
            this.dbContext = new AppDbContext();
        }
        public KhoaHoc IsKhoaHoc(int khID)
        {
            return dbContext.KhoaHoc.FirstOrDefault(x => x.KhoaHocID == khID);
        }

        public void AddCourseDate(NgayHoc n)
        {
            using (var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (IsKhoaHoc(n.KhoaHocID) == null)
                    {
                        Console.WriteLine("Khoa hoc" + Res.KhongTonTai);
                        Console.WriteLine(Res.ThatBai);
                        return;
                    }
                    if (!InputHelper.CheckKhoaHocRule(IsKhoaHoc(n.KhoaHocID)))
                    {
                        Console.WriteLine(Res.Error);
                        Console.WriteLine(Res.ThatBai);
                        return;
                    }
                    dbContext.Add(n);
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
    }
}
