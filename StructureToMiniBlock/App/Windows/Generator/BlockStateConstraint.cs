using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace StructureToMiniBlock.App.Windows.Generator
{
    class BlockStateConstraint
    {
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



    }
}
