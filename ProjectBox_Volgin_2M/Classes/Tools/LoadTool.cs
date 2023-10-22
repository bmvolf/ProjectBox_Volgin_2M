using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ProjectBox_Volgin_2M.Classes.Tools
{
    public static class LoadTool
    {
        private static string itemName;
        private static string backGroundName;
        private static string playerName;
        private static string bombName;
        private static string hpName;
        private static string darkBg;

        private static Texture2D itemTexture;
        private static Texture2D backGroundTexture;
        private static Texture2D playerTexture;
        private static Texture2D bombTexture;
        private static Texture2D hpTexture;
        private static Texture2D darkBgTexture;

        public static Texture2D ItemTexture { get { return itemTexture; } }
        public static Texture2D BombTexture { get { return bombTexture; } }
        public static Texture2D PlayerTexture { get { return playerTexture; } }
        public static Texture2D BackGroundTexture { get { return backGroundTexture; } }
        public static Texture2D HpTexture { get { return hpTexture; } }
        public static Texture2D DarkBgTexture { get { return darkBgTexture; } }

        public static void Initialize()
        {
            itemName = "Banana";
            backGroundName = "Background";
            playerName = "Box";
            bombName = "Bomb";
            hpName = "HP";
            darkBg = "darkBg";
        }

        public static void LoadAllTextures(ContentManager content)
        {
            itemTexture = content.Load<Texture2D>(itemName);
            backGroundTexture = content.Load<Texture2D>(backGroundName);
            playerTexture = content.Load<Texture2D>(playerName);
            bombTexture = content.Load<Texture2D>(bombName);
            hpTexture = content.Load<Texture2D>(hpName);
            darkBgTexture = content.Load<Texture2D>(darkBg);
        }
    }
}
