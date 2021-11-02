using System;
using System.Windows.Forms;
using StructureToMiniBlock.Controls;
using System.Collections;
using StructureToMiniBlock.App.Windows.Generator;

namespace StructureToMiniBlock.App.Windows
{
    public partial class CreateForm : Form
    {
        Generator.Generator generator = new Generator.Generator();
        AllowedChar allowedChars = new AllowedChar();
        //MoreOptionsForm moreOptionsForm = new MoreOptionsForm();
        public static bool charTestPassed = true;
        public static bool needGen = true;
        public static bool noGrav = true;
        public static bool marker = true;
        public static bool tag = false;
        public static string[] tagsList;
        public static string size = "";
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var structFunction = new Generator.Generator();
            structFunction.generateSize(comboBox1.Text);
            size = comboBox1.Text;
            button1.Enabled = true;

            /*if (comboBox1.SelectedIndex.ToString() != "") button1.Enabled = true;
            else button1.Enabled = false;*/

            /*switch (comboBox1.Text)
            {
                case "Big (0.625 block)":
                    label3.Text = "";
                    break;
                case "Normal (0.4375 block)":
                    label3.Text = "";
                    break;
                case "Small (0.3745 block)":
                    label3.Text = "Warnnig : This size may cause\nsome block rotation isssues";
                    label3.ForeColor = System.Drawing.Color.Red;
                    break;
                case "Mini (0.1874 block)":
                    label3.Text = "Warnnig : This size may cause\nsome block rotation isssues";
                    label3.ForeColor = System.Drawing.Color.Red;
                    break;

            }*/
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            charTestPassed = true;
            tagsList = richTextBox1.Lines;

            foreach (char c in String.Concat(tagsList))
            {
                if (string.Concat(allowedChars.tagsNTeam).Contains(c.ToString()) || string.Concat(allowedChars.FileName).Contains(c.ToString())) charTestPassed = true;
                else
                {
                    MessageBox.Show("Invalid Char - Please put a correct tag for your structure\n • Accepted Characters: - | + | . | _ | A-Z | a-z | 0-9");
                    charTestPassed = false;
                    break;
                }
            }
            try
            {
                foreach (char c in String.Concat(MoreOptionsForm.tagsList2))
                {
                    if (string.Concat(allowedChars.tagsNTeam).Contains(c.ToString()) || string.Concat(allowedChars.FileName).Contains(c.ToString())) charTestPassed = true;
                    else
                    {
                        MessageBox.Show("Invalid Char - Please put a correct tag for the falling blocks\n • Accepted Characters: - | + | . | _ | A-Z | a-z | 0-9");
                        charTestPassed = false;
                        break;
                    }
                }
            }
            catch
            {

            }


            try
            {
                foreach (char c in String.Concat(MoreOptionsForm.teamList))
                {
                    if (string.Concat(allowedChars.tagsNTeam).Contains(c.ToString()) || string.Concat(allowedChars.FileName).Contains(c.ToString())) charTestPassed = true;
                    else
                    {
                        MessageBox.Show("Invalid Char - Please put a correct team name for your structure\n • Accepted Characters: - | + | . | _ | A-Z | a-z | 0-9");
                        charTestPassed = false;
                        break;
                    }
                }
            } catch
            {

            }

            if (charTestPassed == true)
            {
                var structFunction = new Struture.Structure();
                structFunction.getBlock();    //Start File Generation
                if (needGen == true)
                {
                    structFunction.reset();
                    this.Close();
                }
            }



        }

        private void paramNoGravity_CheckedChanged(object sender, EventArgs e)
        {
            if (noGrav == true)
            {
                generator.noGrav(0);
            }
            else
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
            button1.Enabled = false;
            label3.Text = "";
            generator.noGrav(1);
            generator.mark(1);
            tag = false;
            checkBox2.Checked = false;
            richTextBox1.ReadOnly = true;
            richTextBox1.Enabled = false;
        }


        private void CreateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var allowDrop = new MainForm();
            allowDrop.AllowDrop = true;
            var canOpen = new MainMenuStrip();
            canOpen.openFile(true);
            var reset = new Struture.Structure();
            reset.reset();

        }

        private void CreateForm_Resize(object sender, EventArgs e)
        {
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (tag == false)
            {
                richTextBox1.ReadOnly = false;
                richTextBox1.HideSelection = false;
                richTextBox1.Enabled = true;
                richTextBox1.BackColor = System.Drawing.Color.White;
                richTextBox1.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                richTextBox1.ReadOnly = true;
                richTextBox1.Enabled = false;
                //richTextBox1.ForeColor = System.Drawing.Color.Transparent;
            }
            tag = !tag;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Enabled = false;
            Generator.MoreOptionsForm moreOptionsForm = new Generator.MoreOptionsForm();
            moreOptionsForm.ShowDialog();
            linkLabel1.Enabled = true;



        }

        public void setToEnabled()
        {
            linkLabel1.Enabled = true;
        }

    }
    
}
