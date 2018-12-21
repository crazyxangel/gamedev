using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Examen
{
    class GameState
    {
        String winner;
        public GameState(bool p1Alive,bool p2Alive)
        {
            if (p1Alive && !p2Alive)
                winner = "Player 1 wins";
            if (p2Alive && !p1Alive)
                winner = "Player 2 wins";

        }
    }
}
