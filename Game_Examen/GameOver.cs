using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Examen
{
    class GameOver
    {
        Vector2[] positions =
        {
            new Vector2(500,500),
            new Vector2(700,500)
        };

        private bool lastpressleft = false;
        private bool lastpressright = false;

        private int pos = 0;
        public int selection { get; set; }

        SpriteBatch spriteBatch;
        SpriteFont font;
        ControlScreens controls;
        public GameOver(SpriteFont f, SpriteBatch Batch)
        {
            spriteBatch = Batch;
            font = f; controls = new ControlScreens();
        }

        public void Draw(SpriteBatch spriteBatch,string winner)
        {
            spriteBatch.DrawString(font, winner, new Vector2(560, 400), Color.White);
            spriteBatch.DrawString(font, "Restart", new Vector2(560, 500), Color.White);
            spriteBatch.DrawString(font, "Exit", new Vector2(760, 500), Color.White);

            spriteBatch.DrawString(font, ">", positions[pos], Color.White);
        }
        public void update()
        {
            controls.Update();


            if (controls.left && !lastpressleft)
            {
                lastpressleft = true;
                pos--;
            }
            if (!controls.left)
                lastpressleft = false;

            if (controls.right && !lastpressright)
            {
                lastpressright = true;
                pos++;
            }
            if (!controls.right)
                lastpressright = false;


            if (pos == 2)
                pos = 0;
            if (pos == -1)
                pos = 1;

            if (controls.select)
                selection = pos + 1;
        }
    }
}
