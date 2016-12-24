using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostInvadersFinal.Helpers
{
    public static class PorcetagensTela
    {
        /// <summary>
        /// Retorna a porcetagem da altura da tela em relação ao valor pedido.
        /// </summary>
        /// <param name="valor">Porcetagem desejada.</param>
        /// <returns>Valor do calculo.</returns>
        public static int GetPorcetagemAltura(int valor)
        {
            double f = (valor * BoardGame.AlturaDaTela) / 100;
            return Convert.ToInt32(f);
        }

        /// <summary>
        /// Retorna a porcetagem da largura da tela em relação ao valor pedido.
        /// </summary>
        /// <param name="valor">Porcetagem desejada.</param>
        /// <returns>Valor do calculo.</returns>
        public static int GetPorcetagemLargura(int valor)
        {
            double f = (valor * BoardGame.LarguraDaTela) / 100;
            return Convert.ToInt32(f);
        }



    }
}
