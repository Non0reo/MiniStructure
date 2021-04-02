using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using fNbt;
using StructureToMiniBlock.Controls;

namespace StructureToMiniBlock.App.Struture
{
    public class Structure
    {
        public void Size(string file)
        {
            var size = new int[3];

            var myFile = new NbtFile();
            myFile.LoadFromFile(file);
            var myCompTag = myFile.RootTag;
            NbtList list1 = myFile.RootTag.Get<NbtList>("size");

            for (int i = 0; i < 3; i++)
            {
                size[i] = list1.Get<NbtInt>(i).IntValue;
                MessageBox.Show(size[i].ToString());
            }

            //size[i] = myCompTag["size"][i].IntValue;
            //MessageBox.Show(size[0].ToString() + size[1].ToString() + size[2].ToString());
            //MessageBox.Show(intVal.ToString());
        }
    }
}
