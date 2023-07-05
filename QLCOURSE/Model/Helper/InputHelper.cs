using QLCOURSE.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLCOURSE.Model.Helper
{
    public enum inputType
    {
        Them
    }
    public class InputHelper
    {
        #region KiemTraKhiNhap
        public static string PhoneNumBer(string msg, string err)
        {
            bool check;
            string ret;
            do
            {
                Console.WriteLine(msg);
                ret = Console.ReadLine();
                check = IsPhoneNumber(ret);
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        public static string Email(string msg, string err)
        {
            bool check;
            string ret;
            do
            {
                Console.WriteLine(msg);
                ret = Console.ReadLine();
                check = IsEmail(ret);
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        #region Private method
        private static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^([0-9]{10})$").Success;
        }
        private static bool IsEmail(string email)
        {
            return Regex.Match(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$").Success;
        }
        private static bool IsMoreTwoWord(string str)
        {
            return str.Split(' ').Length > 2;
        }
        #endregion

        public static int InputINT(string msg, string err, int min = 0, int max = int.MaxValue)
        {
            bool check;
            int ret;
            do
            {
                Console.WriteLine(msg);
                check = int.TryParse(Console.ReadLine(), out ret);
                check = check && ret >= min && ret <= max;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        public static string InputSTR(string msg, string err, int min = 0, int max = int.MaxValue)
        {
            bool check;
            string ret;
            do
            {
                Console.WriteLine(msg);
                ret = Console.ReadLine();
                check = ret.Length >= min && ret.Length <= max;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        public static string InputName(string msg, string err, int min = 0, int max = int.MaxValue)
        {
            bool check;
            string ret;
            do
            {
                Console.WriteLine(msg);
                ret = Console.ReadLine();
                check = ret.Length >= min && ret.Length <= max && IsMoreTwoWord(ret);
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }

        public static DateTime InputDT(string msg, string err, DateTime min, DateTime max)
        {
            bool check;
            DateTime ret;
            do
            {
                Console.WriteLine(msg);
                check = DateTime.TryParse(Console.ReadLine(), out ret);
                check = check && ret >= min && ret <= max;
                if (!check) Console.WriteLine(err);
            } while (!check);
            return ret;
        }
        #endregion
        #region KiemTraKhiCRUD
        public static bool CheckHocVienRule(HocVien hv)
        {
            return hv.HoTen.Length <= 20 && hv.HoTen.Split(' ').Length > 2 && hv.NgaySinh.Year >= 1970 && hv.NgaySinh.Year <= 2000;
        }
        public static bool CheckKhoaHocRule(KhoaHoc kh)
        {
            TimeSpan time = kh.NgayKetThuc.Subtract(kh.NgayBatDau);
            return kh.TenKhoaHoc.Length <= 10 && kh.HocPhi <10000 && time.Days <= 15 && time.Days >0;
        }
        
        #endregion
    }
}
