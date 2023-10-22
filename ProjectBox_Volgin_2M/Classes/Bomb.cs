using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectBox_Volgin_2M.Classes.Interfaces;

namespace ProjectBox_Volgin_2M.Classes
{
    public class Bomb : Item
    {
        public Bomb(double speed) : base(speed)
        {
        }
    }
}
