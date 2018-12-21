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
		public Rectangle CollisionRect { get; set; }
		public Rectangle CollisionLethal { get; set; }
		public Rectangle LethalRect { get; set; }
		public Rectangle _showRectangle { get; set; }
		public Texture2D Texture { get; set; }
		public Vector2 Position { get; set; }
		public bool Collision { get; set; }
		public bool lethal { get; set; }
		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, Position, _showRectangle, Color.AliceBlue);
		}

	}
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
	public class Spike : Tile
	{
		public Spike(Texture2D texture, int x, int y)
		{
			Collision = true;
			lethal = true;
			Texture = texture;
			Position = new Vector2(x, y);
			CollisionRect = new Rectangle(x, y+30, 60, 30);
			CollisionLethal = new Rectangle(x, y+20, 60, 60);
			_showRectangle = new Rectangle(360, 0, 60, 60);
		}
		
	}
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
