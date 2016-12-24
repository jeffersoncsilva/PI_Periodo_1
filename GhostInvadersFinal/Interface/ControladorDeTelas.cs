using Microsoft.Xna.Framework.Graphics;

namespace GhostInvadersFinal.Interface
{
    /// <summary>
    /// Essa classe controla as telas do jogo.
    /// </summary>
    class ControladorDeTelas
    {
        private TelaJogo telaAtual;
        private SpriteFont fonteJogo;

        public ControladorDeTelas(SpriteFont fonte)
        {
            this.fonteJogo = fonte;
            this.telaAtual = new TelaJogo(4, this.fonteJogo);
        }

        public void Draw(SpriteBatch sp)
        {
            this.telaAtual.Draw(sp);
        }

    }
}
