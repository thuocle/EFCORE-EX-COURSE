using QLCOURSE.Controller.IServices;
using QLCOURSE.Controller.Services;
using QLCOURSE.Model.Entities;
using QLCOURSE.Model.Helper;

void Main()
{
    IKhoaHocServices khoaHocServices = new KhoaHocServices();
    INgayHocServices ngayHocServices = new NgayHocServices();
    IHocVienServices hocVienServices = new HocVienServices();
    /* int khID = int.Parse(Console.ReadLine());*/
    /*hocVienServices.SearchStudentsByName(hoten);*/
    khoaHocServices.CalculateRevenueInMonth();

}
Main();

