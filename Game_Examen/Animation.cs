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
		#region variables
		private List<Frame> frames;
        public Frame CurrentFrame { get; set; }
		public double offset { get; set; }
		public int MovesaSecond { get; set; }
        private int counter = 0;
        private double x = 0;
        private int _totalWidth = 0;
		#endregion

		public Animation()
        {
            frames = new List<Frame>();
            MovesaSecond = 1;
        }


		/// <summary>
		/// Used to add frames to the animation list
		/// </summary>
		/// <param name="rectangle"></param>
        public void AddFrame(Rectangle rectangle)
        {
            Frame newFrame = new Frame()
            {
                SourceRectangle = rectangle,
            };

            frames.Add(newFrame);
            CurrentFrame = frames[0];
            offset = CurrentFrame.SourceRectangle.Width;
            foreach (Frame f in frames)
                _totalWidth += f.SourceRectangle.Width;
        }


       /// <summary>
	   /// Updates the animation using the gametime
	   /// </summary>
	   /// <param name="gameTime"></param>
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
