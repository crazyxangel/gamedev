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
		#region variables and objects
		private Texture2D _texture { get; set; }
		private int _size = 60;
		private level1 level1 = new level1();
		private level2 level2 = new level2();
		private byte[,] layout = new byte[17, 32];
		#endregion
		/// <summary>
		/// Constructor of the level requires the spritesheet of the tiles
		/// </summary>
		/// <param name="texture"></param>
		public Level(Texture2D texture)
		{
			_texture = texture;
		}


		///
		public Tile[,] tileArray1 = new Tile[17, 32];
		public List<Rectangle> collisionTiles = new List<Rectangle>();
		public List<Rectangle> collisionLethal = new List<Rectangle>();
		/// <summary>
		/// Here we'll translate the layout array of bytes into the corresponding tiles and fill up the collision list
		/// </summary>
		public void CreateLevel(int level)
		{
			if (level == 1)
				layout = level1.layout;
			if (level == 2)
				layout = level2.layout;
			for (int y = 0; y < 17; y++)
			{
				for (int x = 0; x < 32; x++)
				{
					switch (layout[y, x])
					{
						case 0:
							tileArray1[y, x] = new BackgroundTile(_texture, x * _size, y * _size);
							break;
						case 1:
							tileArray1[y, x] = new Solidtop(_texture, x * _size, y * _size);
							break;
						case 2:
							tileArray1[y, x] = new Solidleft(_texture, x * _size, y * _size);
							break;
						case 3:
							tileArray1[y, x] = new Solidright(_texture, x * _size, y * _size);
							break;
                        case 4:
                            tileArray1[y, x] = new SolidtopL(_texture, x * _size, y * _size);
                            break;
                        case 5:
							tileArray1[y, x] = new SolidtopR(_texture, x * _size, y * _size);
							break;
                        case 6:
							tileArray1[y, x] = new Spike(_texture, x * _size, y * _size);
							break;
						case 7:
							tileArray1[y, x] = new Acid(_texture, x * _size, y * _size);
							break;
						case 8:
							tileArray1[y, x] = new Spikeflip(_texture, x * _size, y * _size);
							break;
						default:
							break;
					}
					if (tileArray1[y, x].Collision)
					{
						collisionTiles.Add(tileArray1[y, x].CollisionRect);
						if (tileArray1[y, x].CollisionRect2 != null)
							collisionTiles.Add(tileArray1[y, x].CollisionRect2);
					}
					if (tileArray1[y, x].lethal)
						collisionLethal.Add(tileArray1[y, x].CollisionLethal);
				}
			}
		}
		/// <summary>
		/// Here we'll put the tiles on screen
		/// </summary>
		/// <param name="spritebatch"></param>
		public void DrawLevel(SpriteBatch spritebatch)
		{
			for (int y = 0; y < 17; y++)
			{
				for (int x = 0; x < 32; x++)
				{
						tileArray1[y, x].Draw(spritebatch);
				}
			}
		}
	}
}
