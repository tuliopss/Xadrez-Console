
using Xadrez_Console.tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.xadrez {
    internal class Torre : Peca {
        public Torre(TabuleiroClass tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "T";
        }
        private bool PodeMover(Posicao pos) {
            Peca p = Tab.GetPecaTab(pos);

            return p == null || p.Cor != Cor;
        }
        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            while (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPecaTab(pos) != null && Tab.GetPecaTab(pos).Cor != Cor) {
                    break;
                }

                pos.Linha -= 1;
            }

            //abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            while (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPecaTab(pos) != null && Tab.GetPecaTab(pos).Cor != Cor) {
                    break;
                }

                pos.Linha += 1;
            }

            //direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            while (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPecaTab(pos) != null && Tab.GetPecaTab(pos).Cor != Cor) {
                    break;
                }

                pos.Coluna += 1;
            }

            //esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            while (Tab.CheckPosicao(pos) && PodeMover(pos)) {
                mat[pos.Linha, pos.Coluna] = true;

                if (Tab.GetPecaTab(pos) != null && Tab.GetPecaTab(pos).Cor != Cor) {
                    break;
                }

                pos.Coluna -= 1;
            }


            return mat;
        }



    }
}
