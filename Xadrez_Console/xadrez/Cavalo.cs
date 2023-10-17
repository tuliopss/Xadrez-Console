using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.xadrez {
    internal class Cavalo : Peca {
        public Cavalo(TabuleiroClass tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "C";
        }
        private bool PodeMover(Posicao pos) {
            Peca p = Tab.GetPecaTab(pos);

            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2);

            if (Tab.CheckPosicao(pos)  && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);

            if (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);

            if (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);

            if (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);

            if (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);

            if (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);

            if (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);

            if (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;
            }
            return mat;

        }
        //public override bool[,] MovimentosPossiveis() {
        //    bool[,] mat = new bool[Tab.Linhas,Tab.Colunas];

        //    Posicao pos = new Posicao(0, 0);

        //    pos.DefinirValores( Posicao.Linha - 1, Posicao.Coluna - 2);
        //    if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
        //        mat[pos.Linha, pos.Coluna] = true;
        //    }
        //    pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1);
        //    if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
        //        mat[pos.Linha, pos.Coluna] = true;
        //    }
        //    pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1);
        //    if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
        //        mat[pos.Linha, pos.Coluna] = true;
        //    }
        //    pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2);
        //    if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
        //        mat[pos.Linha, pos.Coluna] = true;
        //    }
        //    pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2);
        //    if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
        //        mat[pos.Linha, pos.Coluna] = true;
        //    }
        //    pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1);
        //    if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
        //        mat[pos.Linha, pos.Coluna] = true;
        //    }
        //    pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1);
        //    if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
        //        mat[pos.Linha, pos.Coluna] = true;
        //    }
        //    pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 2);
        //    if (Tab.PosicaoValida(pos) && PodeMover(pos)) {
        //        mat[pos.Linha, pos.Coluna] = true;
        //    }

        //    return mat;
        //}
    }
}


