using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidu2
{
    internal class GiaoVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh;
        public DanhMucMonHoc dsMonHoc;
        public string GioiTinh;
        public string[] NgoaiNgu;
        public string SoDT;
        public string Mail;
        public GiaoVien()
        {
            dsMonHoc = new DanhMucMonHoc();
        }
        public GiaoVien(string maso, string hoten, DateTime ngaysinh, DanhMucMonHoc ds, string gt, string[] nn, string sdt, string mail)
        {
            MaSo = maso;
            HoTen = hoten;
            NgaySinh = ngaysinh;
            this.dsMonHoc = ds;
            GioiTinh = gt;
            NgoaiNgu = nn;
            SoDT = sdt;
            Mail = mail;
        }
        public override string ToString()
        {
            string s = "Mã số:" + MaSo + "\n" + "Họ Tên:" + HoTen + "\n"
                + "Ngày Sinh:" + NgaySinh.ToString() + "\n"
                + "Giới tính:" + GioiTinh + "\n"
                + "Số DDT:" + SoDT + "\n"
                + "Mail:" + Mail + "\n";
            string sngoaingu = "Ngoại ngữ:";
            foreach (string t in NgoaiNgu)
            {
                sngoaingu += t + ";";
            }
            string Monday = "Danh sách môn dạy:";
            foreach(MonHoc mh in dsMonHoc.ds)
            {
                Monday += mh + ";";
            }
            s += "\n" + sngoaingu + "\n" + Monday;
            return s;
        }
    }
}
