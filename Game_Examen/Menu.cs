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
		#region variables and objects
		private Vector2[] _positions =
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
		#endregion

		/// <summary>
		/// Constructor of menu requires a spritefond and the spritebatch
		/// </summary>
		/// <param name="f"></param>
		/// <param name="Batch"></param>
		public Menu(SpriteFont f, SpriteBatch Batch)
        {
            spriteBatch = Batch;
            font = f;controls = new ControlScreens();
        }

		/// <summary>
		/// draws the main menu
		/// </summary>
		/// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "play", new Vector2(320, 200), Color.White);
            spriteBatch.DrawString(font, "Exit", new Vector2(320, 300), Color.White);
            spriteBatch.DrawString(font, "menu option 3", new Vector2(320, 400), Color.White);
            spriteBatch.DrawString(font, "menu option 3", new Vector2(320, 500), Color.White);
            spriteBatch.DrawString(font, "menu option 3", new Vector2(320, 600), Color.White);
            spriteBatch.DrawString(font, "menu option 3", new Vector2(320, 700), Color.White);

            spriteBatch.DrawString(font, ">", _positions[pos], Color.White);
        }
		/// <summary>
		/// sets the screen variable to the gameover value
		/// </summary>
        public void gameover()
        {
            screen = 10;
        }
		/// <summary>
		/// updates menu depending on the controls
		/// </summary>
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
