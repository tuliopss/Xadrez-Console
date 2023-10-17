using Xadrez_Console.Tabuleiro.Enums;
using Xadrez_Console.tabuleiro;

namespace Xadrez_Console.xadrez {
    class Peao : Peca {

        private PartidaXadrez partida;

        public Peao(TabuleiroClass Tab, Cor Cor, PartidaXadrez partida) : base(Tab, Cor) {
            this.partida = partida;
        }

        public override string ToString() {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos) {
            Peca p = Tab.GetPecaTab(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos) {
            return Tab.GetPecaTab(pos) == null;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca) {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.CheckPosicao(pos) && Livre(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.CheckPosicao(p2) && Livre(p2) && Tab.CheckPosicao(pos) && Livre(pos) && QntdMovimentos == 0) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.CheckPosicao(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.CheckPosicao(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }


            }
            else {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.CheckPosicao(pos) && Livre(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.CheckPosicao(p2) && Livre(p2) && Tab.CheckPosicao(pos) && Livre(pos) && QntdMovimentos == 0) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.CheckPosicao(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.CheckPosicao(pos) && ExisteInimigo(pos)) {
                    mat[pos.Linha, pos.Coluna] = true;
                }


            }

            return mat;
        }
    }
}