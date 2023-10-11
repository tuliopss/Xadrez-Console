using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xadrez_Console.tabuleiro;
using Xadrez_Console.Tabuleiro.Enums;

namespace Xadrez_Console.xadrez {
    internal class PartidaXadrez {
        public tabuleiro.TabuleiroClass tab { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool Terminada { get; private set; }
        public PartidaXadrez() {
            tab = new tabuleiro.TabuleiroClass(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQtdMovimento();
            Peca PecaCapturada = tab.RetirarPeca(destino);

            tab.SetPecaTab(p, destino);
        }

        private void ColocarPecas() {
            tab.SetPecaTab(new Torre(tab, Cor.Branca), new PosicaoXadrez('a', 1).ToPosicao()); 
            tab.SetPecaTab(new Torre(tab, Cor.Branca), new PosicaoXadrez('h', 1).ToPosicao()); 

            tab.SetPecaTab(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 4).ToPosicao()); 
            
            tab.SetPecaTab(new Torre(tab, Cor.Preta), new PosicaoXadrez('a', 8).ToPosicao()); 
            tab.SetPecaTab(new Torre(tab, Cor.Preta), new PosicaoXadrez('h', 8).ToPosicao()); 
            
        }
    }
}
