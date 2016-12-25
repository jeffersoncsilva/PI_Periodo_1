using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInvadersFinal.Interface
{
    class StringTela
    {
        string msg;
        Rectangle posicao;
        SpriteFont fonte;

        public StringTela(string msg, Rectangle local, SpriteFont font)
        {
            this.msg = msg;
            this.posicao = local;
            this.fonte = font;
        }

        public void SetSpriteFont(SpriteFont sf) { this.fonte = sf; }

        public void Draw(SpriteBatch sp)
        {
            //sp.DrawString(fonte, this.msg, this.dimensoes, Color.White);

            Vector2 size = fonte.MeasureString(msg);

            float xScale = (posicao.Width / size.X);
            float yScale = (posicao.Height / size.Y);

            // Taking the smaller scaling value will result in the text always fitting in the boundaires.
            float scale = Math.Min(xScale, yScale);

            // Figure out the location to absolutely-center it in the boundaries rectangle.
            int strWidth = (int)Math.Round(size.X * scale);
            int strHeight = (int)Math.Round(size.Y * scale);
            Vector2 position = new Vector2(posicao.X, posicao.Y);
            position.X = (((posicao.Width - strWidth) / 2) + posicao.X);
            position.Y = (((posicao.Height - strHeight) / 2) + posicao.Y);
            // Draw the string to the sprite batch!
            sp.DrawString(fonte, msg, position, Color.Yellow, 0.0f, new Vector2(0, 0), scale, SpriteEffects.None, 0.0f);

        }
    }
}
