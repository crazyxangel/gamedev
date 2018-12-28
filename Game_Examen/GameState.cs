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

        public void update(bool p1Alive, bool p2Alive, Rectangle p1,Rectangle p2,bool tag1,bool tag2)
        {
            if(p1Alive&&!p2Alive|| p1.Intersects(p2) && tag1)
            {
                winner = "player1 wins";
                gameover = true;
            }
            if(!p1Alive&&p2Alive|| p1.Intersects(p2) && tag2)
            {
                winner = "player2 wins";
                gameover = true;
            }
        }
    }
}
