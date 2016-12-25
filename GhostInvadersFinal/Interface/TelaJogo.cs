using GhostInvadersFinal.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GhostInvadersFinal.Interface
{
    /// <summary>
    /// Controla o que será mostrado na tela.
    /// </summary>
    class TelaJogo
    {
        List<StringTela> stringsTela;
        SpriteFont fonte;
        public int TelaAtual { get; private set; }

        /// <summary>
        /// Cria a tela dizendo qual tela que e. 1 - tela de inicio. 2 - tela de creditos. 3 - tela de pausa
        /// 4 - tela de jogo.
        /// </summary>
        /// <param name="qualTela"></param>
        public TelaJogo(int qualTela, SpriteFont fonte)
        {
            TelaAtual = qualTela;
            this.stringsTela = new List<StringTela>();
            this.fonte = fonte;
            switch (qualTela)
            {
                case 1:
                    CriaTelaMenuInicio();
                    break;
                case 2:
                    CriaTelaCreditos();
                    break;
                case 3:
                    CriaTelaPausa();
                    break;
                case 4:
                    CriaTelaGameOver();
                    break;
            }
        }

        public TelaJogo(int qualTela)
        {
            TelaAtual = qualTela;
            this.stringsTela = new List<StringTela>();
            switch (qualTela)
            {
                case 1:
                    CriaTelaMenuInicio();
                    break;
                case 2:
                    CriaTelaCreditos();
                    break;
                case 3:
                    CriaTelaPausa();
                    break;
                case 4:
                    CriaTelaGameOver();
                    break;
            }
        }

        public void Draw(SpriteBatch sp)
        {
            foreach (StringTela st in this.stringsTela)
                st.Draw(sp);
        }

        public void SetaSpriteFonte(SpriteFont sFont)
        {
            this.fonte = sFont;
            foreach (StringTela t in stringsTela)
                t.SetSpriteFont(this.fonte);
        }

        private void CriaTelaGameOver()
        {
            Rectangle posicao;
            int larg = 0;
            int alt = 0;
            int x = 0;
            int y = 0;


            larg = GetLarguraElemento(80);
            alt = GetAlturaElemento(25);
            x = (BoardGame.LarguraDaTela / 2) - larg / 2;
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Fim de Jogo", posicao, this.fonte));


            larg = GetLarguraElemento(60);
            alt = GetAlturaElemento(40);
            x = (BoardGame.LarguraDaTela / 2) - larg / 2;
            y = (BoardGame.AlturaDaTela / 2) - (alt / 2) + 50;
            posicao = new Rectangle(x, y, larg, alt);
            string msg = $"Voce conseguiu {Pontuacao.Pontos} PTS.";
            this.stringsTela.Add(new StringTela(msg, posicao, this.fonte));



            larg = GetLarguraElemento(50);
            alt = GetAlturaElemento(25);
            x = (BoardGame.LarguraDaTela / 2) - larg / 2;
            y = BoardGame.AlturaDaTela - (alt / 2) - 10;
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Pressione ESC para sair.", posicao, this.fonte));


        }

        private void CriaTelaPausa()
        {
            Rectangle posicao;
            int larg = GetLarguraElemento(50);
            int alt = GetAlturaElemento(15);
            int x = (BoardGame.LarguraDaTela / 2) - larg / 2;
            int y = 5;

            //1° opcao - continuar
            y = (BoardGame.AlturaDaTela / 2) - (alt * 2);
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Continuar", posicao, this.fonte));

            //2° - voltar inicio.
            y = (BoardGame.AlturaDaTela / 2) - (alt / 2);
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Voltar Inicio", posicao, this.fonte));

            //3° - sair
            y = (BoardGame.AlturaDaTela / 2) + alt;
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Sair", posicao, this.fonte));
        }

        private void CriaTelaCreditos()
        {
            Rectangle posicao;
            int larg = GetLarguraElemento(60);
            int alt = GetAlturaElemento(15);
            int x = (BoardGame.LarguraDaTela / 2) - larg / 2;
            int y = 5;

            //Cria primeiro nome.
            x = (BoardGame.LarguraDaTela / 2) - larg / 2;
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Jefferson C. Silva", posicao, this.fonte));

            //cria segundo nome
            y = GetAlturaElemento(18);
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Henrique Moreno", posicao, this.fonte));

            //cria terceiro nome.
            y = GetAlturaElemento(35);
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Vinicius Coelho", posicao, this.fonte));

            //cria quarto nome.
            y = GetAlturaElemento(52);
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Rodrigo", posicao, this.fonte));

            //cria frase voltar.
            larg = GetLarguraElemento(35);
            x = (BoardGame.LarguraDaTela / 2) - larg / 2;
            y = (BoardGame.AlturaDaTela - (alt / 2) - 5);
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Precione ESC para voltar.", posicao, this.fonte));
        }

        private void CriaTelaMenuInicio()
        {
            int larg;
            int alt;
            int x;
            int y;
            Rectangle posicao;

            //cria o nome do jogo.
            alt = GetAlturaElemento(20);
            larg = GetLarguraElemento(80);
            posicao = new Rectangle((BoardGame.LarguraDaTela / 2) - larg / 2, 0, larg, alt);
            this.stringsTela.Add(new StringTela("Ghost Invaders", posicao, this.fonte));

            //Cria o botao de jogar.
            larg = GetLarguraElemento(30);
            alt = GetAlturaElemento(15);
            x = GetLarguraElemento(30);//nesse caso esta sendo usado para saber a posicao inicial em x.
            y = GetAlturaElemento(35);
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Jogar", posicao, this.fonte));

            //cria o botao de creditos.
            larg = GetLarguraElemento(30);
            alt = GetAlturaElemento(15);
            x = GetLarguraElemento(30);//nesse caso esta sendo usado para saber a posicao inicial em x.
            y = GetAlturaElemento(55);
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Creditos", posicao, this.fonte));

            //cria o botao de sair.
            larg = GetLarguraElemento(30);
            alt = GetAlturaElemento(15);
            x = GetLarguraElemento(30);//nesse caso esta sendo usado para saber a posicao inicial em x.
            y = GetAlturaElemento(75);
            posicao = new Rectangle(x, y, larg, alt);
            this.stringsTela.Add(new StringTela("Sair", posicao, this.fonte));
        }

        private int GetLarguraElemento(int v)
        {
            return PorcetagensTela.GetPorcetagemLargura(v);
        }

        private int GetAlturaElemento(int v)
        {
            return PorcetagensTela.GetPorcetagemAltura(v);
        }
    }
}