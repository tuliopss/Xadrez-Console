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
        public int Turno { get; private set; }
        public Cor JogadorAtual;
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

        public void RealizaJogada(Posicao origem, Posicao destino) {
            ExecutaMovimento(origem, destino);
            Turno++;

            MudaJogador();

        }

        public void ValidarPosicaoOrigem(Posicao pos) {
            if (tab.GetPecaTab(pos) == null) {
                throw new TabuleiroException("Não existe peça nessa posição.");
            }

            if (JogadorAtual != tab.GetPecaTab(pos).Cor) {
                throw new TabuleiroException("A peça de origem não é sua.");
            }

            if (!tab.GetPecaTab(pos).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça escolhida.");

            }
        }
        public void ValidarPosicaoDestino(Posicao origem, Posicao destino) {
            if (!tab.GetPecaTab(origem).PodeMoverPara(destino)) {
                throw new TabuleiroException("Posição de origem inválida.");
            }
        }

        private void MudaJogador() {
            if (JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;
            }
            else {
                JogadorAtual = Cor.Branca;
            }

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
