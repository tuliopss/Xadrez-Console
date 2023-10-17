using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez_Console.Tabuleiro.Enums;
using Xadrez_Console.tabuleiro;
using System.Runtime.ConstrainedExecution;

namespace Xadrez_Console.xadrez {
    internal class Bispo : Peca {
        public Bispo(TabuleiroClass tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "B";
        }

        private bool PodeMover(Posicao pos) {
            Peca p = Tab.GetPecaTab(pos);

            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);


            //noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPecaTab(pos) != null && Tab.GetPecaTab(pos).Cor != Cor) {
                    break;
                }

                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }
            //nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPecaTab(pos) != null && Tab.GetPecaTab(pos).Cor != Cor) {
                    break;
                }

                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }
            //sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPecaTab(pos) != null && Tab.GetPecaTab(pos).Cor != Cor) {
                    break;
                }

                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);

            }  //sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPecaTab(pos) != null && Tab.GetPecaTab(pos).Cor != Cor) {
                    break;
                }

                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);

            }

            return mat;

        }
    }
}


