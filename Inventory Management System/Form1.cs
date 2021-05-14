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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		int startpoint = 0;
		private void timer1_Tick(object sender, EventArgs e)
		{
			startpoint += 1;
			PB1.Value = startpoint;
			if (PB1.Value == 100)
			{
				PB1.Value = 0;
				timer1.Stop();
				Log lg = new Log();
				lg.Show();
				this.Hide();
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			timer1.Start();
		}
	}
}
