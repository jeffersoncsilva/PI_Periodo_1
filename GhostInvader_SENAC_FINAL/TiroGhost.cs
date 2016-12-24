using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInvader_SENAC_FINAL
{
    class TiroGhost
    {
        public Texture2D Textura { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Speed { get; set; }
        public bool isVisible { get; set; }

        public Texture2D TexturaTiroInimigo { get; set; }
        public Vector2 PositionTiroInimigo { get; set; }
        public Vector2 SizeTiroInimigo { get; set; }
        public Vector2 SpeedTiroInimigo { get; set; }
        public bool isVisibleTiroInimigo { get; set; }

        public TiroGhost(Texture2D textura, Vector2 position, Vector2 size, Vector2 speed)
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
            if (Position.X + Speed.X < 65)
            {
                Speed = new Vector2(-Speed.X, Speed.Y);
                Position = new Vector2(Position.X, Position.Y + 45);
            }
            if (Position.X + Speed.X + Size.X > screnSize.X - 25)
            {
                Speed = new Vector2(-Speed.X, Speed.Y);
                Position = new Vector2(Position.X, Position.Y + 45);
            }
            Position += Speed;
        }
        public bool isColides(Pac pac)
        {
            return (this.Position.X + this.Size.X > pac.Position.X &&
                     this.Position.X < pac.Position.X + pac.Size.X &&
                     this.Position.Y + this.Size.Y > pac.Position.Y &&
                     this.Position.Y < pac.Position.Y + pac.Size.Y &&
                     pac.isVisible);
        }
    }
}
