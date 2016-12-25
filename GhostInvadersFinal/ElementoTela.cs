using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInvadersFinal
{
    public abstract class ElementoTela
    {
        protected Texture2D textura;
        protected Rectangle posicao;
        protected Color cor;
        protected string nomeTextura;

        public ElementoTela() { }

        public ElementoTela(string nomeTextura)
        {
            this.nomeTextura = nomeTextura;
        }

        public ElementoTela(string nomeTextura, Rectangle posicao, Color core)
        {
            this.nomeTextura = nomeTextura;
            this.posicao = posicao;
            this.cor = core == null ? core : Color.White;
        }
        
        public void LoadContent(ContentManager content)
        {
            this.textura = content.Load<Texture2D>(this.nomeTextura);
        }

        public virtual void Update(GameTime gameTime) { }

        public void Draw(SpriteBatch sp)
        {
            sp.Draw(this.textura, this.posicao, this.cor);
        }

        /// <summary>
        /// Verifica se colidiu com o retangulo passado.
        /// </summary>
        /// <param name="rect2">Outro objeto da colisão.</param>
        /// <returns>Retorna se colidiu ou não.</returns>
        public bool Colidiu(Rectangle rect2)
        {
            return this.posicao.Intersects(rect2);
        }


    }
}