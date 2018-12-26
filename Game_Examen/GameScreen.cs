﻿using Microsoft.Xna.Framework;
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
        public bool startscreen { get; set; }
        public bool playscreen { get; set; }
        public bool gameoverscreen{ get; set; }
        public int level { get; set; }
        


        public GameScreen()
        {
            startscreen = true;
        }
        public void update(int screen)
        {

            startscreen = false;
            playscreen = false;
            gameoverscreen = false;
            //gameoverscreen = false;
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
