using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Examen
{
    class Menu
    {
        Vector2[] positions =
        {
            new Vector2(300,200),
            new Vector2(300,300),
            new Vector2(300,400),
            new Vector2(300,500),
            new Vector2(300,600),
            new Vector2(300,700)
        };

        int pos = 0;
        public int screen { get; set; }

        private SpriteBatch spriteBatch;
        private ControlScreens controls;
        private SpriteFont font;

        private bool lastpressup = false;
        private bool lastpressdown = false;

        public Menu(SpriteFont f, SpriteBatch Batch)
        {
            spriteBatch = Batch;
            font = f;controls = new ControlScreens();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "play", new Vector2(320, 200), Color.White);
            spriteBatch.DrawString(font, "quit", new Vector2(320, 300), Color.White);
            spriteBatch.DrawString(font, "menu option 3", new Vector2(320, 400), Color.White);
            spriteBatch.DrawString(font, "menu option 3", new Vector2(320, 500), Color.White);
            spriteBatch.DrawString(font, "menu option 3", new Vector2(320, 600), Color.White);
            spriteBatch.DrawString(font, "menu option 3", new Vector2(320, 700), Color.White);

            spriteBatch.DrawString(font, ">", positions[pos], Color.White);
        }
        public void gameover()
        {
            screen = 10;
        }
        public void update()
        {
            controls.Update();


            if (controls.up && !lastpressup)
            {
                lastpressup = true;
                pos--;
            }
            if (!controls.up)
                lastpressup = false;

            if (controls.down && !lastpressdown)
            {
                lastpressdown = true;
                pos++;
            }
            if (!controls.down)
                lastpressdown = false;


            if (pos == 6)
                pos = 0;
            if (pos == -1)
                pos = 5;

            if (controls.select)
                screen = pos+1;
            /*
            if (controls.left)
            if (controls.right)

            if (controls.back)
            */
        }
    }
}
