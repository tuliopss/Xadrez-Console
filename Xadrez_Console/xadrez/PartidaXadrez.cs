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
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;
        public bool Xeque { get; private set; }

        public PartidaXadrez() {
            tab = new tabuleiro.TabuleiroClass(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Xeque = false; 
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQtdMovimento();
            Peca pecaCapturada = tab.RetirarPeca(destino);

            tab.SetPecaTab(p, destino);

            if (pecaCapturada != null) {
                Capturadas.Add(pecaCapturada);
            }
            return pecaCapturada;
        }

        public void DesfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = tab.RetirarPeca(destino);
            p.DecrementarQtdMovimento();

            if(pecaCapturada != null) {
                tab.SetPecaTab(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }

            tab.SetPecaTab(p, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if(EstaEmXeque(JogadorAtual)) {
                DesfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em cheque.");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual))) {
                Xeque = true;

            } else {
                Xeque = false;
            }

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

        public HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca p in Capturadas) {
                if (p.Cor == cor) {
                    aux.Add(p);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca p in Pecas) {
                if (p.Cor == cor) {
                    aux.Add(p);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));
            return aux;
        }

        private Cor Adversaria(Cor cor) {
            if (cor == Cor.Branca) {
                return Cor.Preta;
            }
            else {
                return Cor.Branca;
            }
        }

        private Peca GetRei(Cor cor) {
            foreach (Peca p in PecasEmJogo(cor)) {
                if (p is Rei) {
                    return p;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor) {
            Peca rei = GetRei(cor);
            if (rei == null) {
                throw new TabuleiroException("Não tem rei da cor " + cor + " no tabuleiro");
            }

            foreach (Peca p in PecasEmJogo(Adversaria(cor))) {
                bool[,] mat = p.MovimentosPossiveis();

                if (mat[rei.Posicao.Linha, rei.Posicao.Coluna]) {
                    return true;
                }
            }
            return false;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            tab.SetPecaTab(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        private void ColocarPecas() {
            ColocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(tab, Cor.Branca));

            ColocarNovaPeca('a', 8, new Torre(tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(tab, Cor.Preta));


        }
    }
}
