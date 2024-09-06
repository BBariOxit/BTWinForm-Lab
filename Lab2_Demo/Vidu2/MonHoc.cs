using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidu2
{
    internal class MonHoc
    {
        public int Id { get; set; }
        public int SoTC { get; set; }
        public string TenMH { get; set; }
        public MonHoc() { }
        public MonHoc(int id, int tc, string ten)
        {
            Id = id;
            SoTC = tc;
            TenMH = ten;
        }   
        public MonHoc(string ten)
        {
            TenMH = ten;
        }
        public override string ToString()
        {
            return TenMH;
        }
    }
}
