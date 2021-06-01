using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StructureToMiniBlock.App.Windows;

namespace StructureToMiniBlock.App.Windows.Generator
{
    public partial class MoreOptionsForm : Form
    {
        public static bool team = false;
        public static bool coolPlants = false;
        public static bool toSnowBlock = true;
        public static bool fOnArmorStand = false;
        public static bool tag2 = false;
        public static string teamList = "";
        public static string[] tagsList2;
        CreateForm createForm = new CreateForm();

        public MoreOptionsForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setEverythingOK();
            createForm.setToEnabled();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (team == false)
            {
                textBox1.ReadOnly = false;
                textBox1.HideSelection = false;
                textBox1.Enabled = true;
                textBox1.BackColor = System.Drawing.Color.White;
                textBox1.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                textBox1.ReadOnly = true;
                textBox1.Enabled = false;
                textBox1.ForeColor = System.Drawing.Color.Transparent;
            }
            team = !team;
        }

        private void MoreOptionsForm_Load(object sender, EventArgs e)
        {
            if (team == false)
            {
                team = false;
                checkBox2.Checked = false;
                textBox1.ReadOnly = true;
                textBox1.Enabled = false;
            } else
            {
                team = true;
                checkBox2.Checked = true;
                textBox1.ReadOnly = false;
                textBox1.Enabled = true;
            }
            textBox1.Text = teamList;

            if (coolPlants == false) checkBox1.Checked = false;
            else checkBox1.Checked = true;

            if (toSnowBlock == false) checkBox3.Checked = false;
            else checkBox3.Checked = true;

            if (fOnArmorStand == false)
            {
                checkBox5.Enabled = false;
                richTextBox1.Enabled = false;
            }
            else
            {
                checkBox5.Enabled = true;
                richTextBox1.Enabled = true;
            }

            if (CreateForm.size == "Equal (1 block)")
            {
                if (fOnArmorStand == false) checkBox4.Checked = false;
                else checkBox4.Checked = true;

                if (tag2 == false)
                {
                    tag2 = false;
                    checkBox5.Checked = false;
                    richTextBox1.ReadOnly = true;
                    richTextBox1.Enabled = false;
                }
                else
                {
                    tag2 = true;
                    checkBox5.Checked = true;
                    richTextBox1.ReadOnly = false;
                    richTextBox1.Enabled = true;
                }
            } else
            {
                //tag2 = false;
                //fOnArmorStand = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                richTextBox1.Enabled = false;
            }
            richTextBox1.Lines = tagsList2;

        }

        private void MoreOptionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            setEverythingOK();
            createForm.setToEnabled();
        }

        public void setEverythingOK()
        {
            teamList = textBox1.Text;
            tagsList2 = richTextBox1.Lines;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            coolPlants = !coolPlants;
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            toSnowBlock = !toSnowBlock;
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            fOnArmorStand = !fOnArmorStand;
            if (fOnArmorStand == false)
            {
                checkBox5.Enabled = false;
                if (tag2 == true) richTextBox1.Enabled = false;
            } else
            {
                checkBox5.Enabled = true;
                if (tag2 == true) richTextBox1.Enabled = true;
            }
        }

        private void checkBox5_Click(object sender, EventArgs e)
        {
            if (tag2 == false)
            {
                richTextBox1.ReadOnly = false;
                richTextBox1.HideSelection = false;
                richTextBox1.Enabled = true;
                //richTextBox1.BackColor = System.Drawing.Color.White;
                //richTextBox1.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                richTextBox1.ReadOnly = true;
                richTextBox1.Enabled = false;
                //richTextBox1.ForeColor = System.Drawing.Color.Transparent;
            }
            tag2 = !tag2;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
