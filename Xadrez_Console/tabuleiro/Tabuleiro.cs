
namespace Xadrez_Console.tabuleiro {
    internal class Tabuleiro {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas) {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca GetPecaTab(int linha, int coluna) {
            return Pecas[linha,coluna];
        }

        public void SetPecaTab(Peca p, Posicao pos) {
            Pecas[pos.Linha, pos.Coluna] = p; //Atribui uma peça na matriz c a posicao.linha e .coluna
            p.Posicao = pos; //a peça p vai receber como posição o pos
        }
    }
}
