
using Xadrez_Console.tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.xadrez {
    internal class Torre:Peca {


        public Torre(tabuleiro.Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "T";
        }
    }
}
