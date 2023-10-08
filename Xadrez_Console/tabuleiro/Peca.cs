
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.tabuleiro {
    internal class Peca {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QntdMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca() { }

        public Peca(Posicao posicao, Cor cor, Tabuleiro tabuleiro) {
            Posicao = posicao;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QntdMovimentos = 0;
        }
    }
}
    