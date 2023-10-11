
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
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
