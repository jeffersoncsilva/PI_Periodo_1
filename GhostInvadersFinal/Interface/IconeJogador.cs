using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GhostInvadersFinal.Helpers;

namespace GhostInvadersFinal.Interface
{
    class IconeJogador : ElementoTela
    {
        private Rectangle[] posicoes;
        public int posicaoAtual { get; private set; }

        public IconeJogador()
        {
            DefinePosicoes();
            this.nomeTextura = "Sprites/pac";
            this.posicao = PosicaoAtual();
            this.cor = Color.White;
        }
        
        public IconeJogador(string nomeTextura) : base(nomeTextura)
        {
            DefinePosicoes();
            this.posicao = PosicaoAtual();
            this.cor = Color.White;
        }
        
        public IconeJogador(string nomeTextura, Rectangle posicao, Color core) : base(nomeTextura, posicao, core)
        {
            DefinePosicoes();
        }

        public void MudaPosicaoAtual(int posicao)
        {
            posicaoAtual = posicao;
            this.posicao = PosicaoAtual();
        }

        private Rectangle PosicaoAtual()
        {
            return posicoes[this.posicaoAtual];
        }

        private void DefinePosicoes()
        {
            posicaoAtual = 0;
            posicoes = new Rectangle[6];
            int tam = PorcetagensTela.GetPorcetagemLargura(5);
            //tela de menu inicial do jogo.
            posicoes[0] = new Rectangle(PorcetagensTela.GetPorcetagemLargura(30), PorcetagensTela.GetPorcetagemAltura(35), tam, tam);
            posicoes[1] = new Rectangle(PorcetagensTela.GetPorcetagemLargura(25), PorcetagensTela.GetPorcetagemAltura(55), tam, tam);
            posicoes[2] = new Rectangle(PorcetagensTela.GetPorcetagemLargura(30), PorcetagensTela.GetPorcetagemAltura(75), tam, tam);

            //tela de pausa
            posicoes[3] = new Rectangle(PorcetagensTela.GetPorcetagemLargura(25), PorcetagensTela.GetPorcetagemAltura(20), tam, tam);
            posicoes[4] = new Rectangle(PorcetagensTela.GetPorcetagemLargura(20), PorcetagensTela.GetPorcetagemAltura(43), tam, tam);
            posicoes[5] = new Rectangle(PorcetagensTela.GetPorcetagemLargura(35), PorcetagensTela.GetPorcetagemAltura(65), tam, tam);

        }

    }
}
