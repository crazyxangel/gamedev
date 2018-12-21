using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_Examen
{
	public class Player
	{

		public Vector2 Position { get; set; }
		public Texture2D Texture { get; set; }
		public TimeSpan Duration { get; set; }

		private bool cLeft;
		private bool cRight;
		private bool cDown;
		private bool cUp;
		private bool left = false;
		private bool right = true;
		private bool jump = false;
		private bool time = false;

		public int positionleft = 60;
		public int positionalt = 420;

		public int acceleration = 0;

		public int accelerationjump = 15;

		private Rectangle _showRectangle;

		private Rectangle _collisionleft;
		private Rectangle _collisionright;
		private Rectangle _collisionup;
		private Rectangle _collisiondown;

		private Rectangle _idleframeL;
		private Rectangle _idleframeR;

		private Animation _animationright;
		private Animation _animationleft;
		private Animation _animationjumpL;
		private Animation _animationjumpR;
		private Animation _animationfall;


		private Controls _controls;
		private List<Rectangle> collision = new List<Rectangle>();

		private Rectangle[] collisionarray = new Rectangle[144];

		public Player(Texture2D texture, int player, List<Rectangle> list)
		{

			collision = list;
			collision.ToArray();

			if (player == 1)
				_controls = new ControlP1();

			if (player == 2)
				_controls = new ControlP2();

			#region Animation left
			_animationleft = new Animation();
			_animationleft.AddFrame(new Rectangle(0, 120, 60, 60));
			_animationleft.AddFrame(new Rectangle(60, 120, 60, 60));
			_animationleft.AddFrame(new Rectangle(120, 120, 60, 60));
			_animationleft.AddFrame(new Rectangle(180, 120, 60, 60));
			_animationleft.AddFrame(new Rectangle(240, 120, 60, 60));
			_animationleft.AddFrame(new Rectangle(300, 120, 60, 60));
			_animationleft.AddFrame(new Rectangle(360, 120, 60, 60));
			_animationleft.AddFrame(new Rectangle(420, 120, 60, 60));
			Texture = texture;
			_animationleft.MovesaSecond = 16;
			#endregion

			#region Animation right
			_animationright = new Animation();
			_animationright.AddFrame(new Rectangle(0, 60, 60, 60));
			_animationright.AddFrame(new Rectangle(60, 60, 60, 60));
			_animationright.AddFrame(new Rectangle(120, 60, 60, 60));
			_animationright.AddFrame(new Rectangle(180, 60, 60, 60));
			_animationright.AddFrame(new Rectangle(240, 60, 60, 60));
			_animationright.AddFrame(new Rectangle(300, 60, 60, 60));
			_animationright.AddFrame(new Rectangle(360, 60, 60, 60));
			_animationright.AddFrame(new Rectangle(420, 60, 60, 60));
			Texture = texture;
			_animationright.MovesaSecond = 16;
			#endregion

			#region Animation jump R
			_animationjumpR = new Animation();
			_animationjumpR.AddFrame(new Rectangle(0, 0, 60, 60));
			_animationjumpR.AddFrame(new Rectangle(60, 0, 60, 60));
			_animationjumpR.AddFrame(new Rectangle(120, 0, 60, 60));
			_animationjumpR.AddFrame(new Rectangle(180, 0, 60, 60));
			_animationjumpR.AddFrame(new Rectangle(240, 0, 60, 60));
			_animationjumpR.AddFrame(new Rectangle(300, 0, 60, 60));
			_animationjumpR.AddFrame(new Rectangle(360, 0, 60, 60));
			_animationjumpR.AddFrame(new Rectangle(420, 0, 60, 60));
			Texture = texture;
			_animationjumpR.MovesaSecond = 4;
			#endregion

			#region Animation jump L
			_animationjumpL = new Animation();
			_animationjumpL.AddFrame(new Rectangle(0, 180, 60, 60));
			_animationjumpL.AddFrame(new Rectangle(60, 180, 60, 60));
			_animationjumpL.AddFrame(new Rectangle(120, 180, 60, 60));
			_animationjumpL.AddFrame(new Rectangle(180, 180, 60, 60));
			_animationjumpL.AddFrame(new Rectangle(240, 180, 60, 60));
			_animationjumpL.AddFrame(new Rectangle(300, 180, 60, 60));
			_animationjumpL.AddFrame(new Rectangle(360, 180, 60, 60));
			_animationjumpL.AddFrame(new Rectangle(420, 180, 60, 60));
			Texture = texture;
			_animationjumpL.MovesaSecond = 4;
			#endregion

			#region Animation fall
			_animationfall = new Animation();
			_animationfall.AddFrame(new Rectangle(240, 0, 60, 60));
			_animationfall.AddFrame(new Rectangle(0, 0, 60, 60));
			_animationfall.AddFrame(new Rectangle(240, 0, 60, 60));
			_animationfall.AddFrame(new Rectangle(0, 0, 60, 60));
			Texture = texture;
			_animationfall.MovesaSecond = 4;
			#endregion
			
			_idleframeL = new Rectangle(60, 240, 60, 60);
			_idleframeR = new Rectangle(0, 240, 60, 60);

			_showRectangle = new Rectangle(0, 0, 60, 60);
		}

		public virtual void Update(GameTime gameTime)
		{
			movement(gameTime);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			if (left)
				_showRectangle = _idleframeL;

			if (right)
				_showRectangle = _idleframeR;

			if (_controls.left)
				_showRectangle = _animationleft.CurrentFrame.SourceRectangle;

			if (_controls.right)
				_showRectangle = _animationright.CurrentFrame.SourceRectangle;

			if (_controls.up && left)
				_showRectangle = _animationjumpL.CurrentFrame.SourceRectangle;

			if (_controls.up && right)
				_showRectangle = _animationjumpR.CurrentFrame.SourceRectangle;

			if (!collisiondown() && !_controls.up)
				_showRectangle = _animationfall.CurrentFrame.SourceRectangle;

			spriteBatch.Draw(Texture, new Vector2(positionleft, positionalt), _showRectangle, Color.AliceBlue);
		}
		#region Collision
		public bool collisionleft()
		{
			cLeft = false;
			_collisionleft = new Rectangle(positionleft + 10, positionalt, 10, 30);
			foreach (Rectangle item in collision)
			{
				if (item.Intersects(_collisionleft))
					cLeft = true;
			}
			return cLeft;
		}
		public bool collisionright()
		{
			cRight = false;
			_collisionright = new Rectangle(positionleft + 40, positionalt, 10, 30);
			foreach (Rectangle item in collision)
			{
				if (item.Intersects(_collisionright))
					cRight = true;
			}
			return cRight;
		}
		public bool collisionup()
		{
			cUp = false;
			_collisionup = new Rectangle(positionleft +20, positionalt -10, 20, 10);
			foreach (Rectangle item in collision)
			{
				if (item.Intersects(_collisionup))
					cUp = true;
			}
			return cUp;
		}
		public bool collisiondown()
		{
			cDown = false;
			_collisiondown = new Rectangle(positionleft + 20, positionalt + 55, 20, 15);
			foreach (Rectangle item in collision)
			{
				if (item.Intersects(_collisiondown))
				{
					cDown = true;
					positionalt = item.Y - 56;
				}
			}
			return cDown;
		}
		#endregion

		public void movement(GameTime gameTime)
		{
			_controls.Update();
			if (!collisiondown() && !jump)
			{
				positionalt += 1 * acceleration;
				_animationfall.Update(gameTime);
				if (acceleration < 15)
					acceleration += 1;
			}

			if (collisiondown())
				acceleration = 1;

			if(accelerationjump == 0)
				{
				accelerationjump = 15;
				jump = false;
				}

			if (_controls.left)
			{
				left = true;
				right = false;
				if (!collisionleft())
					positionleft -= 5;

				_animationleft.Update(gameTime);
			}

			if (_controls.right)
			{
				left = false;
				right = true;

				if (!collisionright())
					positionleft += 5;

				_animationright.Update(gameTime);
			}
			if (_controls.up && !jump && !collisionup() &&collisiondown())
				jump = true;
			if (left)
				_animationjumpL.Update(gameTime);
			if (right)
				_animationjumpR.Update(gameTime);

			if (jump)
			{
				if(jump)
				{
					if(!collisionup())
					positionalt -= 1*accelerationjump;
					_animationfall.Update(gameTime);
					if (accelerationjump > 0)
						accelerationjump -= 1;
				}
			}
		}
	}
}
