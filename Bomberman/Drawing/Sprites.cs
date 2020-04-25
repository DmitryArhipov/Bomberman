using System;
using System.Drawing;
using System.IO;

namespace Bomberman
{
    public class Sprites
    {
        private static readonly string spritesFolder =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Drawing", "Images");

        private static Size SpriteSize => UnbreakableWall.Size;

        public static readonly Bitmap UnbreakableWall = 
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "UnbreakableWall.png")));
        
        public static readonly Image BreakableWall =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "BreakableWall.png")), SpriteSize);

        public static readonly Image PlayerRunningRight1 =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "running-right-1.png")), SpriteSize);

        public static readonly Image PlayerRunningRight2 =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "running-right-2.png")), SpriteSize);

        public static readonly Image PlayerRunningLeft1 =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "running-left-1.png")), SpriteSize);

        public static readonly Image PlayerRunningLeft2 =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "running-left-2.png")), SpriteSize);

        public static readonly Image Bomb =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Bomb.png")), SpriteSize);

        public static readonly Image Fire =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Fire.png")), SpriteSize);
        
        public static readonly Image Monster =
            new Bitmap(Image.FromFile(Path.Combine(spritesFolder, "Monster.png")), SpriteSize);
    }
}