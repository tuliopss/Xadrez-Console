
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.tabuleiro {
    internal abstract class Peca {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QntdMovimentos { get; protected set; }
        public TabuleiroClass Tab { get; protected set; }

        public Peca() { }

        public Peca(TabuleiroClass tab, Cor cor) {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QntdMovimentos = 0;
        }

        public void IncrementarQtdMovimento() {
            QntdMovimentos++;
        } public void DecrementarQtdMovimento() {
            QntdMovimentos--;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] mat = MovimentosPossiveis();

            for(int i = 0; i<Tab.Linhas; i++) {
                for (int j = 0; j < Tab.Colunas; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos) {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}
