# <img src="https://user-images.githubusercontent.com/70480609/115313101-f7c29400-a172-11eb-8ac1-81c31968df69.png" width=48> MiniStructure 

### [Download link](https://github.com/Non0reo/MiniStructure/releases)

MiniStructure is a software developed in C# which been made after a map making issue. This software let you put a `.nbt` Minecraft file, select some option and get a `.mcfunction` file which, when executed, spawn a small version of your structure.
# How Make It Work?
This software is meant to be an extremely simple tool to use

* Open or Drop your `.nbt` Structure file
* Select your options and the size of your structure
* Click on <kbd>Create</kbd>, select the location for the file
* Your `.mcfunction` is now created!

<a href="https://github.com/Non0reo/MiniStructure/releases"><img src="https://i.ibb.co/2YhCqsR/Capture-d-cran-2021-04-20-184342.jpg" alt="Make Your Structure UI" border="50"></a>
![Cave_demonstration](https://user-images.githubusercontent.com/70480609/115440149-b46a3300-a20f-11eb-9006-8aef6caa0bbf.gif)

# How Does It Work?
The mini structure is made out of blocks placed on the head or in the hand of Armor Stand depending on the size you selected. The software take all of the informations of your structure and converting them to a .mcfunction file that you can execute via the /function after having put the file into a datapack. But if you use this software, you probably know how all of that works ._.

<a href="https://github.com/Non0reo/MiniStructure/releases"><img src="https://i.ibb.co/MkYgfRt/Capture-d-cran-2021-04-20-185224.jpg" alt="Size Comparison" border="0"></a>

# The Limitations

There is a lot of limitation which, I hope, will be corrected in the future...

For now, only the `facing` and `type` blockstate works. `facing` only works for block which can be rotated to the south, west, east and north. There is right now no up or down compatibility (so, for example, piston or upside down stairs won't work). However, `type` blockstate works as well!

All block that have no render in hand like water, cocoa, piston head, corner stairs or also lit redstone lamps won't be present and converted on the structure (But there will still have an Armor Stand in the emplacement)

# Project Things
It's my first C# Project, and It's also my First Coding Project at all :3
So, the code can be a little bit nasty at some point, I know. I discover C# at the same time I was making this project. So If you see some strange methods or useless variable, It's alright, It's ignorance

