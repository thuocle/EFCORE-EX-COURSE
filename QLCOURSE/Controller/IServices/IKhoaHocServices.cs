using QLCOURSE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCOURSE.Controller.IServices
{
    public interface IKhoaHocServices
    {
        void AddCourse(KhoaHoc kh);
        void DeleteCourse(int khID);
    }
}
