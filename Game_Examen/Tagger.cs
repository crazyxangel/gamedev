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
        private int _positionX;
        private int _positionY;

        private Rectangle _crownrect;
        private Rectangle _P1;
        private Rectangle _P2;

        public bool ownedP1 { get; set; }
        public bool ownedP2 { get; set; }

        /*private Vector2[] _positions =
         {
            new Vector2(300,200),
            new Vector2(300,300),
            new Vector2(300,400),
            new Vector2(300,500),
            new Vector2(300,600),
            new Vector2(300,700)
        };*/

        Texture2D texture;
        public Tagger(Texture2D t)
        {
            texture = t;
            _positionY = 60;//  |||
            _positionX = 950;//  ___
            _crownrect = new Rectangle(_positionX, _positionY, 20, 20);
        }
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
        public void reset()
        {
            _positionY = 60;
            _positionX = 950;
            ownedP1 = false;
            ownedP2 = false;
            _crownrect = new Rectangle(_positionX, _positionY, 20, 20);
        }
        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Rectangle(_crownrect.X, _crownrect.Y-40, 20, 20), Color.AliceBlue);
        }
    }
}
