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
            using(var trans = dbContext.Database.BeginTransaction())
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
            using( var trans = dbContext.Database.BeginTransaction())
            {
                try
                {
                    if(IsKhoaHoc(khID)== null)
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
    }
}
