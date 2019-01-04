using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Examen
{
    class GameState
	{
		#region variables and objects
		public string winner { get; set; }
		public bool gameover { get; set; }
		public bool reset1 { get; set; }
		public bool reset2 { get; set; }
		#endregion


		/// <summary>
		/// Checks if the game is over and who won depending on the alive bools or if the players overlap while 1 is the tagger
		/// </summary>
		/// <param name="p1Alive"></param>
		/// <param name="p2Alive"></param>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <param name="tag1"></param>
		/// <param name="tag2"></param>
		public void update(bool p1Alive, bool p2Alive, Rectangle p1,Rectangle p2,bool tag1,bool tag2)
		{

			reset1 = false;
			reset2 = false;
			if (p1Alive && !p2Alive)
			{
				reset2 = true;
			}
			if (!p1Alive && p2Alive)
			{
				reset1 = true;
			}
			if ((p1Alive && !p2Alive || p1.Intersects(p2)) && tag1 || (!p2Alive && p1Alive && tag2))
			{
				winner = "player1 wins";
				gameover = true;
				reset1 = false;
				reset2 = false;
			}
			if ((!p1Alive && p2Alive || p1.Intersects(p2)) && tag2 || (!p1Alive && p2Alive && tag1))
			{
				winner = "player2 wins";
				gameover = true;
				reset1 = false;
				reset2 = false;
			}
		}
    }
}
