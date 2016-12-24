using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInvader_SENAC_FINAL
{
    class Cenas
    {
        public Texture2D Ato1 { get; set; }
        public Texture2D Ato2 { get; set; }
        public Texture2D Ato3 { get; set; }
        public Texture2D Ato4 { get; set; }
        public Texture2D Ato5 { get; set; }
        public Texture2D Final { get; set; }
        public Vector2 Posicao { get; set; }
        public Vector2 Size { get; set; }
        public int fase { get; set; }

        public Cenas(Texture2D textura1, Texture2D textura2, Texture2D textura3, Texture2D textura4,
                     Texture2D textura5, Texture2D final, Vector2 position, Vector2 size)
        {
            Ato1 = textura1;
            Ato2 = textura2;
            Ato3 = textura3;
            Ato4 = textura4;
            Ato5 = textura5;
            Final = final;
            Posicao = position;
            Size = size;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            switch (fase)
            {
                case 1:
                    Posicao = new Vector2(Size.X / 2 - 710 / 2, Size.Y / 2 - 200 / 2);
                    spriteBatch.Draw(Ato1, Posicao, Color.White);
                    break;
                case 2:
                    spriteBatch.Draw(Ato2, Posicao, Color.White);
                    break;
                case 3:
                    spriteBatch.Draw(Ato3, Posicao, Color.White);
                    break;
                case 4:
                    spriteBatch.Draw(Ato4, Posicao, Color.White);
                    break;
                case 5:
                    spriteBatch.Draw(Ato5, Posicao, Color.White);
                    break;
                case 6:
                    spriteBatch.Draw(Final, Posicao, Color.White);
                    break;
            }
        }

    }
}
