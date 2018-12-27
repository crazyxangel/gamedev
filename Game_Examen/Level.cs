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
		//Random test = new Random();
		private Texture2D _texture { get; set; }
		private int _size = 60;
		public Level(Texture2D texture)
		{
			_texture = texture;
		}


		private byte[,] layout = new byte[17, 32]
        {
            //0: Background, 1: SolidTop, 2: SolidLeft, 3: SolidRight, 4: SolidTopLeft, 5: SolidTopRight, 6: Spike, 7: Acid
            { 4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5},
            { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,0,0,0,0,0,0,0,6,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 2,0,0,6,4,1,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3},
            { 1,1,1,1,1,1,1,1,1,1,1,1,5,7,7,7,7,4,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
        };
		public Tile[,] tileArray = new Tile[17, 32];
		public List<Rectangle> collisionTiles = new List<Rectangle>();
		public List<Rectangle> collisionLethal = new List<Rectangle>();
		public void CreateLevel()
		{
			for (int y = 0; y < 17; y++)
			{
				for (int x = 0; x < 32; x++)
				{
					switch (layout[y, x])
					{
						case 0:
							tileArray[y, x] = new BackgroundTile(_texture, x * _size, y * _size);
							break;
						case 1:
							tileArray[y, x] = new Solidtop(_texture, x * _size, y * _size);
							break;
						case 2:
							tileArray[y, x] = new Solidleft(_texture, x * _size, y * _size);
							break;
						case 3:
							tileArray[y, x] = new Solidright(_texture, x * _size, y * _size);
							break;
                        case 4:
                            tileArray[y, x] = new SolidtopL(_texture, x * _size, y * _size);
                            break;
                        case 5:
                            tileArray[y, x] = new SolidtopR(_texture, x * _size, y * _size);
                            break;
                        case 6:
							tileArray[y, x] = new Spike(_texture, x * _size, y * _size);
							break;
                        case 7:
                            tileArray[y, x] = new Acid(_texture, x * _size, y * _size);
                            break;
                        default:
							break;
					}
					if (tileArray[y, x].Collision)
						collisionTiles.Add(tileArray[y, x].CollisionRect);
					if (tileArray[y, x].lethal)
						collisionLethal.Add(tileArray[y, x].CollisionLethal);
				}
			}
		}

		public void DrawLevel(SpriteBatch spritebatch)
		{
			for (int y = 0; y < 17; y++)
			{
				for (int x = 0; x < 32; x++)
				{
					tileArray[y, x].Draw(spritebatch);
				}
			}
		}
	}
}
