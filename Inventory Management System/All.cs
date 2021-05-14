using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_System
{
	public partial class All : Form
	{
		public All()
		{
			InitializeComponent();
		}

		private void label9_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Log l1 = new Log();
			l1.Show();
			this.Hide();
		}

		private void label4_Click(object sender, EventArgs e)
		{
			Products p1 = new Products();
			p1.Show();
			this.Hide();
		}

		private void label5_Click(object sender, EventArgs e)
		{
			Users u1 = new Users();
			u1.Show();
			this.Hide();
		}

		private void label7_Click(object sender, EventArgs e)
		{
			Categories cat1 = new Categories();
			cat1.Show();
			this.Hide();
		}

		private void label8_Click(object sender, EventArgs e)
		{
			Orders o1 = new Orders();
			o1.Show();
			this.Hide();
		}

		private void label6_Click(object sender, EventArgs e)
		{
			Customers cus1 = new Customers();
			cus1.Show();
			this.Hide();
		}
	}
}
