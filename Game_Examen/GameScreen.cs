using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Examen
{
    class GameScreen
	{
		#region variables and objects
		public bool startscreen { get; set; }
        public bool playscreen { get; set; }
        public bool gameoverscreen{ get; set; }
        public int level { get; set; }
		#endregion

		/// <summary>
		/// sets the startscreen to true 
		/// </summary>
		public GameScreen()
        {
            startscreen = true;
        }

		/// <summary>
		/// Sets the right screen to true depending ont the selection
		/// </summary>
		/// <param name="screen"></param>
        public void update(int screen)
        {

            startscreen = false;
            playscreen = false;
            gameoverscreen = false;
            switch (screen)
            {
                case 0:
                    startscreen = true;
                    break;

                case 1:
                    playscreen = true;
                    break;

                case 10:
                    gameoverscreen = true;
                    break;
            }
        }
    }
}
