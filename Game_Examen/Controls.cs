using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Examen
{
    public abstract class Controls
    {
		#region variables
		public bool left { get; set; }
        public bool right { get; set; }
        public bool up { get; set; }
        public bool down { get; set; }
		#endregion
		public abstract void Update();
    }


	/// <summary>
	/// Abstract class controls for player 1
	/// </summary>
    public class ControlP1 : Controls
    {
		/// <summary>
		/// Updates the controlls
		/// </summary>
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            left = stateKey.IsKeyDown(Keys.Q);
            up = stateKey.IsKeyDown(Keys.Z);
            down = stateKey.IsKeyDown(Keys.S);
            right = stateKey.IsKeyDown(Keys.D);

        }
    }


	/// <summary>
	///  Abstract class controls for player 2
	/// </summary>
	public class ControlP2 : Controls
	{
		/// <summary>
		/// Updates the controlls
		/// </summary>
		public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            left = stateKey.IsKeyDown(Keys.Left);
            up = stateKey.IsKeyDown(Keys.Up);
            down = stateKey.IsKeyDown(Keys.Down);
            right = stateKey.IsKeyDown(Keys.Right);

        }
    }


	/// <summary>
	///  Abstract class controls for menu
	/// </summary>
	public class ControlScreens : Controls
	{
		#region variables
		public bool select { get; set; }
        public bool back { get; set; }
		#endregion

		/// <summary>
		/// Updates the controlls
		/// </summary>
		public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            back = stateKey.IsKeyDown(Keys.Back);
            select = stateKey.IsKeyDown(Keys.Enter);
            left = stateKey.IsKeyDown(Keys.Q);
            up = stateKey.IsKeyDown(Keys.Z);
            down = stateKey.IsKeyDown(Keys.S);
            right = stateKey.IsKeyDown(Keys.D);
        }
    }
}
