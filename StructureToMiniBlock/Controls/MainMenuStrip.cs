using StructureToMiniBlock.App.Struture;
using StructureToMiniBlock.App.Windows;
using System;
using System.Windows.Forms;

namespace StructureToMiniBlock.Controls
{
    class MainMenuStrip : MenuStrip
	{
		public OpenFileDialog _openFileDialog;
		private MainForm _form;
		public static bool canOpenFile = true;

		public MainMenuStrip()
		{
			_openFileDialog = new OpenFileDialog();
			_openFileDialog.Filter = "NBT|*.nbt";
			Name = "MainMenuStrip";
			Dock = DockStyle.Top;
			FileDropDownMenu();
			FormatDropDownMenu();

			HandleCreated += (s, e) =>
			{
				_form = FindForm() as MainForm;
			};
		}

		public void FileDropDownMenu()
		{
			var fileDropDownMenu = new ToolStripMenuItem("Fichier");

			var newMenu = new ToolStripMenuItem("New", null, null, Keys.Control | Keys.N);
			var openMenu = new ToolStripMenuItem("Open", null, null, Keys.Control | Keys.O);
			//var saveMenu = new ToolStripMenuItem("Save", null, null, Keys.Control | Keys.S);
			//var saveAsMenu = new ToolStripMenuItem("Save As", null, null, Keys.Control | Keys.Shift | Keys.N);
			var quitMenu = new ToolStripMenuItem("Quit", null, null, Keys.Alt | Keys.F4);

			openMenu.Click += (object sender, EventArgs e) =>
			{
				if (_openFileDialog.ShowDialog() == DialogResult.OK && canOpenFile == true){

					_form.Text = $"{_openFileDialog.FileName} - StructureNBT";
					
					Structure structFunction = new Structure();
					structFunction.Launch(_openFileDialog.FileName);
					CreateForm secondForm = new CreateForm();
					secondForm.Show();
					
					canOpenFile = false;
				} else
                {
					MessageBox.Show("You can't open a file. Close the 'Make your Struture' window");
                }
			};

			quitMenu.Click += (object sender, EventArgs e) =>
			{
				_form.Close();
			};

			fileDropDownMenu.DropDownItems.AddRange(new ToolStripItem[] { newMenu, openMenu,/*saveMenu, saveAsMenu,*/ quitMenu });

			Items.Add(fileDropDownMenu);
		}

		public void FormatDropDownMenu()
		{
			var helpDropDownMenu = new ToolStripMenuItem("Help");

			var helpMenu = new ToolStripMenuItem("How to use it");
			var creditMenu = new ToolStripMenuItem("Credit");

			creditMenu.Click += (object sender, EventArgs e) =>
			{
				const string message = "Made by NoNOréo\nGithub: https://github.com/Non0reo \n\nIt's my first C# Project.. So, don't look too much into the code :3\nDo you want to see my Github?";
				const string title = "Information and Credit";

				var result = MessageBox.Show(
					message,
					title,
					MessageBoxButtons.YesNo,
					MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
					var uri = "https://github.com/Non0reo";
					var psi = new System.Diagnostics.ProcessStartInfo();
					psi.UseShellExecute = true;
					psi.FileName = uri;
					System.Diagnostics.Process.Start(psi);
				}

			};

			helpMenu.Click += (object sender, EventArgs e) =>
			{
				MessageBox.Show("• Open or Drop your .nbt file\n• Select your options and the size" +
					"" +
					" of your structure\n• Click on 'Create', select the location for the file\n• Your .mcfunction is now created!", "How to use this software");
			};

			helpDropDownMenu.DropDownItems.AddRange(new ToolStripItem[] { creditMenu, helpMenu });

			Items.Add(helpDropDownMenu);
		}

		public void openFile(bool file)
        {
				canOpenFile = file;
        }

	}	
}
