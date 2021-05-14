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
	public partial class Customers : Form
	{
		string path = @"Data Source=LAPTOP-JNKLH8V1;Initial Catalog=InventorySystem;Integrated Security=True";
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adpt;
		DataTable dt;
		SqlDataAdapter adpt1;
		DataTable dt1;
		SqlDataAdapter adpt2;
		DataTable dt2;

		public Customers()
		{
			InitializeComponent();
			con = new SqlConnection(path);
			display();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			All a2 = new All();
			a2.Show();
			this.Hide();
		}

		private void label9_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (txtCuid.Text == "" || txtCuname.Text == "" || txtCunumber.Text == "")
			{
				MessageBox.Show("Enter Required Fields");
			}
			else
			{
				try
				{
					con.Open();
					cmd = new SqlCommand("insert into Customers (Customer_ID,Customer_Name,Phone_Number) values ('" + txtCuid.Text + "','" + txtCuname.Text + "','" + txtCunumber.Text + "')", con);
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
			txtCuid.Text = "";
			txtCuname.Text = "";
			txtCunumber.Text = "";
		}

		public void display()
		{
			try
			{
				dt = new DataTable();
				con.Open();
				adpt = new SqlDataAdapter("select * from Customers", con);
				adpt.Fill(dt);
				DGV2.DataSource = dt;
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
				if (txtCuid.Text == "" || txtCuname.Text == "" || txtCunumber.Text == "")
				{
					MessageBox.Show("Enter Required Fields");
				}
				else
				{
					con.Open();
					cmd = new SqlCommand("update Customers set Customer_Name='"+ txtCuname.Text + "' , Phone_Number='" + txtCunumber.Text + "' where Customer_ID='" + txtCuid.Text + "' ", con);
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
				if (txtCuid.Text == "")
				{
					MessageBox.Show("Select the Customer to Delete");
				}
				else
				{
					con.Open();
					cmd = new SqlCommand("delete from Customers where Customer_ID='" + txtCuid.Text + "' ", con);
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

		private void DGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			txtCuid.Text = DGV2.SelectedRows[0].Cells[0].Value.ToString();
			txtCuname.Text = DGV2.SelectedRows[0].Cells[1].Value.ToString();
			txtCunumber.Text = DGV2.SelectedRows[0].Cells[2].Value.ToString();
			con.Open();
			adpt = new SqlDataAdapter("select Count(*) from Orders where Customer_ID='" + txtCuid.Text + "' ", con);
			dt = new DataTable();
			adpt.Fill(dt);
			lblCount.Text = dt.Rows[0][0].ToString();

			adpt1 = new SqlDataAdapter("select sum(Total_Amount) from Orders where Customer_ID='" + txtCuid.Text + "' ", con);
			dt1 = new DataTable();
			adpt1.Fill(dt1);
			lblAmount.Text = dt1.Rows[0][0].ToString();

			adpt2 = new SqlDataAdapter("select Max(Order_Date) from Orders where Customer_ID='" + txtCuid.Text + "' ", con);
			dt2 = new DataTable();
			adpt2.Fill(dt2);
			lblDate.Text = dt2.Rows[0][0].ToString();
			con.Close();
		}
	}
}
