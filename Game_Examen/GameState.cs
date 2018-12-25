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
        public string winner { get; set; }
        public bool gameover { get; set; }
        private Rectangle player1;
        private Rectangle player2;

        public void update(bool p1Alive, bool p2Alive, Rectangle p1,Rectangle p2)
        {
            if(p1Alive&&!p2Alive)
            {
                winner = "player1 wins";
                gameover = true;
            }
            if(!p1Alive&&p2Alive)
            {
                winner = "player2 wins";
                gameover = true;
            }
        }
    }
}
