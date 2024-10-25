using CTDL_quan_ly_hoc_sinh;
using System.Runtime.Serialization.Formatters.Binary;// Nho dung NETCODE 6.0; 

namespace QLDL_HocSinh
{
    public partial class QuanLyHocSinh : Form
    {
        private List<HocSinh> ds;
        //private Dictionary<string, HocSinh> ds; // DIC
        public QuanLyHocSinh()
        {
            InitializeComponent();
        }
        private void QuanLyHocSinh_Load(object sender, EventArgs e)
        {
            FileStream f = new FileStream("hocsinh.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            ds = bf.Deserialize(f) as List<HocSinh>; //  Dữ liệu sẽ gán cho ds
            //ds = bf.Deserialize(f) as Dictionary<string,HocSinh>; DIC
            f.Close();// Đọc xong đóng file 
            ds = new List<HocSinh>();
            //ds = new Dictionary<string, HocSinh>(); // DIC // Cap phat vung nho cho Dictionary
        }



        private void hienthi()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = ds;/// Lien Ket giua ds va biding source, sau khi tao xong lien ket, tao lien ket bs => Data grid view
            // bs.DataSource = ds.Values.ToList(); //DIC // Doi Dictionary qua ListT

            dgv.DataSource = bs; /// dgv = datagridview
                                 /// tao lien ket cua tung cot + cac doi tuong cua ds(aka properties), ghi ten thuoc tinh dung de bind.
                                 /// vao Data grid box, bam vao tam giac -> edit collum, Kiem DataProperty -> viet ten thuoc tinh ( Viet dung ten thuoc tinh)
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        // Ngay 15/10/

        //// Add button add trong design, nho doi ten 
        // THEM (ADD) 
        //private void Button1Add_CheckedChanged(object sender, EventArgs e)
        //{
        //    HocSinh hs = new HocSinh();
        //    hs.mshs = textBox1.Text;
        //    hs.hoten = textBox2.Text;
        //    // hs.diachi = textBox3.Text;
        //    //hs.ngaysinh = textBoxngaysinh.Value;
        //    //hs.phai = rdioNam.Check;
              //ds.Add(maso);
        //    ds.Add(hs.mshs,hs); // Them dc 1 phan thu vao Dictionary // DIC // Phan thu nhat la key ( mshs) , hs la vung luu tru
        //    hienthi();
        //}


        // Ham Button Xoa(Code nay moi lan chi xoa dc 1)
        private void Xoabtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgv.SelectedRows)// C# co san 
            {
                string maso = r.Cells[0].Value.ToString();
                HocSinh x = null; // luc dau cho = null 
                foreach (HocSinh a in ds)
                {
                    if (a.mshs == maso)
                    {
                        x = a;
                        break;
                    }
                }
                if (x == null) // Neu ma tim thay doi tuong xoa 
                {
                    ds.Remove(x);
                    break; // sau khi xoa xong se break khong lam nua.

                }
            }
            hienthi();
        }

        // Sua trong Data Grid View
        // Ms hoc sinh la key, Ko Duoc sua Mshs! 
        // Dua vao ma so hoc sinh de tim
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgv.SelectedRows)// C# co san 
            {
                string maso = r.Cells[0].Value.ToString();
                HocSinh x = null; // luc dau cho = null 
                foreach (HocSinh a in ds)
                {
                    if (a.mshs == maso)
                    {
                        x = a;
                        break;
                    }
                }
                if (x == null) // Neu ma tim thay doi tuong thi se hien len text box cua doi tuong hs can tim

                {
                    // Ty ve add may cai text box hoten vv vao
                    /*
                     * TextBox1.Text = x.mshs;
                     * TextBox2.Text = x.hoten;
                     * TxtDiachi.Text = x.diachi;
                     * dtNgaySinh.Value = x.ngaysinh;
                     * if(x.phai == true) rdoNam.Checked = true;
                     * else rdoNu.Checked = true;
                    */
                    break;

                }
            }
        }

        private void GhiFile_Click(object sender, EventArgs e)
        {
            FileStream f = new FileStream("hocsinh.dat", FileMode.Create); // Tao File
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(f, ds);
            f.Close();
            MessageBox.Show("Ghi file thanh cong: ");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        //XOA
        /*private void XoabtnDICTIONARY_Click(object sender, EventArgs e) // DICTIONARY
        //{
        //    foreach (DataGridViewRow r in dgv.SelectedRows)// C# co san 
        //    {
        //        string maso = r.Cells[0].Value.ToString();
        //          if (ds.Remove(maso) == true) // Tu dong tim maso hs r xoa dựa vào key để xóa, Còn list T dựa vào đối tượng để xóa
                {
                        break;
                }
        //     
        //    }
        //          hienthi();
              }
        */
        /*
        SUA
         * DICTIONARY
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgv.SelectedRows)// C# co san 
            {
                string maso = r.Cells[0].Value.ToString();
                HocSinh x = ds[maso]; // dua tren maso lam key, 
                // sau khi tim xong se hien len hien thi cho nguoi dung
   
                     * TextBox1.Text = x.mshs;
                     * TextBox2.Text = x.hoten;
                     * TxtDiachi.Text = x.diachi;
                     * dtNgaySinh.Value = x.ngaysinh;
                     * if(x.phai == true) rdoNam.Checked = true;
                     * else rdoNu.Checked = true
                    break;

                }
            }

        SUA
         private void ButtonSua(object sender, EventArgs e)
        {
                string maso = txtmshs.Text;
                Hocsinh x = ds[maso];
                x.hoten = txtHoten.Text;
                x.diachi = txtDiaChi.Text;
                x.ngaysinh = dtNgaysinh.Value;
                x.phai = rdoNam.Checked;
                hienthi();
        }
        // try catch 22-10
         private void ButtonSua(object sender, EventArgs e)
        {
        try {
                string maso = txtmshs.Text;
                Hocsinh x = ds[maso];
                x.hoten = txtHoten.Text;
                x.diachi = txtDiaChi.Text;
                x.ngaysinh = dtNgaysinh.Value;
                x.phai = rdoNam.Checked;
                hienthi();
        }catch(WayNotFoundException ex)
            MessageBox.Show(ex.Message)
        }
    */

    }
}


