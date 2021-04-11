using StructureToMiniBlock.App.Struture;
using StructureToMiniBlock.Controls;
using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace StructureToMiniBlock.App.Windows.Generator
{
    class Generator
    {
        public static double constant = 1.6;
        public static byte noGravity = 1;
        public static byte marker = 1;
        public static byte small;
        public static byte onArm;
        public SaveFileDialog saveFileDialog;
        const string pose = "Pose:{LeftArm:[360f,0f,0f],RightArm:[345f,45f,0f]}";
        Structure structure = new Structure();

        public void noGrav(byte num)
        {
            noGravity = num;
        }
        public void mark(byte num)
        {
            marker = num;
        }

        public void generateSize(string mode)
        {
            switch (mode)
            {
                case "Big (0.625 block)":
                    constant = 1.6;
                    onArm = 0;
                    small = 0;
                    break;
                case "Normal (0.4375 block)":
                    constant = 2.2857142857142857142857;
                    onArm = 0;
                    small = 1;
                    break;
                case "Small (0.3745 block)":
                    constant = 2.670226969;
                    onArm = 1;
                    small = 0;
                    break;
                case "Mini (0.1874 block)":
                    constant = 5.336179296;
                    onArm = 1;
                    small = 1;
                    break;

            }
        }



        public void createFile(int[] size, ArrayList block, int count)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Place your file somewere";
            saveFileDialog.Filter = "mcfunction|*.mcfunction";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                
                try
                { 
                    using (FileStream fs = File.Create(path))
                    {

                        byte[] info2 = new UTF8Encoding(true).GetBytes("###################################################################################\n##																				 ##\n##     Made with the MiniStrucure generator - by NoNOréo                         ##\n##																				 ##\n###################################################################################\n\n");
                        fs.Write(info2, 0, info2.Length);

                        for (int i = 0; i < (count*4); i = i + 4)
                        {
                            if (block[i+3].ToString() != "minecraft:air") {
                                string x = (float.Parse((string)block[i]) / constant).ToString();
                                string y = (float.Parse((string)block[i + 1]) / constant).ToString();
                                string z = (float.Parse((string)block[i + 2]) / constant).ToString();

                                string data = block[i + 3].ToString();
                                byte[] info = new UTF8Encoding(true).GetBytes("summon armor_stand ~" + x.Replace(",", ".") + " ~" + y.Replace(",", ".") + " ~" + z.Replace(",", ".") + " {Invisible:1b,Invulnerable:1b,PersistenceRequired:1b,NoBasePlate:1b,Small:" + small + "b,NoGravity:" + noGravity + "b,Marker:" + marker + "b,");
                                fs.Write(info, 0, info.Length);
                                if (onArm == 0) {
                                    info = new UTF8Encoding(true).GetBytes("ArmorItems:[{},{},{},{id:\"" + data.Remove(0, 10) + "\",Count:1b}],DisabledSlots:4144959}\n");
                                    fs.Write(info, 0, info.Length);
                                } else
                                {
                                    info = new UTF8Encoding(true).GetBytes("HandItems:[{},{id:\"" + data.Remove(0, 10) + "\",Count:1b}],DisabledSlots:4144959," + pose + "}\n");
                                    fs.Write(info, 0, info.Length);
                                }
                            } else
                            {
                                continue;
                            }
                        }
                        MessageBox.Show("test 1");
                        var allowDrop = new MainForm();
                        allowDrop.AllowDrop = true;
                        var canOpen = new MainMenuStrip();
                        canOpen.openFile(true);
                        var secondForm = new StructureToMiniBlock.App.Windows.CreateForm();
                        secondForm.stop(true);
                        MessageBox.Show("test 2");
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}