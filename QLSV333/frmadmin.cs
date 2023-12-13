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
    public partial class admin : Form
    {
        string strconn;
        SqlConnection con;
        SqlCommand cmd;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public admin()
        {
            InitializeComponent();
            strconn = @"Data Source=LAPTOP-Q0PAQT9D\SANGHOCSQL;Initial Catalog=QL12;Integrated Security=True";
            con = new SqlConnection(strconn);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        private void dataGridViewhocsinh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmadmin_Load(object sender, EventArgs e)
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
                txtMalop.Text = row.Cells["MaLopHoc"].Value.ToString();
            }
            con.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if ((MessageBox.Show("bạn có muốn sửa ", "thông báo ", MessageBoxButtons.YesNo) == DialogResult.Yes))
                {
                    con.Open();
                    string update = "UPDATE SinhVien SET HoTen = @HoTen, NgaySinh = @NgaySinh, GioiTinh = @GioiTinh, DiaChi = @DiaChi, MaLopHoc = @MaLopHoc " +
                        "WHERE MaSinhVien = @MaSinhVien;";
                    SqlCommand updatee = new SqlCommand(update, con);
                    updatee.Parameters.Add("@MaSinhVien", SqlDbType.VarChar);
                    updatee.Parameters["@MaSinhVien"].Value = txtMa.Text;

                    updatee.Parameters.Add("@HoTen", SqlDbType.NVarChar);
                    updatee.Parameters["@HoTen"].Value = txtten.Text;

                    updatee.Parameters.Add("@NgaySinh", SqlDbType.Date);
                    updatee.Parameters["@NgaySinh"].Value = txtNgay.Text;

                    updatee.Parameters.Add("@GioiTinh", SqlDbType.NVarChar);
                    updatee.Parameters["@GioiTinh"].Value = txtGT.Text;

                    updatee.Parameters.Add("@DiaChi", SqlDbType.NVarChar);
                    updatee.Parameters["@DiaChi"].Value = txtadd.Text;

                    updatee.Parameters.Add("@MaLopHoc", SqlDbType.VarChar);
                    updatee.Parameters["@MaLopHoc"].Value = txtMalop.Text;

                   

                    int i = updatee.ExecuteNonQuery();

                    // Kiểm tra số hàng bị ảnh hưởng và xử lý kết quả
                    if (i > 0)
                    {


                        lblbao.Text = "Sửa OK bạn đã sửa thành công";
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("có lỗi");
                }
                Filldata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("eror :" + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (chondata != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa : " + chondata + "?", "thông báo", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        con.Open();

                        string sqlQuery = "DELETE FROM SinhVien WHERE MaSinhVien = @MaSinhVien";

                        SqlCommand comm = new SqlCommand(sqlQuery, con);
                        comm.Parameters.AddWithValue("@MaSinhVien", chondata);

                        comm.ExecuteNonQuery();

                        con.Close();

                        Filldata();

                        lblbao.Text = "bạn dã xóa thành công ";
                    }
                }
                else
                {
                    lblbao.Text = "muốn xóa phải click vào dữ liệu cần xóa ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi " + ex.Message, "lỗi");
            }
            finally
            {
                con.Close();
            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            MessageBox.Show("back ", "!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.Hide();
            frmDangnhap ba = new frmDangnhap();  //chuyển form
            ba.ShowDialog(); //show hộp thoại thông báo
            this.Dispose(); //Xóa bộ nhớ
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            Filldata();
            txtMa.Text = "";
            txtten.Text = "";
            txtNgay.Text = "";
            txtGT.Text = "";
            txtadd.Text = "";
            txtMalop.Text = "";
            lblbao.Text = "Bạn vừa Reset tất cả thành công !!! ";
        }
    }
}
