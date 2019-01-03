using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Examen
{
    class Tagger
	{
		#region variables and objects
		private int _positionX;
        private int _positionY;

        private Rectangle _crownrect;
        private Rectangle _P1;
        private Rectangle _P2;

        public bool ownedP1 { get; set; }
        public bool ownedP2 { get; set; }

        Texture2D texture;
		#endregion


		/// <summary>
		/// sets the crown starting position and texture
		/// </summary>
		/// <param name="t"></param>
		public Tagger(Texture2D t)
        {
            texture = t;
            _positionY = 60;//  |||
            _positionX = 950;//  ___
            _crownrect = new Rectangle(_positionX, _positionY, 20, 20);
        }


		/// <summary>
		/// Updates the game with both player rectangles to see if they touch the crown, and if they do to follow the player
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
        public void update(Rectangle p1, Rectangle p2)
        {
            _P1 = p1;
            _P2 = p2;
            if (_crownrect.Intersects(_P1)&&!ownedP2)
            {
                ownedP1 = true;
            }
            if (_crownrect.Intersects(_P2)&&!ownedP1)
            {
                ownedP2 = true;
            }
            if (ownedP1)
                _crownrect = new Rectangle(p1.X, p1.Y, 20, 20);
            if (ownedP2)
                _crownrect = new Rectangle(p2.X, p2.Y, 20, 20);
        }


		/// <summary>
		/// resets the crown
		/// </summary>
        public void reset()
        {
            _positionY = 60;
            _positionX = 950;
            ownedP1 = false;
            ownedP2 = false;
            _crownrect = new Rectangle(_positionX, _positionY, 20, 20);
        }


		/// <summary>
		/// draws the crown
		/// </summary>
		/// <param name="spriteBatch"></param>
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(_crownrect.X, _crownrect.Y-40, 20, 20), Color.AliceBlue);
        }
    }
}
