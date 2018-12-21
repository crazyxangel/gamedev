using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_Examen
{
    class Level
    {
        Random test = new Random();
        public Texture2D textureBackground;
        public Texture2D textureSolid;
        public Texture2D textureDeadly;
        private int _size;
        public Level(int Size)
        {
            _size = Size;
        }

       // 0 = background, 1 = solid, 2 = deadly
        private byte[,] layout = new byte[9, 16]
        {
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            { 0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0},
            { 0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0},
            { 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0},
            { 1,1,0,0,1,0,0,0,0,0,0,1,0,0,0,0},
            { 1,0,0,0,0,0,1,2,2,0,0,0,0,0,0,0},
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };

        public Tile[,] tileArray = new Tile[9, 16];
        //       public Rectangle[] collisionArray = new Rectangle[144];
        public List<Rectangle> collisiontiles = new List<Rectangle>();
        public void CreateLevel()
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    if (layout[y, x] == 0)
                        tileArray[y, x] = new BackgroundTile(textureBackground, new Microsoft.Xna.Framework.Vector2(x * _size, y * _size));
                    if (layout[y, x] == 1)
                        tileArray[y, x] = new SolidTile(textureSolid, new Microsoft.Xna.Framework.Vector2(x * _size, y * _size));
                    if (layout[y, x] == 2)
                        tileArray[y, x] = new DeadlyTile(textureDeadly, new Microsoft.Xna.Framework.Vector2(x * _size, y * _size));

                    if (tileArray[y, x].Collision)
                        collisiontiles.Add(new Rectangle(x*_size, y*_size, _size, 10));
                }
            }
        }

        public void DrawLevel(SpriteBatch spritebatch)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 16; x++)
                {
                    tileArray[y, x].Draw(spritebatch);
                }
            }
        }
    }
}
