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
        int pos = 0;
        SpriteBatch spriteBatch;
        SpriteFont font;
        ControlScreens controls;
        public GameOver(SpriteFont f, SpriteBatch Batch)
        {
            spriteBatch = Batch;
            font = f; controls = new ControlScreens();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "Restart", new Vector2(560, 500), Color.White);
            spriteBatch.DrawString(font, "Menu", new Vector2(760, 500), Color.White);

            spriteBatch.DrawString(font, ">", positions[pos], Color.White);
        }
    }
}
