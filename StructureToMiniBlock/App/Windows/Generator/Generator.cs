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
        //~ ~0.08 ~0.192
        //~ ~0.1142 ~0.26976
        const string horizontalPose = "Pose:{LeftArm:[360f,0f,0f],RightArm:[-90f,0f,0f]}";
        //~-0.29 ~-0.38 ~-0.3
        //~-0.145 ~-0.19 ~-0.15
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
                case "Equal (1 block)":
                    constant = 1;
                    onArm = 0;
                    small = 0;
                    paramSize = 5;
                    break;

            }
        }



        public void createFile(int[] size, ArrayList block, int count, int multiplier)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Place your file somewhere";
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

                        for (int i = 0; i < (count * multiplier); i = i + multiplier)
                        {
                            if (block[i + 3].ToString().Contains("minecraft:air") == false)
                            {
                                if (block[i + 3].ToString().Contains("minecraft:cave_air") == false)
                                {
                                    double x = float.Parse((string)block[i]) / constant;
                                    double y = float.Parse((string)block[i + 1]) / constant;
                                    double z = float.Parse((string)block[i + 2]) / constant;

                                    if (paramSize != 5)
                                    {

                                        //Slab
                                        if (block[i + 3].ToString().Contains("slab") == true)
                                        {
                                            switch (block[i + 5].ToString())
                                            {
                                                case "double":
                                                    bool a = Array.Exists<string>(specialBlocks.wood, element => element.Contains(block[i + 3].ToString().Replace("_slab", "").Replace("minecraft:", "")));
                                                    bool b = Array.Exists<string>(specialBlocks.withoutSlab, element => element.Contains(block[i + 3].ToString().Replace("_slab", "").Replace("minecraft:", "")));
                                                    bool c = Array.Exists<string>(specialBlocks.brick, element => element.Contains(block[i + 3].ToString().Replace("_slab", "").Replace("minecraft:", "")));
                                                    bool d = Array.Exists<string>(specialBlocks.slabToBlock, element => element.Contains(block[i + 3].ToString().Replace("_slab", "").Replace("minecraft:", "")));

                                                    if (a == true) block[i + 3] = block[i + 3].ToString().Replace("slab", "planks");
                                                    if (b == true) block[i + 3] = block[i + 3].ToString().Replace("_slab", "");
                                                    if (c == true) block[i + 3] = block[i + 3].ToString().Replace("_slab", "s");
                                                    if (d == true) block[i + 3] = block[i + 3].ToString().Replace("_slab", "_block");

                                                    if (block[i + 3].ToString().Replace("_slab", "").Replace("minecraft:", "") == "petrified_oak") block[i + 3] = "minecraft:oak_planks";
                                                    if (block[i + 3].ToString().Replace("_slab", "").Replace("minecraft:", "") == "quartz") block[i + 3] = "minecraft:quartz_block";

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

                                        }
                                        else
                                        {
                                            if ((block[i + 3].ToString()).Contains("stairs") == true || (block[i + 3].ToString()).Contains("observer") == true)
                                            {
                                                block[i + 4] = constraint.ChangeFacingStairs(block[i + 4].ToString());
                                                block[i + 4] = constraint.ChangeFacingStairs(block[i + 4].ToString());
                                            }
                                        }


                                        //Rotation
                                        if (block[i + 6].ToString() != "null" && paramSize == 1)
                                        {
                                            x = constraint.MoveBigBlockDueToRotationX(x, block, i);
                                            z = constraint.MoveBigBlockDueToRotationZ(z, block, i);
                                        }
                                        if (block[i + 6].ToString() != "null" && paramSize == 2)
                                        {
                                            x = constraint.MoveNormalBlockDueToRotationX(x, block, i);
                                            z = constraint.MoveNormalBlockDueToRotationZ(z, block, i);
                                        }
                                        if (block[i + 6].ToString() != "null" && paramSize == 3)
                                        {
                                            x = constraint.MoveSmallBlockDueToRotationX(x, block, i);
                                            z = constraint.MoveSmallBlockDueToRotationZ(z, block, i);
                                        }
                                        if (block[i + 6].ToString() != "null" && paramSize == 4)
                                        {
                                            x = constraint.MoveMiniBlockDueToRotationX(x, block, i);
                                            z = constraint.MoveMiniBlockDueToRotationZ(z, block, i);
                                        }

                                        //~ ~0.08 ~0.192
                                        //~ ~0.1142 ~0.26976
                                        //~-0.29 ~-0.38 ~-0.3
                                        //~-0.145 ~-0.19 ~-0.15

                                        if (Array.Exists<string>(specialBlocks.flatItem, element => element.Contains(block[i + 3].ToString().Replace("minecraft:", "")) == true))
                                        {
                                            switch (paramSize)
                                            {
                                                case 1:
                                                    y += -0.5107;
                                                    z += 0.27276;
                                                    break;
                                                case 2:
                                                    y += -0.3575;
                                                    z += 0.192;
                                                    break;
                                                case 3:
                                                    x += -0.29;
                                                    y += -0.7545;
                                                    z += -0.3;
                                                    break;
                                                case 4:
                                                    x += -0.145;
                                                    y += -0.37725;
                                                    z += -0.15;
                                                    break;
                                            }
                                        }

                                        if (MoreOptionsForm.coolPlants == true && Array.Exists<string>(specialBlocks.paperPlant, element => element.Contains(block[i + 3].ToString().Replace("minecraft:", ""))) == true)
                                        {
                                            switch (paramSize)
                                            {
                                                case 1:
                                                    x += -0.195;
                                                    z += -0.1;
                                                    break;
                                                case 2:
                                                    x += -0.13879;
                                                    z += -0.06335;
                                                    break;
                                                case 3:
                                                    x += 0.29;
                                                    z += 0.43;
                                                    break;
                                                case 4:
                                                    x += 0.145;
                                                    z += 0.215;
                                                    break;
                                            }
                                        }

                                        //Facing
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



                                        if (MoreOptionsForm.toSnowBlock == true &&
                                            Array.Exists<string>(specialBlocks.transformToSnow, element => element.Contains(block[i + 3].ToString().Replace("minecraft:", ""))) == true &&
                                            block[i + 7].ToString() == "true")
                                        {
                                            block[i + 3] = "minecraft:snow_block";
                                        }

                                    }

                                    string xString = x.ToString();
                                    string yString = y.ToString();
                                    string zString = z.ToString();
                                    string data = block[i + 3].ToString();
                                    byte[] info = new UTF8Encoding(true).GetBytes("");

                                    if (paramSize != 5) info = new UTF8Encoding(true).GetBytes("summon armor_stand ~" + xString.Replace(",", ".") + " ~" + yString.Replace(",", ".") + " ~" + zString.Replace(",", ".") + " {Invisible:1b,Invulnerable:1b,NoBasePlate:1b");
                                    if (paramSize == 5 && MoreOptionsForm.fOnArmorStand == true) info = new UTF8Encoding(true).GetBytes("summon armor_stand ~" + xString.Replace(",", ".") + " ~" + yString.Replace(",", ".") + " ~" + zString.Replace(",", ".") + " {Invisible:1b,Invulnerable:1b,NoBasePlate:1b");
                                    if (paramSize == 5 && MoreOptionsForm.fOnArmorStand == false) info = new UTF8Encoding(true).GetBytes("summon falling_block ~" + xString.Replace(",", ".") + " ~" + yString.Replace(",", ".") + " ~" + zString.Replace(",", ".") + " {Invulnerable:1b,Time:-2147483648");
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
                                    if (MoreOptionsForm.team == true)
                                    {
                                        info = new UTF8Encoding(true).GetBytes(",Team:\"");
                                        fs.Write(info, 0, info.Length);

                                        info = new UTF8Encoding(true).GetBytes(MoreOptionsForm.teamList.ToString().Replace(" ", "_") + "\"");
                                        fs.Write(info, 0, info.Length);
                                    }

                                    if (paramSize != 5)
                                    {
                                        string rotation = "";
                                        //Facing &
                                        //Rotation
                                        if (block[i + 4].ToString() != "null") rotation = constraint.RotateArmorStandHead(block, i);
                                        if (block[i + 6].ToString() != "null") rotation = constraint.RotateArmorStandSign(block, i);

                                        if (MoreOptionsForm.coolPlants == true && Array.Exists<string>(specialBlocks.paperPlant, element => element.Contains(block[i + 3].ToString().Replace("minecraft:", ""))) == true)
                                            rotation = ",Rotation:[45f]";
                                        info = new UTF8Encoding(true).GetBytes(rotation);
                                        fs.Write(info, 0, info.Length);
                                        info = new UTF8Encoding(true).GetBytes(",Small:" + small + "b");
                                        fs.Write(info, 0, info.Length);

                                    }

                                    if (paramSize == 5 && MoreOptionsForm.fOnArmorStand == true) info = new UTF8Encoding(true).GetBytes(",NoGravity:" + noGravity + "b,Marker:" + marker + "b");
                                    else info = new UTF8Encoding(true).GetBytes(",NoGravity:" + noGravity + "b");
                                    fs.Write(info, 0, info.Length);

                                    if (paramSize != 5)
                                    {
                                        if (onArm == 0)
                                        {
                                            info = new UTF8Encoding(true).GetBytes("ArmorItems:[{},{},{},{id:\"" + data.Replace("minecraft:", "") + "\",Count:1b}],DisabledSlots:4144959}\n");
                                            fs.Write(info, 0, info.Length);
                                        }
                                        else
                                        {
                                            info = new UTF8Encoding(true).GetBytes("HandItems:[{id:\"" + data.Replace("minecraft:", "") + "\",Count:1b},{}],DisabledSlots:4144959,");
                                            fs.Write(info, 0, info.Length);
                                            if (Array.Exists<string>(specialBlocks.flatItem, element => element.Contains(block[i + 3].ToString().Replace("minecraft:", "")) == true))
                                            {
                                                info = new UTF8Encoding(true).GetBytes(horizontalPose + "}\n");
                                                fs.Write(info, 0, info.Length);
                                            }
                                            else
                                            {
                                                info = new UTF8Encoding(true).GetBytes(pose + "}\n");
                                                fs.Write(info, 0, info.Length);
                                            }
                                        }
                                    }
                                    else
                                    {

                                        if (paramSize == 5 && MoreOptionsForm.fOnArmorStand == true) info = new UTF8Encoding(true).GetBytes(",Passengers:[{id:\"minecraft:falling_block\",Invulnerable:1b,Time:-2147483648,NoGravity:" + noGravity + ",BlockState:{Name:\"" + data.Remove(0, 10) + "\",Properties:{");
                                        else info = new UTF8Encoding(true).GetBytes(",BlockState:{Name:\"" + data.Remove(0, 10) + "\",Properties:{");
                                        fs.Write(info, 0, info.Length);

                                        info = new UTF8Encoding(true).GetBytes("");
                                        fs.Write(info, 0, info.Length);
                                        for (int j = 4; j < multiplier; j++) 
                                        {
                                            if (block[i + j].ToString() != "null")
                                            {
                                                switch (j)
                                                {
                                                    case 4:
                                                        info = new UTF8Encoding(true).GetBytes("facing:" + block[i + j].ToString() + ",");
                                                        break;
                                                    case 5:
                                                        info = new UTF8Encoding(true).GetBytes("type:" + block[i + j].ToString() + ",");
                                                        break;
                                                    case 6:
                                                        info = new UTF8Encoding(true).GetBytes("rotation:" + block[i + j].ToString() + ",");
                                                        break;
                                                    case 7:
                                                        info = new UTF8Encoding(true).GetBytes("snowy:" + block[i + j].ToString() + ",");
                                                        break;
                                                    case 8:
                                                        info = new UTF8Encoding(true).GetBytes("half:" + block[i + j].ToString() + ",");
                                                        break;

                                                }
                                                fs.Write(info, 0, info.Length);

                                            }
                                        }

                                        if (paramSize == 5 && MoreOptionsForm.fOnArmorStand == true)  info = new UTF8Encoding(true).GetBytes("}}}]}\n");
                                        else info = new UTF8Encoding(true).GetBytes("}}}\n");
                                        fs.Write(info, 0, info.Length);
                                    }


                                    if (MoreOptionsForm.coolPlants == true && Array.Exists<string>(specialBlocks.paperPlant, element => element.Contains(block[i + 3].ToString().Replace("minecraft:", ""))) == true)
                                    {
                                        if (MoreOptionsForm.coolPlants == true && Array.Exists<string>(specialBlocks.paperPlant, element => element.Contains(block[i + 3].ToString().Replace("minecraft:", ""))) == true)
                                        {
                                            switch (paramSize)
                                            {
                                                case 1:
                                                    x += 0.39;
                                                    //z +=- -0.3657;
                                                    break;
                                                case 2:
                                                    x += 0.27758;
                                                    break;
                                                case 3:
                                                    x += -0.8;
                                                    z += -0.53;
                                                    break;
                                                case 4:
                                                    x += -0.4;
                                                    z += -0.265;
                                                    break;
                                            }
                                        }



                                        xString = x.ToString();
                                        yString = y.ToString();
                                        zString = z.ToString();
                                        info = new UTF8Encoding(true).GetBytes("summon armor_stand ~" + xString.Replace(",", ".") + " ~" + yString.Replace(",", ".") + " ~" + zString.Replace(",", ".") + " {Invisible:1b,Invulnerable:1b,PersistenceRequired:1b");
                                        fs.Write(info, 0, info.Length);
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
                                        if (MoreOptionsForm.team == true)
                                        {
                                            info = new UTF8Encoding(true).GetBytes(",Team:\"");
                                            fs.Write(info, 0, info.Length);

                                            info = new UTF8Encoding(true).GetBytes(MoreOptionsForm.teamList.ToString().Replace(" ", "_") + "\"");
                                            fs.Write(info, 0, info.Length);
                                        }
                                        info = new UTF8Encoding(true).GetBytes(",Rotation:[-45f],NoBasePlate:1b,Small:" + small + "b,NoGravity:" + noGravity + "b,Marker:" + marker + "b,");
                                        fs.Write(info, 0, info.Length);
                                        if (onArm == 0)
                                        {
                                            info = new UTF8Encoding(true).GetBytes("ArmorItems:[{},{},{},{id:\"" + data.Remove(0, 10) + "\",Count:1b}],DisabledSlots:4144959}\n");
                                            fs.Write(info, 0, info.Length);
                                        }
                                        else
                                        {
                                            info = new UTF8Encoding(true).GetBytes("HandItems:[{id:\"" + data.Remove(0, 10) + "\",Count:1b},{}],DisabledSlots:4144959,");
                                            fs.Write(info, 0, info.Length);
                                            if (Array.Exists<string>(specialBlocks.flatItem, element => element.Contains(block[i + 3].ToString().Replace("minecraft:", "")) == true))
                                            {
                                                info = new UTF8Encoding(true).GetBytes(horizontalPose + "}\n");
                                                fs.Write(info, 0, info.Length);
                                            }
                                            else
                                            {
                                                info = new UTF8Encoding(true).GetBytes(pose + "}\n");
                                                fs.Write(info, 0, info.Length);
                                            }
                                        }
                                    }
                                    else
                                    {

                                    }
                                }
                                else
                                {

                                }
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