using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GhostInvader_SENAC_FINAL
{
    class Tiro
    {
        public Texture2D Textura { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public Vector2 Speed { get; set; }
        public bool isVisible { get; set; }

        public Texture2D TexturaTiro { get; set; }
        public Vector2 PositionTiro { get; set; }
        public Vector2 SizeTiro { get; set; }
        public Vector2 SpeedTiro { get; set; }
        public bool isVisibleTiro { get; set; }

        public Tiro(Texture2D textura, Vector2 position, Vector2 size, Vector2 speed)
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

        //Movimentação controlada pelo Game Loop
        public void Move(Vector2 screenSize, Pac pac)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && Speed.X == 0.0f)
            {
                Speed = new Vector2(0.0f, -15.0f);
                isVisible = true;
            }
            else if (Speed.Y == 0)
            {
                this.Position = new Vector2((pac.Position.X + pac.Size.X / 2 - this.Size.X / 2), pac.Position.Y + pac.Size.Y / 2);//720.0f);
            }

            //Verificando limite superior da tela.
            if (Position.Y + Speed.Y < 0)
            {
                isVisible = false;
            }
            Position += Speed;
        }
        public void MoveTiroInimigo(Vector2 screenSize)
        {
            if (PositionTiro.Y + SpeedTiro.Y + SizeTiro.Y > screenSize.Y)
            {
                isVisibleTiro = false;
            }
            PositionTiro += SpeedTiro;
        }

        public bool isColides(Ghosts ghosts)
        {
            return (this.Position.X + this.Size.X > ghosts.Position.X &&
                     this.Position.X < ghosts.Position.X + ghosts.Size.X &&
                     this.Position.Y + this.Size.Y > ghosts.Position.Y &&
                     this.Position.Y < ghosts.Position.Y + ghosts.Size.Y &&
                     ghosts.isVisible);
        }


    }
}
