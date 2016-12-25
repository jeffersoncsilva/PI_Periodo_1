using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GhostInvadersFinal.Interface
{
    /// <summary>
    /// Essa classe controla as telas do jogo.
    /// </summary>
    class ControladorDeTelas
    {
        private TelaJogo telaAtual;
        private SpriteFont fonteJogo;
        private IconeJogador iconeJogador;

        private KeyboardState oldState;

        public ControladorDeTelas()
        {
            //CarregaTelaInicial();
            telaAtual = new TelaJogo(1);
            iconeJogador = new IconeJogador("Sprites/pac");
            oldState = Keyboard.GetState();
        }



        public void LoadContent(ContentManager content)
        {
            this.iconeJogador.LoadContent(content);
            this.fonteJogo = content.Load<SpriteFont>("Fonts/Ghost Of The Wild West");
            this.telaAtual.SetaSpriteFonte(this.fonteJogo);
        }


        public void Update(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();

            if (BoardGame.GameIsPaused || !BoardGame.GameIsStarted)
            {

                MudaPosicaoIcone(newState, oldState);

                TrataEscolhaJogador(newState, oldState);

                //fecha a tela de creditos.
                if (newState.IsKeyDown(Keys.Escape) && oldState.IsKeyUp(Keys.Escape))
                {
                    if (this.telaAtual.TelaAtual == 2)
                        CarregaTelaInicial();
                    else if (this.telaAtual.TelaAtual == 4)
                        BoardGame.FecharJogo();
                }
            }

            oldState = newState;
        }


        public void Draw(SpriteBatch sp)
        {
            this.telaAtual.Draw(sp);
            if (telaAtual.TelaAtual == 1 || telaAtual.TelaAtual == 3)
                this.iconeJogador.Draw(sp);
        }

        private void CarregaTelaCreditos()
        {
            telaAtual = new TelaJogo(2, this.fonteJogo);
            this.iconeJogador.MudaPosicaoAtual(3);
        }

        private void CarregaTelaInicial()
        {
            this.telaAtual = new TelaJogo(1, this.fonteJogo);
            this.iconeJogador.MudaPosicaoAtual(0);
        }

        private void CarregaTelaPausa()
        {
            this.telaAtual = new TelaJogo(3, this.fonteJogo);
        }

        private void CarregaTelaGameOver()
        {
            this.telaAtual = new TelaJogo(4, this.fonteJogo);
        }

        private void MudaPosicaoIcone(KeyboardState newState, KeyboardState oldState)
        {
            if (newState.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
            {
                if (telaAtual.TelaAtual == 1)
                {
                    if (iconeJogador.posicaoAtual == 0)
                        iconeJogador.MudaPosicaoAtual(1);
                    else if (iconeJogador.posicaoAtual == 1)
                        iconeJogador.MudaPosicaoAtual(2);
                }
                else if (telaAtual.TelaAtual == 3)
                {
                    if (iconeJogador.posicaoAtual == 3)
                        iconeJogador.MudaPosicaoAtual(4);
                    else if (iconeJogador.posicaoAtual == 4)
                        iconeJogador.MudaPosicaoAtual(5);
                }

            }
            else if (newState.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
            {
                if (telaAtual.TelaAtual == 1)
                {
                    if (iconeJogador.posicaoAtual == 2)
                        iconeJogador.MudaPosicaoAtual(1);
                    else if (iconeJogador.posicaoAtual == 1)
                        iconeJogador.MudaPosicaoAtual(0);
                }
                else if (telaAtual.TelaAtual == 3)
                {
                    if (iconeJogador.posicaoAtual == 4)
                        iconeJogador.MudaPosicaoAtual(3);
                    else if (iconeJogador.posicaoAtual == 5)
                        iconeJogador.MudaPosicaoAtual(4);
                }

            }
        }

        private void TrataEscolhaJogador(KeyboardState newState, KeyboardState oldState)
        {
            //verifica onde o jogador apertou enter.
            if (newState.IsKeyDown(Keys.Enter) && oldState.IsKeyUp(Keys.Enter))
            {
                //esta na tela inicial.
                if (telaAtual.TelaAtual == 1)
                {
                    if (iconeJogador.posicaoAtual == 0)
                    {
                        //inicia o jogo.
                    }
                    else if (iconeJogador.posicaoAtual == 1)
                    {
                        //mostra os creditos do jogo.
                        CarregaTelaCreditos();
                    }
                    else if (iconeJogador.posicaoAtual == 2)
                    {
                        //fecha o jogo.
                        BoardGame.FecharJogo();
                    }

                }
                //esta na tela de pausa.
                else if (telaAtual.TelaAtual == 3)
                {
                    if (iconeJogador.posicaoAtual == 3)
                    {
                        //retorna para o jogo.
                    }
                    else if (iconeJogador.posicaoAtual == 4)
                    {
                        //volta para o inicio do jogo.
                        CarregaTelaInicial();
                    }
                    else if (iconeJogador.posicaoAtual == 5)
                    {
                        //fecha o jogo.
                        BoardGame.FecharJogo();
                    }

                }
            }
        }

    }

}