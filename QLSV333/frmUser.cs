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
    public partial class nguoidung : Form
    {
        string strconn;
        SqlConnection con;
        SqlCommand cmd;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        public nguoidung()
        {
            InitializeComponent();
            strconn = @"Data Source=LAPTOP-Q0PAQT9D\SANGHOCSQL;Initial Catalog=QL12;Integrated Security=True";
            con = new SqlConnection(strconn);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        private void nguoidung_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(strconn);
            dataAdapter = new SqlDataAdapter("SELECT * FROM SinhVien", con);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridViewtim.DataSource = dataTable;
        }

        public void Filldata()
        {
            con.Open();
            string query = "Select * from SinhVien";
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            ad.Fill(dt);
            dataGridViewtim.DataSource = dt;
            con.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string timm = txttim.Text.Trim();

            if (!string.IsNullOrEmpty(timm))
            {
                string query = "SELECT * FROM SinhVien WHERE MaSinhVien LIKE @timm OR HoTen LIKE @timm";
                con.Open();
                SqlCommand comm = new SqlCommand(query, con);
                comm.Parameters.AddWithValue("@timm", "%" + timm + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                con.Close();

                if (dt.Rows.Count > 0)
                {
                    dataGridViewtim.DataSource = dt;
                    lbltb.Text = "Bạn đã tìm Kiếm thông tin thành công....";

                    
                }
                else
                {
                    dataGridViewtim.DataSource = null;
                    MessageBox.Show("Ko có Kêt quả");

                }
            }
            else
            {
                MessageBox.Show("vui lòng cho tôi giá trị");
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Backkkk ", "!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
            this.Hide();
            frmDangnhap B = new frmDangnhap();  //chuyển form
            B.ShowDialog(); //show hộp thoại thông báo
            this.Dispose(); //Xóa bộ nhớ
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            Filldata();
            txttim.Text = "";
        }
    }
}
