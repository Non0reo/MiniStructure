using System;
using System.Windows.Forms;
using StructureToMiniBlock.Controls;

namespace StructureToMiniBlock.App.Windows
{
    public partial class CreateForm : Form
    {
        Generator.Generator generator = new Generator.Generator();
        public static bool noGrav = true;
        public static bool marker = true;
        public CreateForm _form;
        public CreateForm()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var structFunction = new Generator.Generator();
            structFunction.generateSize(comboBox1.Text);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var structFunction = new Struture.Structure();
            structFunction.getBlock();
            this.Close();
            MessageBox.Show("Your file have been created!");
        }

        private void paramNoGravity_CheckedChanged(object sender, EventArgs e)
        {
            if(noGrav == true)
            {
                generator.noGrav(0);
            } else
            {
                generator.noGrav(1);
            }
            noGrav = !noGrav;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (marker == true)
            {
                generator.mark(0);
            }
            else
            {
                generator.mark(1);
            }
            marker = !marker;
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {
            generator.noGrav(1);
            generator.mark(1);
        }


        private void CreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var allowDrop = new MainForm();
            allowDrop.AllowDrop = true;
            var canOpen = new MainMenuStrip();
            canOpen.openFile(true);
        }
    }
}
