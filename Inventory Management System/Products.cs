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
	public partial class Products : Form
	{
		string path = @"Data Source=LAPTOP-JNKLH8V1;Initial Catalog=InventorySystem;Integrated Security=True";
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adpt;
		DataTable dt;
		SqlDataReader dr;

		public Products()
		{
			InitializeComponent();
			con = new SqlConnection(path);
			display();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			All a4 = new All();
			a4.Show();
			this.Hide();
		}

		private void label9_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void fillcombo()
		{
			try
			{
				//This method will bind the combobox with the Database
				con.Open();
				cmd = new SqlCommand("select Category_Name from Categories", con);
				dr = cmd.ExecuteReader();
				dt = new DataTable();
				dt.Columns.Add("Category_Name", typeof(string));
				dt.Load(dr);
				cbPrcat.ValueMember = "Category_Name";
				cbPrcat.DataSource = dt;
				con.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void Products_Load(object sender, EventArgs e)
		{
			fillcombo();
			fillcombo1();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (txtPrid.Text == "" || txtPrname.Text == "" || txtPrquty.Text == "" || txtPrprice.Text == "" || txtPrdesc.Text == "")
			{
				MessageBox.Show("Enter Required Fields");
			}
			else
			{
				try
				{
					con.Open();
					cmd = new SqlCommand("insert into Products (Product_ID,Product_Name,Quantity,Price,Product_Description,Category) values ('" + txtPrid.Text + "','" + txtPrname.Text + "','" + txtPrquty.Text + "','" + txtPrprice.Text + "', '" + txtPrdesc.Text + "','" + cbPrcat.SelectedValue.ToString() + "')", con);
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
			txtPrid.Text = "";
			txtPrname.Text = "";
			txtPrquty.Text = "";
			txtPrprice.Text = "";
			txtPrdesc.Text = "";
		}

		public void display()
		{
			try
			{
				dt = new DataTable();
				con.Open();
				adpt = new SqlDataAdapter("select * from Products", con);
				adpt.Fill(dt);
				DGV4.DataSource = dt;
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
				if (txtPrid.Text == "" || txtPrname.Text == "" || txtPrquty.Text == "" || txtPrprice.Text == "" || txtPrdesc.Text == "")
				{
					MessageBox.Show("Enter Required Fields");
				}
				else
				{
					con.Open();
					cmd = new SqlCommand("update Products set Product_Name='" + txtPrname.Text + "' , Quantity='" + txtPrquty.Text + "', Price='" + txtPrprice.Text + "', Product_Description='" + txtPrdesc.Text + "', Category='" + cbPrcat.SelectedValue.ToString() + "' where Product_ID='" + txtPrid.Text + "' ", con);
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
				if (txtPrid.Text == "")
				{
					MessageBox.Show("Select the Product to Delete");
				}
				else
				{
					con.Open();
					cmd = new SqlCommand("delete from Products where Product_ID='" + txtPrid.Text + "' ", con);
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

		private void DGV4_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			txtPrid.Text = DGV4.SelectedRows[0].Cells[0].Value.ToString();
			txtPrname.Text = DGV4.SelectedRows[0].Cells[1].Value.ToString();
			txtPrquty.Text = DGV4.SelectedRows[0].Cells[2].Value.ToString();
			txtPrprice.Text = DGV4.SelectedRows[0].Cells[3].Value.ToString();
			txtPrdesc.Text = DGV4.SelectedRows[0].Cells[4].Value.ToString();
			cbPrcat.SelectedValue = DGV4.SelectedRows[0].Cells[5].Value.ToString();
		}

		private void cbPrSearchcat_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				dt = new DataTable();
				con.Open();
				adpt = new SqlDataAdapter("select * from Products where Category='" + cbPrSearchcat.SelectedValue.ToString() + "' ", con);
				adpt.Fill(dt);
				DGV4.DataSource = dt;
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void fillcombo1()
		{
			//This method will bind the combobox with the Database
			con.Open();
			cmd = new SqlCommand("select Category_Name from Categories", con);
			dr = cmd.ExecuteReader();
			dt = new DataTable();
			dt.Columns.Add("Category_Name", typeof(string));
			dt.Load(dr);
			cbPrSearchcat.ValueMember = "Category_Name";
			cbPrSearchcat.DataSource = dt;
			con.Close();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			display();
		}
	}
}
