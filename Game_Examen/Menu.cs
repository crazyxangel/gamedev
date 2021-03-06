﻿using Microsoft.Xna.Framework;
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
		public int level { get; set; }
		public bool createlevel { get; set; }
		public bool refselect { get; set; }
		private SpriteBatch spriteBatch;
        private ControlScreens controls;
        private SpriteFont font;


		private bool lastpressup = false;
		private bool lastpressdown = false;
		private bool lastpressleft = false;
		private bool lastpressright = false;
		#endregion

		/// <summary>
		/// Constructor of menu requires a spritefond and the spritebatch
		/// </summary>
		/// <param name="f"></param>
		/// <param name="Batch"></param>
		public Menu(SpriteFont f, SpriteBatch Batch)
        {
			level = 1;
            spriteBatch = Batch;
            font = f;
			controls = new ControlScreens();
        }

		/// <summary>
		/// draws the main menu
		/// </summary>
		/// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, "play", new Vector2(320, 200), Color.White);
            spriteBatch.DrawString(font, "level " + level + "use Q and D", new Vector2(320, 300), Color.White);
			spriteBatch.DrawString(font, "Exit", new Vector2(320, 400), Color.White);
			spriteBatch.DrawString(font, "menu option 3", new Vector2(320, 500), Color.White);
            spriteBatch.DrawString(font, "menu option 3", new Vector2(320, 600), Color.White);
            spriteBatch.DrawString(font, "Navigate with Z and S select with Enter", new Vector2(320, 700), Color.White);
			spriteBatch.DrawString(font, "The goal is to reach the crown first,", new Vector2(320, 800), Color.White);
			spriteBatch.DrawString(font, " when you reach the crown you become the tagger if you touch your oponent you win.", new Vector2(320, 850), Color.White);
			spriteBatch.DrawString(font, "But beware the moment one of you becomes the tagger both of you can die to enviromental hazards", new Vector2(320, 900), Color.White);
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
			if (!controls.select)
				refselect = false;
			if (controls.select && pos == 0 && !refselect)
			{
				createlevel = true;
			}
            if (controls.up && !lastpressup)
            {
                lastpressup = true;
                pos--;
            }
            if (controls.down && !lastpressdown)
            {
                lastpressdown = true;
                pos++;
            }
            
			if (controls.left && !lastpressleft && pos==1)
			{
				lastpressleft = true;
				level--;
			}
			if (controls.right && !lastpressright&&pos==1)
			{
				lastpressright = true;
				level++;
			}
			if (!controls.down)
				lastpressdown = false;
			if (!controls.up)
				lastpressup = false;
			if (!controls.left)
				lastpressleft = false;
			if (!controls.right)
				lastpressright = false;


			if (pos == 6)
                pos = 0;
            if (pos == -1)
                pos = 5;
			if (level == 3)
				level = 1;
			if (level == 0)
				level = 2;

            if (controls.select && !refselect&&(pos == 0||pos == 2))
                screen = pos+1;
        }
    }
}
