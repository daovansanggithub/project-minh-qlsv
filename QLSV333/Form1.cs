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
    public partial class frmDangnhap : Form
    {
        string strconn;
        SqlConnection conn;
        public frmDangnhap()
        {
            InitializeComponent();
            strconn = @"Data Source=LAPTOP-Q0PAQT9D\SANGHOCSQL;Initial Catalog=QL12;Integrated Security=True";
            conn = new SqlConnection(strconn);
            conn.Open();

            conn.Close();

        }

        private void frmDangnhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            
                try
                {
                    string username = txtNDung.Text;
                    string password = txtPass.Text;
                    string query = "Select * from taikhoan where acc =@acc and pass =@pass";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@acc", SqlDbType.VarChar);
                    cmd.Parameters["@acc"].Value = username;
                    cmd.Parameters.AddWithValue("@pass", SqlDbType.VarChar);
                    cmd.Parameters["@pass"].Value = password;
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string role = reader["rolee"].ToString();
                        if (role.Equals("admin"))
                        {
                            MessageBox.Show("Đăng nhập thành công ", "!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Hide();
                            admin ad = new admin();
                            ad.ShowDialog();
                            this.Dispose();
                        }
                        else if (role.Equals("user"))
                        {
                            MessageBox.Show("Đăng nhập thành công", "!!!", MessageBoxButtons.OK, MessageBoxIcon.None);
                            this.Hide();
                            nguoidung user = new nguoidung();  //chuyển form
                            user.ShowDialog(); //show hộp thoại thông báo
                            this.Dispose(); //Xóa bộ nhớ
                        }
                        else
                        {
                            lblthongbao.Text = "Không có thông tin được nhập vào! Vui lòng điền đầy đủ thông tin ";
                        }

                    }
                    else 
                    {
                        lblthongbao.Text = "Vui lòng thêm đầy đủ và đúng thông tin ";
                    }
                    
                

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error !!! " + ex.Message, "Error !!! ");

                }
                finally
                {
                    conn.Close();
                }
            
            
        }

        private void btnth_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
