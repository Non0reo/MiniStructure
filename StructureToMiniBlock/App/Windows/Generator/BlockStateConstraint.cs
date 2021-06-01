using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using fNbt;

namespace StructureToMiniBlock.App.Windows.Generator
{
    class BlockStateConstraint
    {

        public List<string> BlockStates(string file, int i)
        {
            var myFile = new NbtFile();
            myFile.LoadFromFile(file);
            var myCompTag = myFile.RootTag;
            NbtList block = myFile.RootTag.Get<NbtList>("palette");
            List<string> listblock = new List<string>();

            listblock.Add(block.Get<NbtCompound>(i).Get<NbtString>("Name").StringValue);


            if (block.Get<NbtCompound>(i).Get<NbtCompound>("Properties").Contains("facing") == true)
            {
                listblock.Add(block.Get<NbtCompound>(i).Get<NbtCompound>("Properties").Get<NbtString>("facing").StringValue);
            } else
            {
                listblock.Add("null");
            }

            if (block.Get<NbtCompound>(i).Get<NbtCompound>("Properties").Contains("type") == true)
            {
                listblock.Add(block.Get<NbtCompound>(i).Get<NbtCompound>("Properties").Get<NbtString>("type").StringValue);
            }
            else
            {
                listblock.Add("null");
            }

            if (block.Get<NbtCompound>(i).Get<NbtCompound>("Properties").Contains("rotation") == true)
            {
                listblock.Add(block.Get<NbtCompound>(i).Get<NbtCompound>("Properties").Get<NbtString>("rotation").StringValue);
            }
            else
            {
                listblock.Add("null");
            }

            if (block.Get<NbtCompound>(i).Get<NbtCompound>("Properties").Contains("snowy") == true)
            {
                listblock.Add(block.Get<NbtCompound>(i).Get<NbtCompound>("Properties").Get<NbtString>("snowy").StringValue);
            }
            else
            {
                listblock.Add("null");
            }

            if (block.Get<NbtCompound>(i).Get<NbtCompound>("Properties").Contains("half") == true)
            {
                listblock.Add(block.Get<NbtCompound>(i).Get<NbtCompound>("Properties").Get<NbtString>("half").StringValue);
            }
            else
            {
                listblock.Add("null");
            }

            if (block.Get<NbtCompound>(i).Get<NbtCompound>("Properties").Contains("axis") == true)
            {
                listblock.Add(block.Get<NbtCompound>(i).Get<NbtCompound>("Properties").Get<NbtString>("axis").StringValue);
            }
            else
            {
                listblock.Add("null");
            }

            return listblock;  
        } 


        public string ChangeFacing(string block)
        {
            switch (block)
            {
                case "east":
                    return "south";
                case "west":
                    return "north";
                case "north":
                    return "east";
                case "south":
                    return "west";
                default:
                    return "north";
            }
        }
        public string ChangeFacingStairs(string block)
        {
            switch (block)
            {
                case "east":
                    return "north";
                case "west":
                    return "south";
                case "north":
                    return "west";
                case "south":
                    return "east";
                default:
                    return "south";
            }
        }

        //Facing
        public double MoveBlockDueToFacingX(double x, ArrayList block, int where)
        {
            switch (block[where + 4])
            {
                case "east":
                    x += -0.925;
                    return x;
                case "west":
                    x += -0.4;
                    return x;
                case "north":
                    x += -1.325;
                    return x;
                case "south":
                    return x;
                default:
                    return x;
            }
        }

        public double MoveBlockDueToFacingZ(double z, ArrayList block, int where)
        {
            switch (block[where + 4])
            {
                case "east":
                    z += -0.4;
                    return z;
                case "west":
                    z += 0.925;
                    return z;
                case "north":
                    z += 0.525;
                    return z;
                case "south":
                    return z;
                default:
                    return z;
            }
        }

        public double MoveMiniBlockDueToFacingX(double x, ArrayList block, int where)
        {
            switch (block[where + 4])
            {
                case "east":
                    x += -0.4635;
                    return x;
                case "west":
                    x += -0.2;
                    return x;
                case "north":
                    x += -0.663;
                    return x;
                case "south":
                    return x;
                default:
                    return x;
            }
        }

