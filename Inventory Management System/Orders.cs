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
	public partial class Orders : Form
	{
		string path = @"Data Source=LAPTOP-JNKLH8V1;Initial Catalog=InventorySystem;Integrated Security=True";
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adpt;
		DataTable dt;
		SqlDataReader dr;

		public Orders()
		{
			InitializeComponent();
			con = new SqlConnection(path);
			display();
			display1();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			All a5 = new All();
			a5.Show();
			this.Hide();
		}

		private void label9_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		public void display()
		{
			try
			{
				dt = new DataTable();
				con.Open();
				adpt = new SqlDataAdapter("select * from Customers", con);
				adpt.Fill(dt);
				DGV5.DataSource = dt;
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public void display1()
		{
			try
			{
				dt = new DataTable();
				con.Open();
				adpt = new SqlDataAdapter("select * from Products", con);
				adpt.Fill(dt);
				DGV6.DataSource = dt;
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void fillcombo()
		{
			//This method will bind the combobox with the Database
			con.Open();
			cmd = new SqlCommand("select Category_Name from Categories", con);
			dr = cmd.ExecuteReader();
			dt = new DataTable();
			dt.Columns.Add("Category_Name", typeof(string));
			dt.Load(dr);
			cbOrSearchcat.ValueMember = "Category_Name";
			cbOrSearchcat.DataSource = dt;
			con.Close();
		}

		private void Orders_Load(object sender, EventArgs e)
		{
			fillcombo();
		}

		private void cbOrSearchcat_SelectionChangeCommitted(object sender, EventArgs e)
		{
			try
			{
				dt = new DataTable();
				con.Open();
				adpt = new SqlDataAdapter("select * from Products where Category='" + cbOrSearchcat.SelectedValue.ToString() + "' ", con);
				adpt.Fill(dt);
				DGV6.DataSource = dt;
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			display1();
		}

		private void DGV5_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			txtOrcuid.Text = DGV5.SelectedRows[0].Cells[0].Value.ToString();
			txtOrcuname.Text = DGV5.SelectedRows[0].Cells[1].Value.ToString();
		}

		int Order = 0, GrdTotal = 0 ;
		int Price, Totalprice, Quantity;
		string Product;
		int Stock;

		private void button3_Click(object sender, EventArgs e)
		{
			try
			{
				if (txtOrquty.Text == "")
				{
					MessageBox.Show("Enter the Quantity of Product");
				}
				else if (flag == 0)
				{
					MessageBox.Show("Select the Product");
				}
				else if (Convert.ToInt32(txtOrquty.Text) > Stock)
				{
					MessageBox.Show("No enough Stock available");
				}
				else
				{
					Quantity = Convert.ToInt32(txtOrquty.Text);

					Totalprice = Quantity * Price;

					DataGridViewRow newRow = new DataGridViewRow();
					newRow.CreateCells(DGV7);
					newRow.Cells[0].Value = Order + 1;
					newRow.Cells[1].Value = Product;
					newRow.Cells[2].Value = Quantity;
					newRow.Cells[3].Value = Price;
					newRow.Cells[4].Value = Totalprice;
					DGV7.Rows.Add(newRow);
					Order++;
					GrdTotal = GrdTotal + Totalprice;
					lblRS.Text = "" + GrdTotal;
					flag = 0;
					updateproduct();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (txtOrid.Text == "" || txtOrcuid.Text == "" || txtOrcuname.Text == "" || lblRS.Text == "")
			{
				MessageBox.Show("Enter Required Fields");
			}
			else
			{
				try
				{
					con.Open();
					cmd = new SqlCommand("insert into Orders (Order_ID,Customer_ID,Customer_Name,Order_Date,Total_Amount) values ('" + txtOrid.Text + "','" + txtOrcuid.Text + "','" + txtOrcuname.Text + "','" + Ordate.Value.ToString() + "','" + lblRS.Text + "')", con);
					cmd.ExecuteNonQuery();
					con.Close();
					MessageBox.Show("Data has been saved");
					display();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			ViewOrders vo1 = new ViewOrders();
			vo1.Show();
			this.Hide();
		}

		int flag = 0;
		private void DGV6_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			Product = DGV6.SelectedRows[0].Cells[1].Value.ToString();
			Stock= Convert.ToInt32(DGV6.SelectedRows[0].Cells[2].Value.ToString());
			//Quantity = Convert.ToInt32(txtOrquty.Text);
			Price = Convert.ToInt32(DGV6.SelectedRows[0].Cells[3].Value.ToString());
			//Totalprice = Quantity * Price;
			flag = 1;
		}

		public void updateproduct()
		{
			try
			{
				if (txtOrquty.Text == "")
				{
					MessageBox.Show("Enter Required Fields");
				}
				else
				{
					con.Open();
					int id = Convert.ToInt32(DGV6.SelectedRows[0].Cells[0].Value.ToString());
					int NewQuantity = Stock - Convert.ToInt32(txtOrquty.Text);
					cmd = new SqlCommand("update Products set Quantity='" + NewQuantity + "' where Product_ID='" + id + "' ", con);
					cmd.ExecuteNonQuery();
					con.Close();
					display1();
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
