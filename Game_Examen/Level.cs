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
		private byte[,] layout = new byte[17, 32]
	{
            //0: Background, 1: SolidTop, 2: SolidLeft, 3: SolidRight, 4: SolidTopLeft, 5: SolidTopRight, 6: Spike, 7: Acid, 8: RoofSpike
            { 4,1,1,1,1,1,5,1,4,1,1,1,1,1,1,1   ,1,1,1,1,1,1,1,5,1,4,1,1,1,1,1,5},
			{ 2,0,0,0,0,0,0,8,0,0,0,0,0,0,0,0   ,0,0,0,0,0,0,0,0,8,0,0,0,0,0,0,3},
			{ 2,0,8,0,0,6,0,0,0,3,0,0,0,0,0,1   ,1,0,0,0,0,0,2,0,0,0,6,0,0,8,0,3},
			{ 2,0,0,0,1,1,5,0,0,3,0,0,2,3,0,0   ,0,0,2,3,0,0,2,0,0,4,1,1,0,0,0,3},
			{ 2,2,0,0,0,0,3,0,0,3,0,0,6,0,0,0   ,0,0,0,6,0,0,2,0,0,2,0,0,0,0,3,3},
			{ 2,0,0,0,0,0,0,5,6,3,0,0,5,7,4,0   ,0,5,7,4,0,0,2,6,4,0,0,0,0,0,0,3},
			{ 2,6,2,3,6,0,1,1,5,0,8,0,0,1,0,3   ,2,0,1,0,0,8,0,4,1,1,0,6,2,3,6,3},
			{ 4,5,7,7,4,0,0,0,3,0,0,5,0,0,0,0   ,0,0,0,0,4,0,0,2,0,0,0,5,7,7,4,5},
			{ 4,8,8,1,5,7,2,0,0,8,2,3,0,0,1,0   ,0,1,0,0,2,3,8,0,0,3,7,4,1,8,8,5},
			{ 2,0,0,0,0,1,5,7,2,0,2,0,5,0,0,2   ,3,0,0,4,0,3,0,3,7,4,1,0,0,0,0,3},
			{ 2,1,5,6,0,0,0,5,0,0,2,0,0,1,0,0   ,0,0,1,0,0,3,0,0,4,0,0,0,6,4,1,3},
			{ 2,0,0,1,5,6,0,3,0,8,5,6,0,6,0,0   ,0,0,6,0,6,4,8,0,2,0,6,4,1,0,0,3},
			{ 2,5,0,0,0,5,0,6,0,0,0,5,0,8,1,0   ,0,1,8,0,4,0,0,0,6,0,4,0,0,0,4,3},
			{ 7,7,7,4,0,3,0,1,8,1,0,3,0,0,0,0   ,0,0,0,0,2,0,1,8,1,0,2,0,5,7,7,7},
			{ 4,8,1,0,0,4,0,0,0,0,3,3,0,0,0,3   ,2,0,0,0,2,2,0,0,0,0,5,0,0,1,8,5},
			{ 2,0,0,0,6,2,0,0,1,0,0,3,0,3,0,0   ,0,0,2,0,2,0,0,1,0,0,3,6,0,0,0,3},
			{ 1,5,7,4,1,1,5,7,7,7,4,1,5,7,7,7   ,7,7,7,4,1,5,7,7,7,4,1,1,5,7,4,1},
	};
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
		public Tile[,] tileArray = new Tile[17, 32];
		public List<Rectangle> collisionTiles = new List<Rectangle>();
		public List<Rectangle> collisionLethal = new List<Rectangle>();
		/// <summary>
		/// Here we'll translate the layout array of bytes into the corresponding tiles and fill up the collision list
		/// </summary>
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
						case 8:
							tileArray[y, x] = new Spikeflip(_texture, x * _size, y * _size);
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
					tileArray[y, x].Draw(spritebatch);
				}
			}
		}
	}
}
