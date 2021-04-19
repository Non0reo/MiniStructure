using StructureToMiniBlock.App.Struture;
using StructureToMiniBlock.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
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
        public static byte paramSize = 1;
        public SaveFileDialog saveFileDialog;
        const string pose = "Pose:{LeftArm:[360f,0f,0f],RightArm:[345f,45f,0f]}";
        BlockStateConstraint constraint = new BlockStateConstraint();
        SpecialBlocks specialBlocks = new SpecialBlocks();

        public void noGrav(byte num)
        { noGravity = num; }
        public void mark(byte num)
        { marker = num; }

        public void generateSize(string mode)
        {
            switch (mode)
            {
                case "Big (0.625 block)":
                    constant = 1.6;
                    onArm = 0;
                    small = 0;
                    paramSize = 1;
                    break;
                case "Normal (0.4375 block)":
                    constant = 2.2857142857142857142857;
                    onArm = 0;
                    small = 1;
                    paramSize = 2;
                    break;
                case "Small (0.3745 block)":
                    constant = 2.67022696929238985313751668891;
                    onArm = 1;
                    small = 0;
                    paramSize = 3;
                    break;
                case "Mini (0.1874 block)":
                    constant = 5.3361792956243329775880469;
                    onArm = 1;
                    small = 1;
                    paramSize = 4;
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
                var nbt = new ArrayList();
                
                try
                { 
                    using (FileStream fs = File.Create(path))
                    {

                        byte[] info2 = new UTF8Encoding(true).GetBytes("###################################################################################\n##																				 ##\n##     Made with the MiniStrucure generator - by NoNOréo                         ##\n##																				 ##\n###################################################################################\n\n");
                        fs.Write(info2, 0, info2.Length);

                        for (int i = 0; i < (count*6); i = i + 6)
                        {
                            if (block[i+3].ToString().Contains("minecraft:air") == false) {
                                if (block[i + 3].ToString().Contains("minecraft:cave_air") == false)
                                {
                                    double x = float.Parse((string)block[i]) / constant;
                                    double y = float.Parse((string)block[i + 1]) / constant;
                                    double z = float.Parse((string)block[i + 2]) / constant;

                                    if (block[i + 3].ToString().Contains("slab") == true) {
                                        switch (block[i + 5].ToString())
                                        {
                                            case "double":
                                                bool a = Array.Exists<string>(specialBlocks.wood, element => element.Contains(block[i + 3].ToString().Replace("_slab", "").Replace("minecraft:", "")));
                                                bool b = Array.Exists<string>(specialBlocks.withoutSlab, element => element.Contains(block[i + 3].ToString().Replace("_slab", "").Replace("minecraft:", "")));
                                                bool c = Array.Exists<string>(specialBlocks.brick, element => element.Contains(block[i + 3].ToString().Replace("_slab", "").Replace("minecraft:", "")));
                                                bool d = Array.Exists<string>(specialBlocks.slabToBlock, element => element.Contains(block[i + 3].ToString().Replace("_slab", "").Replace("minecraft:", "")));

                                                if (a == true)
                                                {
                                                    block[i + 3] = block[i + 3].ToString().Replace("slab", "planks");
                                                } if (b == true)
                                                {
                                                    block[i + 3] = block[i + 3].ToString().Replace("_slab", "");
                                                }
                                                if (c == true)
                                                {
                                                    block[i + 3] = block[i + 3].ToString().Replace("_slab", "s");
                                                }
                                                if (d == true)
                                                {
                                                    block[i + 3] = block[i + 3].ToString().Replace("_slab", "_block");
                                                }
                                                if (block[i + 3].ToString().Replace("_slab", "").Replace("minecraft:", "") == "petrified_oak")
                                                {
                                                    block[i + 3] = "minecraft:oak_planks";
                                                }
                                                if (block[i + 3].ToString().Replace("_slab", "").Replace("minecraft:", "") == "quartz")
                                                {
                                                    block[i + 3] = "minecraft:quartz_block";
                                                }

                                                break;
                                            case "top":
                                                y += constraint.SlabType(paramSize);
                                                break;
                                            case "bottom":
                                                break;
                                        }

                                    }

                                    if (onArm == 1)
                                    {
                                        if (block[i + 3].ToString().Contains("stairs") == true || block[i + 3].ToString().Contains("observer") == true)
                                        {
                                            block[i + 4] = constraint.ChangeFacingStairs(block[i + 4].ToString());
                                        }
                                        if (block[i + 3].ToString().Contains("chest") == true || block[i + 3].ToString().Contains("trapped_chest") == true)
                                        {
                                            block[i + 4] = constraint.ChangeFacing(block[i + 4].ToString());
                                        }
                                    
                                } else
                                    {
                                        if ((block[i + 3].ToString()).Contains("stairs") == true || (block[i + 3].ToString()).Contains("observer") == true)
                                        {
                                            block[i + 4] = constraint.ChangeFacingStairs(block[i + 4].ToString());
                                            block[i + 4] = constraint.ChangeFacingStairs(block[i + 4].ToString());
                                        }
                                    }

                                    if (block[i + 4].ToString() != "null" && paramSize == 3)
                                    {
                                        x = constraint.MoveBlockDueToFacingX(x, block, i);
                                        z = constraint.MoveBlockDueToFacingZ(z, block, i);
                                    }
                                    if (block[i + 4].ToString() != "null" && paramSize == 4)
                                    {
                                        x = constraint.MoveMiniBlockDueToFacingX(x, block, i);
                                        z = constraint.MoveMiniBlockDueToFacingZ(z, block, i);
                                    }

                                    string xString = x.ToString();
                                    string yString = y.ToString();
                                    string zString = z.ToString();
                                    string data = block[i + 3].ToString();
                                    byte[] info = new UTF8Encoding(true).GetBytes("summon armor_stand ~" + xString.Replace(",", ".") + " ~" + yString.Replace(",", ".") + " ~" + zString.Replace(",", ".") + " {Invisible:1b,Invulnerable:1b,PersistenceRequired:1b");
                                    fs.Write(info, 0, info.Length);
                                    string presentTags = "";
                                    if (CreateForm.tag == true)
                                    {
                                        info = new UTF8Encoding(true).GetBytes(",Tags:[\"");
                                        fs.Write(info, 0, info.Length);

                                        for (int j = 0; j < CreateForm.tagsList.Length; j++)
                                        {
                                            if (CreateForm.tagsList[j] != "")
                                            {
                                                presentTags = CreateForm.tagsList[j];
                                                info = new UTF8Encoding(true).GetBytes(presentTags.ToString().Replace(" ", "_"));
                                                fs.Write(info, 0, info.Length);
                                                if (j != CreateForm.tagsList.Length - 1)
                                                {
                                                    info = new UTF8Encoding(true).GetBytes("\",\"");
                                                    fs.Write(info, 0, info.Length);
                                                }
                                            }
                                        }
                                        info = new UTF8Encoding(true).GetBytes("\"]");
                                        fs.Write(info, 0, info.Length);
                                    }
                                    string rotation = "";
                                    if (block[i + 4].ToString() != "null" && onArm == 0)
                                    {
                                        rotation = constraint.RotateArmorStandHead(block, i);
                                    }
                                    else if (block[i + 4].ToString() != "null" && onArm == 1)
                                    {
                                        rotation = constraint.RotateArmorStandArm(block, i);
                                    }
                                    info = new UTF8Encoding(true).GetBytes(rotation);
                                    fs.Write(info, 0, info.Length);

                                    info = new UTF8Encoding(true).GetBytes(",NoBasePlate:1b,Small:" + small + "b,NoGravity:" + noGravity + "b,Marker:" + marker + "b,");
                                    fs.Write(info, 0, info.Length);
                                    if (onArm == 0) {
                                        info = new UTF8Encoding(true).GetBytes("ArmorItems:[{},{},{},{id:\"" + data.Remove(0, 10) + "\",Count:1b}],DisabledSlots:4144959}\n");
                                        fs.Write(info, 0, info.Length);
                                    } else
                                    {
                                        info = new UTF8Encoding(true).GetBytes("HandItems:[{id:\"" + data.Remove(0, 10) + "\",Count:1b},{}],DisabledSlots:4144959," + pose + "}\n");
                                        fs.Write(info, 0, info.Length);
                                    }
                                } else
                                {

                                }
                            } else {

                            } 
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            var allowDrop = new MainForm();
            allowDrop.AllowDrop = true;
            var canOpen = new MainMenuStrip();
            canOpen.openFile(true);
        }
    }
}