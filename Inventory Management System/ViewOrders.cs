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
	public partial class ViewOrders : Form
	{
		string path = @"Data Source=LAPTOP-JNKLH8V1;Initial Catalog=InventorySystem;Integrated Security=True";
		SqlConnection con;
		SqlCommand cmd;
		SqlDataAdapter adpt;
		DataTable dt;

		public ViewOrders()
		{
			InitializeComponent();
			con = new SqlConnection(path);
			display();
		}

		private void label9_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			All a9 = new All();
			a9.Show();
			this.Hide();
		}

		public void display()
		{
			try
			{
				dt = new DataTable();
				con.Open();
				adpt = new SqlDataAdapter("select * from Orders", con);
				adpt.Fill(dt);
				DGV8.DataSource = dt;
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Orders o6 = new Orders();
			o6.Show();
			this.Hide();
		}

		private void DGV8_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
			{
				printDocument1.Print();
			}
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			e.Graphics.DrawString("Order Summary", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Black, new Point(230));

			e.Graphics.DrawString("Order ID : " + DGV8.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.RoyalBlue, new Point(100, 70));

			e.Graphics.DrawString("Customer ID : " + DGV8.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.RoyalBlue, new Point(100, 100));

			e.Graphics.DrawString("Customer Name : " + DGV8.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.RoyalBlue, new Point(100, 130));

			e.Graphics.DrawString("Order Date : " + DGV8.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.RoyalBlue, new Point(100, 160));

			e.Graphics.DrawString("Total Amount : RS." + DGV8.SelectedRows[0].Cells[4].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.RoyalBlue, new Point(100, 190));

			e.Graphics.DrawString("Thank You !", new Font("Century Gothic", 20, FontStyle.Italic), Brushes.RoyalBlue, new Point(230, 250));
		}
	}
}
