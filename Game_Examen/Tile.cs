using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Game_Examen
{
	public abstract class Tile
	{
		#region variables and objects
		public Rectangle CollisionRect { get; set; }
		public Rectangle CollisionLethal { get; set; }
		public Rectangle LethalRect { get; set; }
		public Rectangle _showRectangle { get; set; }
		public Texture2D Texture { get; set; }
		public Vector2 Position { get; set; }
		public bool Collision { get; set; }
		public bool lethal { get; set; }
		#endregion

		/// <summary>
		/// draws the individual tiles
		/// </summary>
		/// <param name="spriteBatch"></param>
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			SpriteEffects s = SpriteEffects.FlipHorizontally;
			spriteBatch.Draw(Texture, Position, _showRectangle, Color.AliceBlue);
		}

	}


	/// <summary>
	/// background tile
	/// </summary>
	public class BackgroundTile : Tile
	{
		public BackgroundTile(Texture2D texture, int x, int y)
		{
			Collision = false;
			lethal = false;
			Texture = texture;
			Position = new Vector2(x, y);
			_showRectangle = new Rectangle(300, 0, 60, 60);
		}
	}


	/// <summary>
	/// Tile with a solid top
	/// </summary>
	public class Solidtop : Tile
    {
        public Solidtop(Texture2D texture, int x, int y)
        {
            Collision = true;
            lethal = false;
            Texture = texture;
            Position = new Vector2(x, y);
            CollisionRect = new Rectangle(x, y, 60, 12);
            _showRectangle = new Rectangle(60, 0, 60, 60);
        }
	}


	/// <summary>
	/// Tile with a solid top and left side
	/// </summary>
	public class SolidtopL : Tile
    {
        public SolidtopL(Texture2D texture, int x, int y)
        {
            Collision = true;
            lethal = false;
            Texture = texture;
            Position = new Vector2(x, y);
            CollisionRect = new Rectangle(x, y, 60, 12);
            _showRectangle = new Rectangle(180, 0, 60, 60);
        }
	}


	/// <summary>
	/// Tile with a solid top and right side
	/// </summary>
	public class SolidtopR : Tile
    {
        public SolidtopR(Texture2D texture, int x, int y)
        {
            Collision = true;
            lethal = false;
            Texture = texture;
            Position = new Vector2(x, y);
            CollisionRect = new Rectangle(x, y, 60, 12);
            _showRectangle = new Rectangle(240, 0, 60, 60);
        }
    }


	/// <summary>
	/// Tile with a solid left side
	/// </summary>
	public class Solidleft : Tile
	{
		public Solidleft(Texture2D texture, int x, int y)
		{
			Collision = true;
			lethal = false;
			Texture = texture;
			Position = new Vector2(x, y);
			CollisionRect = new Rectangle(x, y, 12, 60);
			_showRectangle = new Rectangle(0, 0, 60, 60);
		}
	}



	/// <summary>
	/// Tile with a solid right side
	/// </summary>
	public class Solidright : Tile
	{
		public Solidright(Texture2D texture, int x, int y)
		{
			Collision = true;
			lethal = false;
			Texture = texture;
			Position = new Vector2(x, y);
			CollisionRect = new Rectangle(x + 48, y, 12, 60);
			_showRectangle = new Rectangle(120, 0, 60, 60);
		}
	}



	/// <summary>
	/// Spike
	/// </summary>
	public class Spike : Tile
	{
		public Spike(Texture2D texture, int x, int y)
		{
			Collision = true;
			lethal = true;
			Texture = texture;
			Position = new Vector2(x, y);
			CollisionRect = new Rectangle(x, y + 40, 60, 20);
			CollisionLethal = new Rectangle(x, y + 15, 60, 60);
			_showRectangle = new Rectangle(360, 0, 60, 60);
		}

	}



	/// <summary>
	/// Spike flipped 180°
	/// </summary>
	public class Spikeflip : Tile
	{
		public Spikeflip(Texture2D texture, int x, int y)
		{
			Collision = true;
			lethal = true;
			Texture = texture;
			Position = new Vector2(x, y);
			CollisionRect = new Rectangle(x+1, y, 58, 20);
			CollisionLethal = new Rectangle(x+5, y+15, 45, 40);
			_showRectangle = new Rectangle(480, 0, 60, 60);
		}
	}



	/// <summary>
	/// Acid tiles
	/// </summary>
	public class Acid : Tile
	{
		public Acid(Texture2D texture, int x, int y)
		{
			Collision = true;
			lethal = true;
			Texture = texture;
			Position = new Vector2(x, y);
			CollisionLethal = new Rectangle(x, y + 20, 60, 40);
			CollisionRect = new Rectangle(x, y + 58, 60, 2);
			_showRectangle = new Rectangle(420, 0, 60, 60);
		}

	}
}
