using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez_Console.tabuleiro {
    internal class TabuleiroClass {

        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public TabuleiroClass(int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca GetPecaTab(int linha, int coluna) {
            return Pecas[linha, coluna];
        }
        public Peca GetPecaTab(Posicao pos) {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos) {
            ValidarPosicao(pos);
            return GetPecaTab(pos) != null;
        }

        public void SetPecaTab(Peca p, Posicao pos) {
            if (ExistePeca(pos)) {
                throw new TabuleiroException("Já existe uma peça nessa posição.");
            }
            Pecas[pos.Linha, pos.Coluna] = p; //Atribui uma peça na matriz c a posicao.linha e .coluna
            p.Posicao = pos; //a peça p vai receber como posição o pos
        }

        public Peca RetirarPeca(Posicao pos) {
            if (GetPecaTab(pos) == null) {
                return null;
            }
            Peca aux = GetPecaTab(pos);
            aux.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;

        }

        public bool CheckPosicao(Posicao pos) {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas) {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos) {
            if (!CheckPosicao(pos)) {
                throw new TabuleiroException("Posição inválida.");
            }
        }
    }
}



