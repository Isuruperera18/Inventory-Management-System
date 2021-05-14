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
	public partial class Categories : Form
	{
		string path = @"Data Source=LAPTOP-JNKLH8V1;Initial Catalog=InventorySystem;Integrated Security=True";
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adpt;
		DataTable dt;

		public Categories()
		{
			InitializeComponent();
			con = new SqlConnection(path);
			display();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			All a3 = new All();
			a3.Show();
			this.Hide();
		}

		private void label9_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (txtCaid.Text == "" || txtCaname.Text == "")
			{
				MessageBox.Show("Enter Required Fields");
			}
			else
			{
				try
				{
					con.Open();
					cmd = new SqlCommand("insert into Categories (Category_ID,Category_Name) values ('" + txtCaid.Text + "','" + txtCaname.Text + "')", con);
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

		public void clear()
		{
			txtCaid.Text = "";
			txtCaname.Text = "";
		}

		public void display()
		{
			try
			{
				dt = new DataTable();
				con.Open();
				adpt = new SqlDataAdapter("select * from Categories", con);
				adpt.Fill(dt);
				DGV3.DataSource = dt;
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
				if (txtCaid.Text == "" || txtCaname.Text == "")
				{
					MessageBox.Show("Enter Required Fields");
				}
				else
				{
					con.Open();
					cmd = new SqlCommand("update Categories set Category_Name='" + txtCaname.Text + "' where Category_ID='" + txtCaid.Text + "' ", con);
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

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtCaid.Text == "")
				{
					MessageBox.Show("Select the Category to Delete");
				}
				else
				{
					con.Open();
					cmd = new SqlCommand("delete from Categories where Category_ID='" + txtCaid.Text + "' ", con);
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

		private void DGV3_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			txtCaid.Text = DGV3.SelectedRows[0].Cells[0].Value.ToString();
			txtCaname.Text = DGV3.SelectedRows[0].Cells[1].Value.ToString();
		}
	}
}
