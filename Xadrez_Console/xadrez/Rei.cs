
using Xadrez_Console.tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.xadrez {
    internal class Rei : Peca {
        public Rei(tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "R";
        }
    }
}
