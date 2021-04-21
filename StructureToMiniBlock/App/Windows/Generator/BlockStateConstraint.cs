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
