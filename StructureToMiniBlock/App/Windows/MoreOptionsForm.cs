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
        public static string teamList = "";
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
            team = false;
            checkBox2.Checked = false;
            textBox1.ReadOnly = true;
            textBox1.Enabled = false;
        }

        private void MoreOptionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            setEverythingOK();
            createForm.setToEnabled();
        }

        public void setEverythingOK()
        {
            teamList = textBox1.Text;
        }


        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