        public double MoveMiniBlockDueToFacingZ(double z, ArrayList block, int where)
        {
            switch (block[where + 4])
            {
                case "east":
                    z += -0.2;
                    return z;
                case "west":
                    z += 0.4635;
                    return z;
                case "north":
                    z += 0.262;
                    return z;
                case "south":
                    return z;
                default:
                    return z;
            }
        }

        //Rotation
        public double MoveBigBlockDueToRotationX(double x, ArrayList block, int where)
        {
            switch (block[where + 6])
            {
                //south
                case "0":
                case "8":
                    return x;
                case "1":
                case "9":
                    x += -0.1;
                    return x;
                case "2":
                case "10":
                    x += -0.195;
                    return x;
                case "3":
                case "11":
                    x += -0.26;
                    return x;
                //west
                case "4":
                case "12":
                    x += -0.275;
                    return x;
                case "5":
                case "13":
                    x += -0.26;
                    return x;
                case "6":
                case "14":
                    x += -0.2;
                    return x;
                case "7":
                case "15":
                    x += -0.1;
                    return x;

                default:
                    return x;
            }
        }

        public double MoveBigBlockDueToRotationZ(double z, ArrayList block, int where)
        {
            switch (block[where + 6])
            {
                //south
                case "0":
                case "8":
                    return z;
                case "1":
                case "9":
                    z += -0.02;
                    return z;
                case "2":
                case "10":
                    z += -0.09;
                    return z;
                case "3":
                case "11":
                    z += -0.17;
                    return z;
                //west
                case "4":
                case "12":
                    z += -0.272;
                    return z;
                case "5":
                case "13":
                    z += -0.37;
                    return z;
                case "6":
                case "14":
                    z += -0.46;
                    return z;
                case "7":
                case "15":
                    z += -0.52;
                    return z;

                default:
                    return z;
            }
        }

        public double MoveNormalBlockDueToRotationX(double x, ArrayList block, int where)
        {
            switch (block[where + 6])
            {
                //south
                case "0":
                case "8":
                    return x;
                case "1":
                case "9":
                    x += -0.0674;
                    return x;
                case "2":
                case "10":
                    x += -0.1354;
                    return x;
                case "3":
                case "11":
                    x += -0.1805;
                    return x;
                //west
                case "4":
                case "12":
                    x += -0.191;
                    return x;
                case "5":
                case "13":
                    x += -0.1805;
                    return x;
                case "6":
                case "14":
                    x += -0.1411;
                    return x;
                case "7":
                case "15":
                    x += -0.0694;
                    return x;

                default:
                    return x;

            }
        }

        public double MoveNormalBlockDueToRotationZ(double z, ArrayList block, int where)
        {
            switch (block[where + 6])
            {
                //south
                case "0":
                case "8":
                    return z;
                case "1":
                case "9":
                    z += -0.0141;
                    return z;
                case "2":
                case "10":
                    z += -0.0635;
                    return z;
                case "3":
                case "11":
                    z += -0.12;
                    return z;
                //west
                case "4":
                case "12":
                    z += -0.192;
                    return z;
                case "5":
                case "13":
                    z += -0.2611;
                    return z;
                case "6":
                case "14":
                    z += -0.3247;
                    return z;
                case "7":
                case "15":
                    z += -0.36705;
                    return z;

                default:
                    return z;
            }
        }

        public double MoveSmallBlockDueToRotationX(double x, ArrayList block, int where)
        {
            switch (block[where + 6])
            {
                //south
                case "0":
                case "8":
                    return x;
                case "1":
                case "9":
                    x += 0.19;
                    return x;
                case "2":
                case "10":
                    x += 0.32;
                    return x;
                case "3":
                case "11":
                    x += 0.3;
                    return x;
                //west
                case "4":
                case "12":
                    x += 0.19;
                    return x;
                case "5":
                case "13":
                    x += -0;
                    return x;
                case "6":
                case "14":
                    x += -0.24;
                    return x;
                case "7":
                case "15":
                    x += -0.5;
                    return x;

                default:
                    return x;
            }
        }

