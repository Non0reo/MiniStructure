using fNbt;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using StructureToMiniBlock.App.Windows.Generator;

namespace StructureToMiniBlock.App.Struture
{
    public class Structure
    {
        public static int[] size = new int[3];
        public static int count;
        public string [] data = new string[11];
        public List<List<string>> palette = new List<List<string>>();
        //public List<string> palette = new List<string>();
        //public List<string> blockAndNbt = new List<string>();
        //public List<string> temporary = new List<string>();
        public static ArrayList block = new ArrayList();

        public void Launch(string file)
        {
            Size(file);
            Palette(file);
            Block(file);
        }

        public void Size(string file)
        {
            var myFile = new NbtFile();
            myFile.LoadFromFile(file);
            var myCompTag = myFile.RootTag;
            NbtList list = myFile.RootTag.Get<NbtList>("size");

            for (int i = 0; i < 3; i++)
            {
                size[i] = list.Get<NbtInt>(i).IntValue;
                //MessageBox.Show(size[i].ToString());
            }
            count = size[0] * size[1] * size[2];
        }

        public void Palette(string file)
        {
            var myFile = new NbtFile();
            myFile.LoadFromFile(file);
            var myCompTag = myFile.RootTag;
            NbtList block = myFile.RootTag.Get<NbtList>("palette");

            for (int i = 0; i < block.Count; i++)
            {
                if (block.Get<NbtCompound>(i).Contains("Properties") == true)
                { 
                    BlockStateConstraint bSC = new BlockStateConstraint();
                    palette.Add(bSC.BlockStates(file, i));
                }
                else
                {
                    palette.Add(new List<string> { block.Get<NbtCompound>(i).Get<NbtString>("Name").StringValue, "null", "null", "null", "null", "null", "null", "null" });
                }
            }
        }

        public void Block(string file)
        {
            var myFile = new NbtFile();
            myFile.LoadFromFile(file);
            var myCompTag = myFile.RootTag;
            NbtList entries = myFile.RootTag.Get<NbtList>("blocks");
            // Y :
            for (int i = 0; i < size[1]; i++)
            {
                // Z :
                for (int j = 0; j < size[2]; j++)
                {
                    // X :
                    for (int k = 0; k < size[0]; k++)
                    {
                        for (int l = 0; l < count; l++)
                        {
                            NbtList pos = entries.Get<NbtCompound>(l).Get<NbtList>("pos");
                            if (pos.Get<NbtInt>(0).IntValue == k
                                && pos.Get<NbtInt>(1).IntValue == i
                                && pos.Get<NbtInt>(2).IntValue == j)
                            {
                                int state = entries.Get<NbtCompound>(l).Get<NbtInt>("state").IntValue;
                                //MessageBox.Show(state.ToString());
                                data[0] = k.ToString();
                                data[1] = i.ToString();
                                data[2] = j.ToString();
                                data[3] = palette[state][0];
                                data[4] = palette[state][1];
                                data[5] = palette[state][2];
                                data[6] = palette[state][3];
                                data[7] = palette[state][4];
                                data[8] = palette[state][5];
                                data[9] = palette[state][6];
                                data[10] = palette[state][7];

                                block.AddRange(data);
                            } 
                        }
                    }
                }
            }
            
            /*for (int i = 0; i < (count*4); i++)
            {
                MessageBox.Show((string)block[i] + " :" + i);
            }*/
        }

        public void getBlock()
        {
            var gen = new Windows.Generator.Generator();
            gen.createFile(size, block, count, (int)data.Length);
        }

        public void reset()
        {
            block.RemoveRange(0, block.Count);
            palette.RemoveRange(0, palette.Count);
        }

        /*public bool testNbt(string file)
        {
            var myFile = new NbtFile();
            myFile.LoadFromFile(file);
            NbtList block = myFile.RootTag.Get<NbtList>("palette");
            NbtCompound nbtBlock = block.Get<NbtCompound>(1);

            NbtString exist;
            if (myFile.RootTag.TryGet.TryGet<NbtString>("facing", out exist) == true)
            {
                return true;
            } else
            {
                return false;
            }
        }*/
    }
}
