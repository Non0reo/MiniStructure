using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StructureToMiniBlock
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			Controls.MainMenuStrip menuStrip = new Controls.MainMenuStrip();
			Controls.Add(menuStrip);
		}

		private void mainMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}
	}
}
