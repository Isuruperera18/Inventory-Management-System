using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory_Management_System
{
	public partial class Log : Form
	{
		string path = @"Data Source=LAPTOP-JNKLH8V1;Initial Catalog=InventorySystem;Integrated Security=True";
		SqlConnection con;
		SqlDataAdapter adpt;
		DataTable dt;

		public Log()
		{
			InitializeComponent();
			con = new SqlConnection(path);
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				txtPWord.UseSystemPasswordChar = false;
			}
			else
			{
				txtPWord.UseSystemPasswordChar = true;
			}
		}

		private void label4_Click(object sender, EventArgs e)
		{
			txtUName.Text = "";
			txtPWord.Text = "";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				con.Open();
				adpt = new SqlDataAdapter("select Count(*) from Users where Username='" + txtUName.Text + "' and User_Password='" + txtPWord.Text + "' ", con);
				dt = new DataTable();
				adpt.Fill(dt);

				if(dt.Rows[0][0].ToString()=="1")
				{
					All a10 = new All();
					a10.Show();
					this.Hide();
				}
				else
				{
					MessageBox.Show("Enter Correct Cerdentials");
				}
				con.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void label9_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
