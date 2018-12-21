using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Examen
{
    class Animation
    {
        private List<Frame> frames;
        public Frame CurrentFrame { get; set; }
        public int MovesaSecond { get; set; }
        private int counter = 0;
        private double x = 0;
        public double offset { get; set; }


        private int _totalWidth = 0;

        public Animation()
        {
            frames = new List<Frame>();
            MovesaSecond = 1;
        }

        public void AddFrame(Rectangle rectangle)
        {
            Frame newFrame = new Frame()
            {
                SourceRectangle = rectangle,
                //Duration = duration
            };

            frames.Add(newFrame);
            CurrentFrame = frames[0];
            offset = CurrentFrame.SourceRectangle.Width;
            foreach (Frame f in frames)
                _totalWidth += f.SourceRectangle.Width;
        }
       
        public void Update(GameTime gameTime)
        {
            double temp = CurrentFrame.SourceRectangle.Width * ((double)gameTime.ElapsedGameTime.Milliseconds / 1000);

            x += temp;
            if (x >= CurrentFrame.SourceRectangle.Width / MovesaSecond)
            {
                Console.WriteLine(x);
                x = 0;
                counter++;
                if (counter >= frames.Count)
                    counter = 0;
                CurrentFrame = frames[counter];
                offset += CurrentFrame.SourceRectangle.Width;
            }
            if (offset >= _totalWidth)
                offset = 0;
        }
    }
}
