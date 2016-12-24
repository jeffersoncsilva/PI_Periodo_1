using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInvader_SENAC_FINAL
{
    class Ghosts
    {
        public Texture2D Textura { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Speed { get; set; }
        public bool isVisible { get; set; }
        public double tempo { get; set; }

        public Ghosts(Texture2D textura, Vector2 position, Vector2 size, Vector2 speed)
        {
            Textura = textura;
            Position = position;
            Size = size;
            Speed = speed;
            isVisible = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Textura, Position, Color.White);

        }

        public void Move(Vector2 screnSize)
        {
            if (Position.X + Speed.X < 45)
            {
                Speed = new Vector2(-Speed.X, Speed.Y);
                Position = new Vector2(Position.X, Position.Y + 45);
            }
            if (Position.X + Speed.X + Size.X > screnSize.X - 45)
            {
                Speed = new Vector2(-Speed.X, Speed.Y);
                Position = new Vector2(Position.X, Position.Y + 45);
            }
            Position += Speed;
        }


    }
}
