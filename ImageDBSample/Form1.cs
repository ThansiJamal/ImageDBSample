using ImageFS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageDBSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            picP1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(@"Server = DESKTOP-1GLFNAF\SQLEXPRESS; Database =ImageDB; trusted_connection = true");
            connect.Open();
            SqlCommand cmd = new SqlCommand("ImageStringSave", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ImageString", ImageProcessing.ImageToBase64(picP1.Image, ImageFormat.Png));
            cmd.ExecuteNonQuery();
            MessageBox.Show("saved");
            connect.Close();

        }
    }
}
