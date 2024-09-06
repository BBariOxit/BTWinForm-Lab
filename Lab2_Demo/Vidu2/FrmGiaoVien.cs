using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vidu2
{
    public partial class FrmGiaoVien : Form
    {
        public FrmGiaoVien()
        {
            InitializeComponent();
        }

        private void FrmGiaoVien_Load(object sender, EventArgs e)
        {
            string lienhe = "https://www.youtube.com/watch?v=y5XlsTTqyBk&list=PLoU6znVFVEY5zROnFOOjzAmHguBqNeAWG&index=18";
            this.linklbLienHe.Links.Add(0, lienhe.Length, lienhe);
            this.cboMaSo.SelectedItem = this.cboMaSo.Items[0];
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int i = this.lbDanhSachMH.SelectedItems.Count - 1;
            while(i >= 0)
            {
                this.lbMonHocDay.Items.Add(lbDanhSachMH.SelectedItems[i]);
                this.lbDanhSachMH.Items.Remove(lbDanhSachMH.SelectedItems[i]);
                i--;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = this.lbMonHocDay.SelectedItems.Count - 1;
            while(i >= 0)
            {
                this.lbDanhSachMH.Items.Add(lbMonHocDay.SelectedItems[i]);
                this.lbMonHocDay.Items.Remove(lbMonHocDay.SelectedItems[i]);
                i--;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            this.cboMaSo.Text = string.Empty;
            this.txtHoTen.Text = string.Empty;
            this.txtMail.Text = string.Empty;
            this.mtxtSoDT.Text = string.Empty;
            this.rdNam.Checked = true;
            for(int i = 0; i< chklbNgoaiNgu.Items.Count-1; i++)
            {
                chklbNgoaiNgu.SetItemChecked(i, false);
            }
            foreach (object ob in this.lbMonHocDay.Items)
            {
                this.lbDanhSachMH.Items.Add(ob);
            }
            this.lbDanhSachMH.Items.Clear();
        }

        private void linklbLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = e.Link.LinkData.ToString();
            Process.Start(s);   
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            frmTBGiaoVien frm = new frmTBGiaoVien();
            frm.setText(GetgiaoVien().ToString());
            frm.ShowDialog();

        }
        public GiaoVien GetgiaoVien()
        {
            string gt = "Nam";
            if(rdNu.Checked) {
                gt = "Nữ";
            }
            GiaoVien gv =  new GiaoVien();
            gv.MaSo = this.cboMaSo.Text;
            gv.GioiTinh = gt;
            gv.HoTen = this.txtHoTen.Text;
            gv.NgaySinh = this.dtpNgaySinh.Value;
            gv.Mail =this.txtMail.Text;
            gv.SoDT = this.mtxtSoDT.Text;
            string ngoaingu = "";
            for(int i= 0 ; i < chklbNgoaiNgu.Items.Count-1; i++) 
            {
                if (chklbNgoaiNgu.GetItemChecked(i))
                    ngoaingu += chklbNgoaiNgu.Items[i] + ";";
                gv.NgoaiNgu = ngoaingu.Split(';');
            }
            DanhMucMonHoc mh =  new DanhMucMonHoc();
            foreach(object ob in lbMonHocDay.Items)
            {
                mh.Them(new MonHoc(ob.ToString()));
            }
            gv.dsMonHoc = mh;
            return gv;
        }
    }
}
