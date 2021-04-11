using fNbt;
using System.Collections;
using System.Collections.Generic;

namespace StructureToMiniBlock.App.Struture
{
    public class Structure
    {
        public static int[] size = new int[3];
        public static int count;
        public string [] data = new string[4];
        public List<string> palette = new List<string>();
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
                palette.Add(block.Get<NbtCompound>(i).Get<NbtString>("Name").StringValue);
                //MessageBox.Show(palette[i].ToString());
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
                                string state = entries.Get<NbtCompound>(l).Get<NbtInt>("state").IntValue.ToString();
                                //MessageBox.Show(state.ToString());
                                data[0] = k.ToString();
                                data[1] = i.ToString();
                                data[2] = j.ToString();
                                data[3] = palette[int.Parse(state)];
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
            gen.createFile(size, block, count);
        }
    }
}
