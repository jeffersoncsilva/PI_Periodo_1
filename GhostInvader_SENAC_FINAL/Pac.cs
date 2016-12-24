using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInvader_SENAC_FINAL
{
    class Pac
    {
        public Texture2D Textura { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Speed { get; set; }
        public bool isVisible { get; set; }

        public Pac(Texture2D textura, Vector2 position, Vector2 size, Vector2 speed)
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

        //Movimentação (direita/esquerda) controlada via teclado.
        public void Move(float larguraTela)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (Position.X > 0)
                    Position -= Speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (Position.X + Size.X < larguraTela)
                    Position += Speed;
            }
        }

    }
}
