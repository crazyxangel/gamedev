using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Game_Examen
{    
    public abstract class Tile
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public bool Collision { get; set; }
        public bool Deadly { get; set; }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, Position, Color.AliceBlue);
        }

    }
    public class BackgroundTile : Tile
    {
        public BackgroundTile(Texture2D texture, Vector2 pos)
        {
            Collision = false;
            Deadly = false;
            Texture = texture;
            Position = pos;
        }
    }
    public class SolidTile : Tile
    {
        public SolidTile(Texture2D texture, Vector2 pos)
        {
            Collision = true;
            Deadly = false;
            Texture = texture;
            Position = pos;
        }
    }
    public class DeadlyTile : Tile
    {
        public DeadlyTile(Texture2D texture, Vector2 pos)
        {
            Collision = true;
            Deadly = true;
            Texture = texture;
            Position = pos;
        }

    }
}