        public double MoveSmallBlockDueToRotationZ(double z, ArrayList block, int where)
        {
            switch (block[where + 6])
            {
                //south
                case "0":
                case "8":
                    return z;
                case "1":
                case "9":
                    z += 0.18;
                    return z;
                case "2":
                case "10":
                    z += 0.46;
                    return z;
                case "3":
                case "11":
                   z += 0.7;
                    return z;
                //west
                case "4":
                case "12":
                    z += 0.937;
                    return z;
                case "5":
                case "13":
                    z += 1.13;
                    return z;
                case "6":
                case "14":
                    z += 1.252;
                    return z;
                case "7":
                case "15":
                    z += 1.23;
                    return z;

                default:
                    return z;
            }
        }

        public double MoveMiniBlockDueToRotationX(double x, ArrayList block, int where)
        {
            switch (block[where + 6])
            {
                //south
                case "0":
                case "8":
                    return x;
                case "1":
                case "9":
                    x += 0.095;
                    return x;
                case "2":
                case "10":
                    x += 0.16;
                    return x;
                case "3":
                case "11":
                    x += 0.15;
                    return x;
                //west
                case "4":
                case "12":
                    x += 0.095;
                    return x;
                case "5":
                case "13":
                    x += -0;
                    return x;
                case "6":
                case "14":
                    x += -0.12;
                    return x;
                case "7":
                case "15":
                    x += -0.25;
                    return x;

                default:
                    return x;
            }
        }

        public double MoveMiniBlockDueToRotationZ(double z, ArrayList block, int where)
        {
            switch (block[where + 6])
            {
                //south
                case "0":
                case "8":
                    return z;
                case "1":
                case "9":
                    z += 0.09;
                    return z;
                case "2":
                case "10":
                    z += 0.23;
                    return z;
                case "3":
                case "11":
                    z += 0.35;
                    return z;
                //west
                case "4":
                case "12":
                    z += 0.4685;
                    return z;
                case "5":
                case "13":
                    z += 0.565;
                    return z;
                case "6":
                case "14":
                    z += 0.626;
                    return z;
                case "7":
                case "15":
                    z += 0.615;
                    return z;

                default:
                    return z;
            }
        }



        public string RotateArmorStandHead(ArrayList block, int where)
        {
            switch (block[where + 4])
            {
                case "east":
                    return ",Rotation:[-90f]";
                case "west":
                    return ",Rotation:[90f]";
                case "north":
                    return ",Rotation:[180f]";
                case "south":
                    return "";
                default:
                    return "";
            }
        }

        public string RotateArmorStandArm(ArrayList block, int where)
        {
            switch (block[where + 4])
            {
                case "east":
                    return ",Rotation:[-90f]";
                case "west":
                    return ",Rotation:[90f]";
                case "north":
                    return ",Rotation:[180f]";
                case "south":
                    return "";
                default:
                    return "";
            }
        }

        public string RotateArmorStandSign(ArrayList block, int where)
        {
            switch (block[where + 6])
            {
                case "0":
                case "8":
                    return "";
                case "1":
                case "9":
                    return ",Rotation:[22.5f]";
                case "2":
                case "10":
                    return ",Rotation:[45f]";
                case "3":
                case "11":
                    return ",Rotation:[67.5f]";
                case "4":
                case "12":
                    return ",Rotation:[90f]";
                case "5":
                case "13":
                    return ",Rotation:[112.5f]";
                case "6":
                case "14":
                    return ",Rotation:[135f]";
                case "7":
                case "15":
                    return ",Rotation:[157.5f]";
                default:
                    return "";
            }
        }

        public double SlabType(byte size)
        {
            double temp = 0.3125;

                switch (size)
                {
                    case 1:
                        temp = 0.3125;
                    break;
                    case 2:
                        temp = 0.21875;
                    break;
                    case 3:
                        temp = 0.18725;
                    break;
                    case 4:
                        temp = 0.0937;
                    break;
                }

            return temp;
        }

        public string RotateSigns(ArrayList block, int where)
        {
            switch (block[where + 4])
            {
                case "east":
                    return ",Rotation:[-90f]";
                case "west":
                    return ",Rotation:[90f]";
                case "north":
                    return ",Rotation:[180f]";
                case "south":
                    return "";
                default:
                    return "";
            }
        }

        /*public double MoveFlatItem(double x, ArrayList block, int where, byte paramSize)
        {
            switch (paramSize)
            {
                case 1:
                    break;
            } 
        }*/
    }
}
