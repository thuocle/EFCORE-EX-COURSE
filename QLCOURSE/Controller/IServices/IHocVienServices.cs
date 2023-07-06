using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLCOURSE.Controller.IServices
{
    public interface IHocVienServices
    {
        void UpdateStudentInfo(int hvID);
        void SearchStudentsByName(string tenHV);
    }
}
