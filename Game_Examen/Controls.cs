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
        public bool left { get; set; }
        public bool right { get; set; }
        public bool up { get; set; }
        public bool down { get; set; }
        public abstract void Update();
    }
    public class ControlP1 : Controls
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            left = stateKey.IsKeyDown(Keys.Q);
            up = stateKey.IsKeyDown(Keys.Z);
            down = stateKey.IsKeyDown(Keys.S);
            right = stateKey.IsKeyDown(Keys.D);

        }
    }
    public class ControlP2 : Controls
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            left = stateKey.IsKeyDown(Keys.Left);
            up = stateKey.IsKeyDown(Keys.Up);
            down = stateKey.IsKeyDown(Keys.Down);
            right = stateKey.IsKeyDown(Keys.Right);

        }
    }
    public class ControlScreens : Controls
    {
        public bool select { get; set; }
        public bool back { get; set; }
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
