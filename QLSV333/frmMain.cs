using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV333
{
    public partial class frmMain : Form
    {
        string strconn;
        SqlConnection con;
        SqlCommand cmd;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        public frmMain()
        {
            InitializeComponent();
            strconn = @"Data Source=LAPTOP-Q0PAQT9D\SANGHOCSQL;Initial Catalog=QL12;Integrated Security=True";
            con = new SqlConnection(strconn);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(strconn);
            dataAdapter = new SqlDataAdapter("SELECT * FROM SinhVien", con);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridViewhocsinh.DataSource = dataTable;
        }

        public void Filldata()
        {
            con.Open();
            string query = "Select * from SinhVien";
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridViewhocsinh.DataSource = dt;
            con.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            int er = 0;

            string mahs = txtMa.Text;
            if (mahs.Equals(""))
            {
                er++;
                lblbao.Text = "Không được để trống id ";
            }
            else
            {
                lblbao.Text = " ";
            }

            string ten = txtten.Text;
            if (ten.Equals(""))
            {
                er++;
                lblbao.Text = "Không được để trống Tên ";
            }
            else //check ID trùng
            {
                try
                {
                    con.Open();
                    string query = "select * from SinhVien where MaSinhVien = @MaSinhVien";

                    SqlCommand commcheck = new SqlCommand(query, con);
                    commcheck.Parameters.AddWithValue("@MaSinhVien", SqlDbType.Char);
                    commcheck.Parameters["@MaSinhVien"].Value = mahs;
                    SqlDataReader reader = commcheck.ExecuteReader();

                    if (reader.Read())
                    {
                        er++;
                        lblbao.Text = "Mã đã có";
                    }
                    else
                    {
                        lblbao.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error!" + ex.Message, "Error");
                }
                finally
                {
                    con.Close();
                }

            }

            string ngay = txtNgay.Text;
            string gioitinh = txtGT.Text;
            string diachi = txtadd.Text;
            string malop = txtMalop.Text;
            

            if (er == 0)
            {

                string Them = "Insert into SinhVien values (@MaSinhVien,@HoTen,@NgaySinh,@GioiTinh,@DiaChi,@MaLop)";
                con.Open();

                SqlCommand cThem = new SqlCommand(Them, con);

                cThem.Parameters.AddWithValue("@MaSinhVien", SqlDbType.VarChar);
                cThem.Parameters["@MaSinhVien"].Value = mahs;

                cThem.Parameters.AddWithValue("@HoTen", SqlDbType.NVarChar);
                cThem.Parameters["@HoTen"].Value = ten;

                cThem.Parameters.AddWithValue("@NgaySinh", SqlDbType.Date);
                cThem.Parameters["@NgaySinh"].Value = ngay;

                cThem.Parameters.AddWithValue("@GioiTinh", SqlDbType.NVarChar);
                cThem.Parameters["@GioiTinh"].Value = gioitinh;

                cThem.Parameters.AddWithValue("@DiaChi", SqlDbType.NVarChar);
                cThem.Parameters["@DiaChi"].Value = diachi;

                cThem.Parameters.AddWithValue("@MaLop", SqlDbType.VarChar);
                cThem.Parameters["@MaLop"].Value = malop;





                cThem.ExecuteNonQuery();

                con.Close();

                Filldata();

                lblbao.Text = "Bạn đã thêm thành công ";

            }
        }
        string chondata;
        private void dataGridViewhocsinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewhocsinh.Rows[e.RowIndex];
                chondata = row.Cells["MaSinhVien"].Value.ToString();
                txtMa.Text = row.Cells["MaSinhVien"].Value.ToString();
                txtten.Text = row.Cells["HoTen"].Value.ToString();
                txtNgay.Text = row.Cells["NgaySinh"].Value.ToString();
                txtGT.Text = row.Cells["GioiTinh"].Value.ToString();
                txtadd.Text = row.Cells["DiaChi"].Value.ToString();
                txtadd.Text = row.Cells["MaLopHoc"].Value.ToString();
            }
            con.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("Bạn có muốn sửa ko???", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                con.Open();
                string sua = "UPDATE SinhVien SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, MaLopHoc = @maLop" + "WHERE MaSinhVien = @MaSinhVien;";

                SqlCommand suaa = new SqlCommand(sua, con);

                suaa.Parameters.Add("@MaLopHoc", SqlDbType.VarChar);
                suaa.Parameters["@MaLopHoc"].Value = txtMa.Text;

                suaa.Parameters.Add("@HoTen", SqlDbType.NVarChar);
                suaa.Parameters["@HoTen"].Value = txtten.Text;

                suaa.Parameters.Add("@NgaySinh", SqlDbType.Date);
                suaa.Parameters["@NgaySinh"].Value = txtNgay.Text;

                suaa.Parameters.Add("@GioiTinh", SqlDbType.NVarChar);
                suaa.Parameters["@GioiTinh"].Value = txtGT.Text;

                suaa.Parameters.Add("@DiaChi", SqlDbType.NVarChar);
                suaa.Parameters["@DiaChi"].Value = txtadd.Text;

                suaa.Parameters.Add("@maLop", SqlDbType.VarChar);
                suaa.Parameters["@maLop"].Value = txtMalop.Text;

                
                int c = suaa.ExecuteNonQuery();

               
                if (c > 0)
                {
                    lblbao.Text = "Bạn đã sửa OK ";
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("có lỗi trong khi sửa");
            }
            Filldata();
        }
    }
}
