using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using fNbt;
using StructureToMiniBlock.App.Struture;
using StructureToMiniBlock.App.Windows;
//using NbtStudio.SNBT;

namespace StructureToMiniBlock.Controls 
{
	class MainMenuStrip : MenuStrip
	{
		public OpenFileDialog _openFileDialog;
		private MainForm _form;

		public MainMenuStrip()
		{
			_openFileDialog = new OpenFileDialog();
			_openFileDialog.Filter = "NBT|*.nbt";
			Name = "MainMenuStrip";
			Dock = DockStyle.Top;
			FileDropDownMenu();
			EditDropDownMenu();
			ViewDropDownMenu();
			FormatDropDownMenu();

			HandleCreated += (s, e) =>
			{
				_form = FindForm() as MainForm;
			};
		}

		public void FileDropDownMenu()
		{
			var fileDropDownMenu = new ToolStripMenuItem("Fichier");

			var newMenu = new ToolStripMenuItem("Nouveau", null, null, Keys.Control | Keys.N);
			var openMenu = new ToolStripMenuItem("Ouvrir", null, null, Keys.Control | Keys.O);
			var saveMenu = new ToolStripMenuItem("Enregister", null, null, Keys.Control | Keys.S);
			var saveAsMenu = new ToolStripMenuItem("Enregistrer sous", null, null, Keys.Control | Keys.Shift | Keys.N);
			var quitMenu = new ToolStripMenuItem("Quitter", null, null, Keys.Alt | Keys.F4);

			openMenu.Click += async (object sender, EventArgs e) =>
			{
				if (_openFileDialog.ShowDialog() == DialogResult.OK){

					_form.Text = $"{_openFileDialog.FileName} - StructureNBT";
					
					Structure structFunction = new Structure();
					structFunction.Launch(_openFileDialog.FileName);

				}
			};

			saveMenu.Click += async (object sender, EventArgs e) =>
			{
				CreateForm secondForm = new CreateForm();
				secondForm.Show();
			};

			fileDropDownMenu.DropDownItems.AddRange(new ToolStripItem[] { newMenu, openMenu, saveMenu, saveAsMenu, quitMenu });

			Items.Add(fileDropDownMenu);
		}

		public void EditDropDownMenu()
		{
			var editDropDownMenu = new ToolStripMenuItem("Edition");

			var cancelMenu = new ToolStripMenuItem("Annuler", null, null, Keys.Control | Keys.Z);
			var restoreMenu = new ToolStripMenuItem("Restaurer", null, null, Keys.Control | Keys.Y);


			editDropDownMenu.DropDownItems.AddRange(new ToolStripItem[] { cancelMenu, restoreMenu});

			Items.Add(editDropDownMenu);
		}

		public void FormatDropDownMenu()
		{
			var helpDropDownMenu = new ToolStripMenuItem("Aide");

			var creditMenu = new ToolStripMenuItem("Crédit");


			helpDropDownMenu.DropDownItems.AddRange(new ToolStripItem[] { creditMenu });

			Items.Add(helpDropDownMenu);
		}

		public void ViewDropDownMenu()
		{
			var viewDropDownMenu = new ToolStripMenuItem("Format");

			var alwaysOnTopMenu = new ToolStripMenuItem("Toujours Devant");


			viewDropDownMenu.DropDownItems.AddRange(new ToolStripItem[] { alwaysOnTopMenu });

			Items.Add(viewDropDownMenu);
		}



		/*public static NbtFile CreateFromSnbt(string path)
		{
			using (var stream = File.OpenRead(path))
			using (var reader = new StreamReader(stream, Encoding.UTF8))
			{
				char[] firstchar = new char[1];
				reader.ReadBlock(firstchar, 0, 1);
				if (firstchar[0] != '{') // optimization to not load in huge files
					throw new FormatException("File did not begin with a '{'");
				var text = firstchar[0] + reader.ReadToEnd();
				var tag = SnbtParser.Parse(text, named: false);
				if (!(tag is NbtCompound compound))
					throw new FormatException("File did not contain an NBT compound");
				compound.Name = "";
				var file = new fNbt.NbtFile(compound);
				return new NbtFile(path);
			}
		}*/
	}

	
}
