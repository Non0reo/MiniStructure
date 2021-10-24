using StructureToMiniBlock.App.Windows;
using System;
using System.Windows.Forms;

namespace StructureToMiniBlock
{
    public partial class MainForm : Form
	{
		public static int tempo = 0;

		public MainForm()
		{
			InitializeComponent();
			Controls.MainMenuStrip menuStrip = new Controls.MainMenuStrip();
			Controls.Add(menuStrip);

			this.AllowDrop = true;
			this.DragEnter += new DragEventHandler(MainForm_DragEnter);
			this.DragDrop += new DragEventHandler(MainForm_DragDrop);
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

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {

			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			if (tempo == 0)
			{
				if (/*_openFileDialog.ShowDialog() == DialogResult.OK &&*/ StructureToMiniBlock.Controls.MainMenuStrip.canOpenFile == true)
				{


					if (files.Length > 1)
					{
						MessageBox.Show("Please put only one file at the time");
					}
					else
					{
						foreach (var file in files)
						{
							//MessageBox.Show(file);
							this.AllowDrop = false;
							App.Struture.Structure structFunction = new App.Struture.Structure();
							structFunction.Launch(file);
							CreateForm secondForm = new CreateForm();
							secondForm.Show();
						}
						var strip = new Controls.MainMenuStrip();
						strip.openFile(false);
						this.AllowDrop = true;
					}
					
				}
				else MessageBox.Show("You can't open a file. Close the 'Make your Struture' window");
				tempo = 1;
			}
			else tempo = 0;


		}

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
		}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
