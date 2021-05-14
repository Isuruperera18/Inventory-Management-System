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
	public partial class Users : Form
	{
		string path = @"Data Source=LAPTOP-JNKLH8V1;Initial Catalog=InventorySystem;Integrated Security=True";
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adpt;
		DataTable dt;

		public Users()
		{
			InitializeComponent();
			con = new SqlConnection(path);
			display();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			All a1 = new All();
			a1.Show();
			this.Hide();
		}

		private void label9_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		public void clear()
		{
			txtUsuname.Text = "";
			txtUsfname.Text = "";
			txtUspword.Text = "";
			txtUsnumber.Text = "";
		}

		public void display()
		{
			try
			{
				dt = new DataTable();
				con.Open();
				adpt = new SqlDataAdapter("select * from Users", con);
				adpt.Fill(dt);
				DGV1.DataSource = dt;
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtUsuname.Text == "" || txtUsfname.Text == "" || txtUspword.Text == "" || txtUsnumber.Text == "")
				{
					MessageBox.Show("Enter Required Fields");
				}
				else
				{
					con.Open();
					cmd = new SqlCommand("update Users set Full_Name='" + txtUsfname.Text + "' , User_Password='" + txtUspword.Text + "' , Phone_Number='" + txtUsnumber.Text + "' where Username='" + txtUsuname.Text + "' ", con);
					cmd.ExecuteNonQuery();
					con.Close();
					MessageBox.Show("Data has been updated");
					clear();
					display();
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			if (txtUsuname.Text == "" || txtUsfname.Text == "" || txtUspword.Text == "" || txtUsnumber.Text == "")
			{
				MessageBox.Show("Enter Required Fields");
			}
			else
			{
				try
				{
					con.Open();
					cmd = new SqlCommand("insert into Users (Username,Full_Name,User_Password,Phone_Number) values ('" + txtUsuname.Text + "','" + txtUsfname.Text + "','" + txtUspword.Text + "','" + txtUsnumber.Text + "')", con);
					cmd.ExecuteNonQuery();
					con.Close();
					MessageBox.Show("Data has been saved");
					clear();
					display();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtUsuname.Text == "")
				{
					MessageBox.Show("Select the User to Delete");
				}
				else
				{
					con.Open();
					cmd = new SqlCommand("delete from Users where Username='" + txtUsuname.Text + "' ", con);
					cmd.ExecuteNonQuery();
					con.Close();
					MessageBox.Show("Data has been deleted");
					clear();
					display();
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			txtUsuname.Text = DGV1.SelectedRows[0].Cells[0].Value.ToString();
			txtUsfname.Text = DGV1.SelectedRows[0].Cells[1].Value.ToString();
			txtUspword.Text = DGV1.SelectedRows[0].Cells[2].Value.ToString();
			txtUsnumber.Text = DGV1.SelectedRows[0].Cells[3].Value.ToString();
		}
	}
}
